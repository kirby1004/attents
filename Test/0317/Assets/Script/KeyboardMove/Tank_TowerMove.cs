using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_TowerMove : MonoBehaviour
{

    public float acceleratiorRotateUp = 60.0f;
    public float acceleratiorRotate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && acceleratiorRotate <= 360)
        {
            transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && acceleratiorRotate >= 360)
        {
            transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
        {
            acceleratiorRotate = 5.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow) && acceleratiorRotate <= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
            acceleratiorRotate += 5.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && acceleratiorRotate >= 360)
        {
            transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) == true)
        {
            acceleratiorRotate = 5.0f;
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(-transform.right * acceleratiorRotateUp * Time.deltaTime, Space.World);

        }
        //else if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Rotate(-transform.right * acceleratiorRotateUp * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKeyUp(KeyCode.UpArrow) == true)
        //{
        //    acceleratiorRotateUp = 1;
        //}

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(transform.right * acceleratiorRotateUp * Time.deltaTime, Space.World);
        }
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Rotate(transform.right * acceleratiorRotateUp * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKeyUp(KeyCode.DownArrow) == true)
        //{
        //    acceleratiorRotateUp = 1;
        //}



    }
}
