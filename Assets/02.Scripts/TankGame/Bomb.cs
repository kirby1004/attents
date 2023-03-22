using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // 발사전과 후의 상태를 기준으로 Bomb의 State를 구분
    bool isFire = false;
    public float bombSpeed = 10000.0f;
    //Rigidbody myBombRb;
    //public GameObject orgTarget; // Target의 프리팹을 직접 지정해 줄 때
    public GameObject fireEffect;
    public float BoomLife = 5.0f;
    void Awake()
    {
        //myBombRb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isFire)
        {
            //myBombRb.AddForce(0, 0, bombSpeed);
            float delta = bombSpeed * Time.deltaTime;

            // Ray 값은 World 공간 상의 값
            Ray ray = new Ray();
            ray.origin = transform.position;
            ray.direction = transform.forward;
            if(Physics.Raycast(ray, out RaycastHit hit, delta))
            {
                DestroyObject(hit.transform.gameObject);
            }
            BoomLife -= Time.deltaTime;
            if( BoomLife <= 0.0f)
            {
                Destroy(gameObject);
            }
            
            transform.Translate(Vector3.forward * delta);
        }
    }

    public void OnFire()
    {
        isFire = true;
        transform.SetParent(null);
        //transform.parent = null;
     
        //FireEffect();

        Debug.Log("Fire!");
        GetComponent<Collider>().isTrigger = false;
    }


    // 물리적인 충돌 시 발생하는 이벤트 함수들

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.tag == "BOMB") return;
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
    }

    // 감지 센서 발발 시의 이벤트 함수들
    // 물리적인 충돌은 무시하고 물체의 감지만을 체크한다

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        //if (!other.gameObject.transform.CompareTag("BOMB"))
        //{
        //    Destroy(other.gameObject);
        //}

        if (other.gameObject.tag == "BOMB") return;

        //DestroyObject(other.gameObject);
    }

    void DestroyObject(GameObject obj)
    {
        Vector3 tmpPos = obj.transform.position;
        Destroy(obj.gameObject);
        StartCoroutine(CreateDelay(tmpPos));
    }

    IEnumerator CreateDelay(Vector3 tmpPos)
    {
        yield return new WaitForSeconds(1.0f);

        // Project 안의 파일(프리팹)을 읽어와서 인스턴스를 생성하는 방법
        GameObject org = Resources.Load("Target") as GameObject;

        if (org != null)
        {
            GameObject obj = Instantiate(org);
            tmpPos.x = Random.Range(-8.0f, 8.0f);
            obj.transform.position = tmpPos;
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }

}
