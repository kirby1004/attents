using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // �߻����� ���� ���¸� �������� Bomb�� State�� ����
    bool isFire = false; //
    public float StarSpeed = 10.0f;
    //Rigidbody myBombRb;
    //public GameObject orgTarget; // Target�� �������� ���� ������ �� ��
    public GameObject fireEffect;
    public float BoomLife = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire)
        {
            //myBombRb.AddForce(0, 0, bombSpeed);
            float delta = StarSpeed * Time.deltaTime;

            // Ray ���� World ���� ���� ��
            Ray ray = new Ray();
            ray.origin = transform.position;
            ray.direction = transform.forward;
            if (Physics.Raycast(ray, out RaycastHit hit, delta))
            {
                DestroyObject(hit.transform.gameObject);
            }
            BoomLife -= Time.deltaTime;
            if (BoomLife <= 0.0f)
            {
                Destroy(gameObject);
            }

            transform.Translate(Vector3.forward * delta);
        }
    }



}
