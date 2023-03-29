using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovement : ArcherProperty
{
    protected void ArcherMovingToPos(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(ArcherMoveToPos(pos));
    }

    IEnumerator ArcherMoveToPos(Vector3 pos)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        yield return StartCoroutine(ArcherRotating(dir));
        myArcher.SetBool("IsMoving", true);
        while (dist > 0.0f)
        {
            if (!myArcher.GetBool("isAttacking"))
            {
                float delta = ArcherSpeed * Time.deltaTime;
                if (dist - delta < 0.0f)
                {
                    delta = dist;
                }
                dist -= delta;
                transform.Translate(dir * delta, Space.World);
            }
            yield return null;
        }
        myArcher.SetBool("IsMoving", false);
    }

    IEnumerator ArcherRotating(Vector3 dir)
    {
        float angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -1.0f;
        }
        while (angle > 0.0f)
        {
            float delta = Time.deltaTime * ArcherRotate;
            if (angle - delta < 0.0f)
            {
                angle = delta;
            }
            angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta);
            yield return null;
        }
    }


    protected void ArcherAttacking(Vector3 pos)
    {
        StopAllCoroutines();
        StartCoroutine(ArcherAttackStart(pos));
    }

    IEnumerator ArcherAttackStart(Vector3 pos)
    {
        myArcher.SetTrigger("Skill");
        yield return null;
    }

    IEnumerator ArcherAttackEnd(Vector3 pos)
    {

        yield return null;
    }

}
