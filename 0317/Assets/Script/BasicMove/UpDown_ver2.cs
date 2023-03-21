using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown_ver2 : MonoBehaviour
{
    public bool PointCheck = false;
    public float TopCheck = 2.5f;
    public float BottomCheck = 0.0f;

    public double k = 0;
    bool PositionUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirY = new Vector3(0, 1, 0);

        k += Time.deltaTime;
        if (PositionUp == true && transform.position.y >= 2.5)
        {
            PositionUp = false;
            transform.position = new Vector3(0.0f, 2.5f, 0.0f);
        }
        else if (PositionUp == false && transform.position.y <= 0)
        {
            PositionUp = true;
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
        if (PositionUp == true)
        {
            transform.Translate(dirY * Time.deltaTime);
        }
        else if (PositionUp == false)
        {
            transform.Translate(-dirY * Time.deltaTime);
        }


    }
}
