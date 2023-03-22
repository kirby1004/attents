using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //public Rigidbody myRigidbody = new Rigidbody();
    //private Vector3 startPosition { get; set; } 
    public float maxDistanceY = 2.5f;
    public float minDistanceY = -2.5f;
    private float curPosition;
    private float speed = 1.0f;
    private int dir = 1;

    private float dist = 2.5f; // �̵��� �Ÿ�

    private float delta = 2.5f;

    Vector3 pos;

    private void Awake()
    {
        //startPosition = this.transform.position;
        
    }

    private void Start()
    {
        //myRigidbody.AddForce(0, 500, 0);

        //curPosition = transform.position.y;

        pos = transform.position;
    }

    private void Update()
    {
        // �Ÿ��� ���� ���
        
        // ���� �����ӿ� �̵��ϴ� �Ÿ�
        float delta = Time.deltaTime * speed;

        // ���� �Ÿ��� delta���� ���� ��
        if(dist <= delta)
        {
            delta = dist;
            // �����Ÿ� �缳�� �� ���� ����
            dist = 2.5f;
            dir *= -1;
        }
        // ���� �Ÿ� ���
        dist -= delta;
        transform.Translate(dir * new Vector3(0,1,0) * delta, Space.Self);

        // ȸ��
        transform.Rotate(dir * new Vector3(0,1,0) * 360.0f * Time.deltaTime * speed);

        /*Vector3 vec = pos;
        vec.y += delta * Mathf.Sin(Time.time * speed);
        this.transform.position = vec;
        */

        //this.transform.Translate(dir * Time.deltaTime);

        /*float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        */
    }


}
