using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ���� �ֱ�
    public float rotatePeriod;
    

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(transform.up * (360.0f/rotatePeriod) * Time.deltaTime);
        
    }
}
