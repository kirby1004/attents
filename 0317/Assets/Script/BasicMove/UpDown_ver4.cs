using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown_ver4 : MonoBehaviour
{

    Vector3 dirY = new Vector3(0, 1, 0);
    float dist = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime;
        if (dist - delta <= 0.0f)
        {
            delta = dist;
            dist = 2.5f;
            dirY = -dirY;
        }
        dist -= delta;

        transform.Rotate(dirY * delta, Space.Self);
    }
}
