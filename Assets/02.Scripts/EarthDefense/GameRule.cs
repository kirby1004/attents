using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour
{

    Coroutine GameStart;
    Coroutine SpawnStart;
    public LayerMask PickMask;
    public LayerMask enemyMask;
    public int LifeCount = 10;
    public Stars mystar1;
    public Stars mystar2;
    public Stars mystar3;
    public Stars mystar4;
    public Earth myEarth;
    public Transform myMuzzle = null;
    public GameObject orgStar =null;
    // Start is called before the first frame update
    void Start()
    {
        GameStart = StartCoroutine(GameRules());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnStart = StartCoroutine(StarSpawn());
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, PickMask))
            {
                if (((1 << hit.transform.gameObject.layer) & enemyMask) == 0)
                {

                }
            }
        }
    }

    IEnumerator GameRules()
    {

        while (LifeCount ==0)
        {


            yield return null;
        }
    }
    IEnumerator StarSpawn()
    {
        float RndX, RndY;
        RndX = Random.Range(-70.0f, 70.0f);
        RndY = Random.Range(40.0f, 140.0f);
        while ((RndX>=-30.0f&&RndX <=30.0f)&&(RndY>=75.0&& RndY >= 125.0f))
        {
            RndX = Random.Range(-70.0f, 70.0f);
            RndY = Random.Range(40.0f, 140.0f);
        }
        while (LifeCount >= 0)
        {

            GameObject obj = Instantiate(orgStar, myMuzzle);
            mystar1 = obj.GetComponent<Stars>();
            mystar1.transform.position = new Vector3(RndX, RndY, 100.0f);
            yield return new WaitForSeconds(1.4f);
        }
    }


    IEnumerator playFireEffect()
    {
        GameObject fireEffect;
        int rnd = Random.Range(1, 5);
        //switch (rnd)
        //{
        //    case 1:
        //}
        fireEffect = Instantiate(mystar1.fireEffect, mystar1.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1.4f);

        Destroy(fireEffect);
    }

}
