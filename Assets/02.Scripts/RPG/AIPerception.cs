using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPerception : MonoBehaviour
{
    public LayerMask EnemyMask;
    public List<Transform> myEnemylist = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((EnemyMask & 1 << other.gameObject.layer) != 0)
        {
            myEnemylist.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (myEnemylist.Contains(other.transform))
        {
            if (myEnemylist.Contains(other.transform))
            {
                myEnemylist.Remove(other.transform);
            }

        }
    }
}
