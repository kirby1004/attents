using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //IEnumerator 타입으로 변수를 선언하고 Coroutine 함수 실행하는 방법
    //IEnumerator coFunc;

    Coroutine move = null;
    public GameObject destroyEffect = null;


    void Start()
    {
        //coFunc = Moving();
        //move = StartCoroutine(Moving());
    }

    void Update()
    {
        //coFunc.MoveNext();
        if(Input.GetKeyDown(KeyCode.F1))
        {
            // 코루틴 중지를 위해서는 IEnumerator 인스턴스를 삭제하여야 한다.
            StopCoroutine(move);
        }
    }

    bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        if (!isQuitting)
        {
            GameObject obj = Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(obj, 2.0f);
        }
    }

    IEnumerator Moving()
    {
        float range = 2.0f;
        Vector3 startPos, destPos;
        float t = 0.0f; // 보간 시간
        float dir = 1.0f; // 값의 증감 방향
        float delayTime = 1.0f;


        t = 0.5f;
        destPos = startPos = transform.position;
        startPos.x -= range / 2.0f;
        destPos.x += range / 2.0f;

        while (true)
        {
            t = Mathf.Clamp(t + dir * Time.deltaTime, 0.0f, 1.0f);
            if (Mathf.Approximately(t, 0.0f) || Mathf.Approximately(t, 1.0f))
            {
                dir *= -1.0f;
                yield return new WaitForSeconds(delayTime);
            }
            transform.position = Vector3.Lerp(startPos, destPos, t);
            yield return null;
        }
    }
}
