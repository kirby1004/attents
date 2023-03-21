using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Wheel_move : MonoBehaviour
{

    public float acceleratiorRotate = 15.0f;
    public float acceleratiorRotateWheel = 5.0f;
    public int wheel_Rotate = 3;
    public float WheelMax = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && acceleratiorRotate <= 360)
        {
            transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.W) && acceleratiorRotate >= 360)
        {
            transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.W) == true)
        {
            acceleratiorRotate = 5.0f;
        }

        if (Input.GetKey(KeyCode.S) && acceleratiorRotate <= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.S) && acceleratiorRotate >= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.S) == true)
        {
            acceleratiorRotate = 5.0f;
        }




        //if (Input.GetKey(KeyCode.A) && WheelMax +Time.deltaTime<= 3)
        //{
        //    transform.Rotate(-transform.forward * acceleratiorRotateWheel * Time.deltaTime, Space.World);
        //    WheelMax += Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.A) && WheelMax +Time.deltaTime >= 3)
        //{

        //}
        //else if (Input.GetKeyUp(KeyCode.A) == true)
        //{
        //    transform.Rotate(transform.forward * acceleratiorRotateWheel , Space.World);
        //    WheelMax = 0.0f;
        //}

        //if (Input.GetKey(KeyCode.D) && WheelMax + Time.deltaTime <= 3)
        //{
        //    transform.Rotate(transform.forward * acceleratiorRotateWheel * Time.deltaTime, Space.World);
        //    WheelMax += Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.A) && WheelMax + Time.deltaTime >= 3)
        //{

        //}
        //else if (Input.GetKeyUp(KeyCode.D) == true)
        //{
        //    transform.Rotate(-transform.forward * acceleratiorRotateWheel, Space.World);
        //    WheelMax = 0.0f;
        //}



    }
}
