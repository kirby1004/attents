using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // 발사전과 후의 상태를 기준으로 Bomb의 State를 구분
    bool isFire = false; //
    public float StarSpeed = 10.0f;
    public GameObject fireEffect;
    public float BoomLife = 5.0f;
    public GameObject myEarth;
    public Transform myStars;


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
            ray.direction = myEarth.transform.position - transform.position;
            if (Physics.Raycast(ray, out RaycastHit hit, delta))
            {
                Destroy(hit.transform.gameObject);
            }

            transform.Translate(Vector3.forward * delta);


        }
    }
    Vector3 targetPos;
    IEnumerator MovingToEarth(Vector3 pos)
    {
        targetPos = transform.position;
        Vector3 dir = pos - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();

        while (dist > 0.0f)
        {
            float delta = StarSpeed * Time.deltaTime;
            if (dist - delta < 0.0f)
            {
                delta = dist;
            }

            //transform.Translate(dir * delta, Space.World);
            targetPos += dir * delta;
            //transform.position = Vector3.Lerp(transform.position, targetPos, Velocity * Time.deltaTime);
            dist -= delta;

            yield return null;
        }

    }

    public void OnFire()
    {
        isFire = true;
        transform.SetParent(null);

        Debug.Log("Fire!");
        GetComponent<Collider>().isTrigger = false;
    }

}
