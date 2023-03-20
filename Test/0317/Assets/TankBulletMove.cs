using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletMove : MonoBehaviour
{
    public float BulletAcc = 30.0f;
    public bool BulletFire = false;
    public float BulletLeft = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Q)&& BulletFire == false)
        {
            transform.Translate(transform.forward * BulletAcc * Time.deltaTime, Space.World);
            BulletFire = true;
        }
        else if ( BulletFire == true && BulletLeft <= 10)
        {
            transform.Translate(transform.forward * BulletAcc * Time.deltaTime, Space.World);
            BulletLeft += Time.deltaTime;
        }
        else if (BulletLeft >= 10)
        {
            BulletFire = false;
            Destroy(gameObject);
        }

    }
}
