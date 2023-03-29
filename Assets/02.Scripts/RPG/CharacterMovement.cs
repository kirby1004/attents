using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterMovement : CharacterProperty
{
    protected void MoveToPos(Vector3 pos, UnityAction done = null)
    {
        StopAllCoroutines();
        StartCoroutine(MovingToPos(pos,done));
    }
    protected void FollowTarget(Transform target)
    {
        StopAllCoroutines();
        StartCoroutine(FollowingTarget(target));
    }

   IEnumerator MovingToPos(Vector3 pos, UnityAction done)
    {
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();
        yield return StartCoroutine(Rotating(dir));

        myAnim.SetBool("IsMoving", true);
        while (dist > 0.0f)
        {
            if (!myAnim.GetBool("isAttacking"))
            {
                float delta = Time.deltaTime * moveSpeed;
                if (dist - delta < 0.0f)
                {
                    delta = dist;
                }
                dist -= delta;
                transform.Translate(dir * delta, Space.World);
            }
            yield return null;
        
        }
        myAnim.SetBool("IsMoving", false);
        done?.Invoke(); 
    }

    IEnumerator Rotating(Vector3 dir)
    {
        float angle = Vector3.Angle(transform.forward, dir);
        float rotDir = 1.0f;
        if (Vector3.Dot(transform.right, dir) < 0.0f)
        {
            rotDir = -1.0f;
        }
        while (angle > 0.0f)
        {
            float delta = Time.deltaTime * RotSpeed;
            if( angle - delta < 0.0f)
            {
                angle = delta;
            }
            angle -= delta;
            transform.Rotate(Vector3.up * rotDir * delta);
            yield return null;
        }
    }

    IEnumerator FollowingTarget(Transform target)
    {
        while (target != null)
        {
            if(target.GetComponent<IBattle>() != null)
            {
                if (!target.GetComponent<IBattle>().IsLive) yield break;
            }
            if(!myAnim.GetBool("isAttacking")) playTime += Time.deltaTime;
            Vector3 dir = Vector3.zero;
            float delta = 0.0f;
            if (!myAnim.GetBool("isAttacking"))
            {
                myAnim.SetBool("IsMoving", false);
                dir = target.position - transform.position;
                float dist = dir.magnitude - AttackRange;
                dir.Normalize();
                
                if (dist > 0.0f)
                {
                    delta = moveSpeed * Time.deltaTime;
                    if (dist <= delta)
                    {
                        delta = dist;
                    }

                    myAnim.SetBool("IsMoving", true);
                    transform.Translate(dir * delta, Space.World);
                }
                else
                {
                    if (!myAnim.GetBool("isAttacking"))
                    {
                        if(playTime >= AttackDelay)
                        {
                            playTime = 0.0f;
                            myAnim.SetTrigger("Attack");
                        }
                    }
                }
               
            }

            float angle = Vector3.Angle(transform.forward, dir);
            if (angle > Mathf.Epsilon)
            {
                float rotDir = 1.0f;
                if (Vector3.Dot(transform.right, dir) < 0.0f)
                {
                    rotDir = -1.0f;
                }
                delta = Time.deltaTime * RotSpeed;
                if (angle < delta)
                {
                    delta = angle;
                }
                transform.Rotate(transform.up * rotDir * delta, Space.World);
            }
            yield return null;
                
        }
    }



}
