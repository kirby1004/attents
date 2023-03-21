using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    public double k = 0;
    bool PositionUp = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirX = new Vector3(1, 0, 0);
        Vector3 dirY = new Vector3(0, 1, 0);
        Vector3 dirZ = new Vector3(0, 0, 1);

        k += Time.deltaTime;
        if(PositionUp == true && transform.position.y >= 2.5)
        {
            PositionUp = false;
            transform.position.Set(0, 2.5f, 0);
        }
        else if ( PositionUp == false && transform.position.y <=0)
        {
            PositionUp = true;
            transform.position.Set(0, 0, 0);
        }
        if ( PositionUp ==true)
        {
            transform.Translate(dirY * Time.deltaTime);
        }
        else if (PositionUp == false)
        {
            transform.Translate(-dirY * Time.deltaTime);
        }



    }
}
