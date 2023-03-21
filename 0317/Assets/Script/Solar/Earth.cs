using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    Vector3 dirY = new Vector3(0.0f, 1.0f, 0.0f);
    public float CycleWorld =1.0f ;
    public float CycleSelf = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaSelf = Time.deltaTime * 360.0f;
        float deltaWorld = Time.deltaTime * 360.0f;

        transform.Rotate(dirY * deltaSelf / CycleSelf, Space.Self);
        //transform.Rotate(dirY * deltaWorld / CycleWorld, Space.World);
        //transform.Rotate
    }
}
