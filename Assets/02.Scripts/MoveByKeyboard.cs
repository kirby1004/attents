using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByKeyboard : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 360.0f;
    public Transform head;
    public Transform cannon;
    public Transform cannonPivot;
    public float cannonRotSpeed = 360.0f;
    public float cannonUpDownSpeed = 120.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(this.transform.forward * Time.deltaTime * moveSpeed, Space.World);
            //transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * moveSpeed);
            //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-this.transform.forward * Time.deltaTime * moveSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-transform.up * Time.deltaTime * rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up * Time.deltaTime * rotateSpeed);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            head.transform.Rotate(-transform.up * Time.deltaTime * cannonRotSpeed);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            head.transform.Rotate(transform.up * Time.deltaTime * cannonRotSpeed);
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            cannonPivot.transform.Rotate(-cannonUpDownSpeed * Time.deltaTime * transform.right);
            //cannon.transform.RotateAround(cannonPivot.position, -cannon.transform.right, Time.deltaTime * cannonUpDownSpeed);

            /*float x;
            x = cannonUpDownSpeed * Time.deltaTime;
            cannonUpDown.rotation = Quaternion.Euler(-x, 0, 0);*/
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            cannonPivot.transform.Rotate(cannonUpDownSpeed * Time.deltaTime * transform.right);

            //cannon.transform.RotateAround(cannonPivot.position, cannon.transform.right, Time.deltaTime * cannonUpDownSpeed);
         
            /*float x;
            x = cannonUpDownSpeed * Time.deltaTime;
            cannonUpDown.rotation = Quaternion.Euler(x, 0, 0);*/
        }
    }
}
