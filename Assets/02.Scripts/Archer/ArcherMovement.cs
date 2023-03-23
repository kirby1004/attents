using System.Collections;
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

        yield return ArcherRotating(dir);
        myArcher.SetBool("Ismoving", true);
        while (dist > 0.0f)
        {
            float delta = ArcherSpeed * Time.deltaTime;
            if(dist - delta < 0.0f)
            {
                delta = dist;
            }
            dist -= delta;
            transform.Translate(dir * delta);
            yield return null;
        }
        myArcher.SetBool("Ismoving", false);
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
            float delta = ArcherRotate * Time.deltaTime;
            if(angle - delta < 0.0f)
            {
                delta = angle;
            }
            angle -= delta;
            transform.Rotate(Vector3.up * angle * rotDir);
            yield return null;
        }
    }

    IEnumerator ArcherAttack(Vector3 pos)
    {


        yield return null;
    }
}
