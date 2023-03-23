using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenseEarth : MonoBehaviour
{
    public static DeffenseEarth Instance = null;
    public Transform myEarth =null;
    public LayerMask enemyMask;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(Spawning());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, enemyMask))
            {
                //if (hit.transform.gameObject.layer == LayerMask.NameToLayer("ground"))
                if (((1 << transform.gameObject.layer) & enemyMask) == 0)
                {
                    Destroy(hit.transform.gameObject);
                }

            }
        }

    }



    IEnumerator Spawning()
    {
        while (myEarth != null)
        {
            Vector3 pos = Vector3.zero;


            /*
            while (Mathf.Approximately(pos.magnitude,0.0f))
            {
                pos.x = Random.Range(-1.0f, 1.0f);
                pos.y = Random.Range(-1.0f, 1.0f);
            }
            Vector3 rndDir = (pos - myEarth.position).normalized;
            */

            Vector3 rndDir = new Vector3(0, 1, 0);
            float angle = Random.Range(0.0f, 360.0f);
            rndDir = Quaternion.Euler(0,0, angle)* rndDir;

            float rndDist = Random.Range(7, 10);
            pos = myEarth.position + rndDir * rndDist;

            GameObject obj = Instantiate(Resources.Load("DefensesEarth/Meteor"),pos, Quaternion.identity) as GameObject;


            yield return new WaitForSeconds(1.0f);
        }


    }

}
