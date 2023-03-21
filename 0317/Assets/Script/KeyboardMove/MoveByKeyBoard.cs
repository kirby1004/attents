using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyBoard : MonoBehaviour
{
    public float acceleratiorRotate = 1.0f;
    public float AccelerationGo = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && AccelerationGo <= 40)
        {
            transform.Translate(transform.forward * AccelerationGo * Time.deltaTime, Space.World);
            AccelerationGo += 0.1f;
        }
        else if (Input.GetKey(KeyCode.W) && AccelerationGo >= 40)
        {
            transform.Translate(transform.forward * AccelerationGo * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.W) == true)
        {
            AccelerationGo = 1;
        }

        if (Input.GetKey(KeyCode.S)&& AccelerationGo <=40)
        {
            transform.Translate(-transform.forward *AccelerationGo* Time.deltaTime,Space.World);
            AccelerationGo += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S) && AccelerationGo >=40)
        {
            transform.Translate(transform.forward * AccelerationGo * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.S) == true)
        {
            AccelerationGo = 1;
        }


        if (Input.GetKey(KeyCode.A) && acceleratiorRotate <= 360)
        {
            transform.Rotate(-transform.up *acceleratiorRotate* Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.A) && acceleratiorRotate >= 360)
        {
            transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.A) == true)
        {
            acceleratiorRotate = 1;
        }

        if (Input.GetKey(KeyCode.D) && acceleratiorRotate <= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.D) && acceleratiorRotate >= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.D) == true)
        {
            acceleratiorRotate = 5;
        }





    }
}
