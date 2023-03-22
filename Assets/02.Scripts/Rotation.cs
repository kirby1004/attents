using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // 자전 주기
    public float rotatePeriod;
    

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.Rotate(transform.up * (360.0f/rotatePeriod) * Time.deltaTime);
        
    }
}
