using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//
public class Picking_ver2 : MonoBehaviour
{
    //public clickact clickaction = null;
    //public UnityAction<Vector3> clickAtcion = null;
    public float moveSpeed = 5.0f;
    Coroutine myCoFunc;
    public float RotateSpeed = 60.0f;
    public float Velocity = 2.0f;
    public LayerMask PickMask;
    public LayerMask enemyMask;
    void Start()
    {
        targetPos = transform.position;
        targetRot = transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,PickMask) )
            {
                //if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ground"))
                if (((1<< transform.gameObject.layer)& enemyMask) == 0)
                {
                    //clickAtcion?.Invoke(hit.point);
                    StopAllCoroutines();
                    targetPos = transform.position;
                    targetRot = transform.rotation.eulerAngles;
                    //StartCoroutine(MovingToPos(hit.point));
                }

            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, Velocity * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(targetRot),RotateSpeed*Time.deltaTime);
    }
    Vector3 targetPos;
    IEnumerator MovingToPos(Vector3 pos)
    {
        pos.y += 0.5f;

        targetPos = transform.position;
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();
        if (dist > 0.0f)
        {

        }
        //float d = Vector3.Dot(transform.forward, dir);
        //float r = Mathf.Acos(d);

        //float angle = 180.0f * (r / Mathf.PI);
        //transform.Rotate(Vector3.up * angle);

        //if( Vector3.Dot(transform.right,dir)< 0.0f){
        // }
        yield return StartCoroutine(Roatation(dir));

        while (dist>0.0f)
        {
            float delta = moveSpeed * Time.deltaTime;
            if (dist -delta < 0.0f)
            {
                delta = dist;
            }
            targetPos += dir * delta;
            //transform.position = Vector3.Lerp(transform.position, targetPos, Velocity * Time.deltaTime);
            dist -= delta;

            yield return null;
        }

    }
    Vector3 targetRot;
    IEnumerator Roatation(Vector3 dir)
    {
        float d = Vector3.Dot(transform.forward, dir);
        float r = Mathf.Acos(d);
        float angle = r * Mathf.Rad2Deg;
        float retdir = 1.0f;
        if(Vector3.Dot(transform.right,dir) < 0.0f)
        {
            retdir = -1.0f;
        }
        while (angle >0.0f)
        {
            float delta = 360.0f* Time.deltaTime;
            if (angle - delta <0.0f)
            {
                delta = angle;
            }
            //transform.Rotate(Vector3.up *delta*retdir);
            targetRot.y += retdir * delta;
            angle -= delta;
            yield return null;
        }
    }




}
