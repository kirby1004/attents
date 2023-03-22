using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picking : MonoBehaviour
{
    //Vector3 click;
    public float moveSpeed = 5.0f;
    Coroutine myCoFunc;
    bool isMoving = false;
    public Transform headTr;
    public Transform cannonTr;
    public Transform muzzleTr;
    float headRotSpeed = 180.0f;
    bool isDist = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& isMoving == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit) && isDist == false)
            {
                //transform.position = Vector3.MoveTowards(transform.position, hit.point, moveSpeed * Time.deltaTime);

                myCoFunc = StartCoroutine(MovingToPos(hit.point));
                
            }
        }

    }

    IEnumerator MovingToPos(Vector3 pos)
    {
        Vector3 startPos, destPos;
        startPos = this.transform.position;
        destPos = pos;
        Vector3 distance = destPos - startPos;
        
        float t = 0.0f;

        while (true)
        {
            t = Mathf.Clamp(t + Time.deltaTime, 0.0f, 1.0f);
            if (!Mathf.Approximately(distance.magnitude, 0.0f))
            {
                startPos = transform.position;
                yield return null;
            }
            if (!Mathf.Approximately(t, 1.0f))
            {
                isMoving = true;
                isDist = true;
                transform.position = Vector3.Lerp(startPos, destPos, t/2);
            }
            else if (Mathf.Approximately(t, 1.0f))
            {
                isDist = false;
                isMoving = false;
                transform.position = Vector3.Lerp(startPos, destPos, 1.0f);
                StopCoroutine(myCoFunc);
            }
            transform.rotation = Quaternion.LookRotation(distance, Vector3.up);
            yield return null;
        }
    }
}
