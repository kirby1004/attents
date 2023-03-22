using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //IEnumerator Ÿ������ ������ �����ϰ� Coroutine �Լ� �����ϴ� ���
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
            // �ڷ�ƾ ������ ���ؼ��� IEnumerator �ν��Ͻ��� �����Ͽ��� �Ѵ�.
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
        float t = 0.0f; // ���� �ð�
        float dir = 1.0f; // ���� ���� ����
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
