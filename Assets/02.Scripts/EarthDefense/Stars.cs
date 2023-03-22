using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // 발사전과 후의 상태를 기준으로 Bomb의 State를 구분
    bool isFire = false; //
    public float StarSpeed = 10.0f;
    //Rigidbody myBombRb;
    //public GameObject orgTarget; // Target의 프리팹을 직접 지정해 줄 때
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

            // Ray 값은 World 공간 상의 값
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
