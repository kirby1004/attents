using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // �߻����� ���� ���¸� �������� Bomb�� State�� ����
    bool isFire = false;
    public float bombSpeed = 10000.0f;
    //Rigidbody myBombRb;
    //public GameObject orgTarget; // Target�� �������� ���� ������ �� ��
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

            // Ray ���� World ���� ���� ��
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


    // �������� �浹 �� �߻��ϴ� �̺�Ʈ �Լ���

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

    // ���� ���� �߹� ���� �̺�Ʈ �Լ���
    // �������� �浹�� �����ϰ� ��ü�� �������� üũ�Ѵ�

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

        // Project ���� ����(������)�� �о�ͼ� �ν��Ͻ��� �����ϴ� ���
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
