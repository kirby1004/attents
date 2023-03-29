using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MobSpwaner : MonoBehaviour
{
    public GameObject orgObject;
    public int Totalcount = 3;
    public float Width = 5.0f;
    public float Height = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0;i < Totalcount; ++i)
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-Width * 0.5f, Width * 0.5f);
            pos.z += Random.Range(-Height * 0.5f, Height * 0.5f);
            Instantiate(orgObject, pos, Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReSpawn()
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-Width * 0.5f, Width * 0.5f);
        pos.z += Random.Range(-Height * 0.5f, Height * 0.5f);
        Instantiate(orgObject, pos, Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
    }

    IEnumerator ReSpawnning()
    {
        yield return null;
    }                                                                                                                                                                                                                                                                                                                                                                                                        

}
