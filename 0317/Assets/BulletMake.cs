using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMake : MonoBehaviour
{
    public GameObject prefab;
    public int Bulletleft = 0;
    public bool bulletMakePossible = true;
    public Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && Bulletleft == 0 && bulletMakePossible == true)
        {
            Rigidbody p = Instantiate(Rigidbody, transform.position, transform.rotation);
           // Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            Bulletleft += 1;
            bulletMakePossible = false;
        }
        else if (Input.GetKeyUp(KeyCode.Q) == true)
        {
            bulletMakePossible = true;
            Bulletleft = 0;
        }
    }
}
