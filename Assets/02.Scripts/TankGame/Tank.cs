using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float tankSpeed = 3.0f;
    public float rotSpeed = 180.0f;
    public float topRotSpeed = 90.0f;
    public float cannonUpDownSpeed = 90.0f;
    public Transform myTop = null;
    public Transform myCannon = null;
    public Transform myMuzzle = null;
    public Bomb myBomb = null;
    public GameObject orgBomb = null;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * tankSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            myTop.Rotate(Vector3.down * topRotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myTop.Rotate(Vector3.up * topRotSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            myCannon.Rotate(Vector3.left * cannonUpDownSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myCannon.Rotate(Vector3.right * cannonUpDownSpeed * Time.deltaTime);         
        }

        ClampCannonUpDownAngle();
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myBomb.OnFire();
            myBomb = null;
            
            /*
            GameObject obj = Instantiate(orgBomb);                // 원본 orgBomb에서 새로운 인스턴스 생성 ==> obj 로 생성
            obj.transform.SetParent(myMuzzle);                    // 새로 생성된 오브젝트를 myMuzzle 의 자식으로 설정
            obj.transform.localPosition = Vector3.zero;           // 새로 생성된 오브젝트의 localPosition을 Vector3.zero로 설정 -> 부모 기준 원점
            obj.transform.localRotation = myMuzzle.localRotation; // 새로 생성된 오브젝트의 localRotation을 부모 기준 rotation 값과 동일하게 한다 
            */
            
            GameObject obj = Instantiate(orgBomb, myMuzzle);
            myBomb = obj.GetComponent<Bomb>();          // GameObject obj 인스턴스에서 Bomb이라는 컴포넌트의 참조값을 가져온다

            StartCoroutine(playFireEffect());
        }
    }

    IEnumerator playFireEffect()
    {
        GameObject fireEffect = Instantiate(myBomb.fireEffect, myMuzzle.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.4f);

        Destroy(fireEffect);
    }

    void ClampCannonUpDownAngle()
    {
        Vector3 angle = myCannon.localRotation.eulerAngles;
        if (angle.x > 180.0f)
        {
            angle.x -= 360.0f;
            Debug.Log($"{angle.x}");
        }
        /*
        if (angle.x > 15.0f)
        {
            angle.x = 15.0f;
            Debug.Log($"{angle.x}");
        }
        if (angle.x < -60.0f)
        {
            angle.x = -60.0f;
            Debug.Log($"{angle.x}");
        }*/

        angle.x = Mathf.Clamp(angle.x, -60.0f, 15.0f);
        //Debug.Log($"{angle.x}");
        myCannon.localRotation = Quaternion.Euler(angle);

    }

    
}
