using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyBoard_ver2 : MonoBehaviour
{
    public float acceleratiorRotate = 1.0f;
    public float accelerationRight = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && accelerationRight <= 180)
        {
            transform.Rotate(-transform.right * accelerationRight * Time.deltaTime, Space.World);
            accelerationRight += 5.0f;
        }
        else if (Input.GetKey(KeyCode.Q) && accelerationRight >= 180)
        {
            transform.Rotate(-transform.right * accelerationRight * Time.deltaTime, Space.World);
            
        }
        else if (Input.GetKeyUp(KeyCode.Q) == true)
        {
            accelerationRight = 1;
        }

        if (Input.GetKey(KeyCode.E) && accelerationRight <= 180)
        {
            transform.Rotate(transform.right * accelerationRight * Time.deltaTime, Space.World);
            accelerationRight += 5.0f;
        }
        else if (Input.GetKey(KeyCode.E) && accelerationRight >= 180)
        {
            transform.Rotate(transform.right * accelerationRight * Time.deltaTime, Space.World);
           
        }
        else if (Input.GetKeyUp(KeyCode.E) == true)
        {
            accelerationRight = 1;
        }


        //if (Input.GetKey(KeyCode.A) && acceleratiorRotate <= 360)
        //{
        //    transform.Rotate(-transform.up *acceleratiorRotate* Time.deltaTime, Space.World);
        //    acceleratiorRotate += 5.0f;
        //}
        //else if (Input.GetKey(KeyCode.A) && acceleratiorRotate >= 360)
        //{
        //    transform.Rotate(-transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKeyUp(KeyCode.A) == true)
        //{
        //    acceleratiorRotate = 1;
        //}

        //if (Input.GetKey(KeyCode.D) && acceleratiorRotate <= 360)
        //{
        //    transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        //    acceleratiorRotate += 5.0f;
        //}
        //else if (Input.GetKey(KeyCode.D) && acceleratiorRotate >= 360)
        //{
        //    transform.Rotate(transform.up * acceleratiorRotate * Time.deltaTime, Space.World);
        //}
        //else if (Input.GetKeyUp(KeyCode.D) == true)
        //{
        //    acceleratiorRotate = 5;
        //}





    }
}
