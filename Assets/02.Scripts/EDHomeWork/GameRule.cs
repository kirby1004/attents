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
    public StarSpawner spawner;

    public Transform starspawn = null;
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

    public float circleR; //반지름
    public float deg; //각도
    public float objSpeed; //원운동 속도
    IEnumerator StarSpawn()
    {
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            var rad = Mathf.Deg2Rad * (deg);
            var x = circleR * Mathf.Sin(rad);
            var y = circleR * Mathf.Cos(rad);
            mystar1.transform.position = transform.position + new Vector3(x, y);
            mystar1.transform.rotation = Quaternion.Euler(0, 0, deg * -1); //가운데를 바라보게 각도 조절
        }
        else
        {
            deg = 0;
        }
        mystar1.OnFire();
        mystar1 = null;
        GameObject obj = Instantiate(orgStar, starspawn);
        mystar1 = obj.GetComponent<Stars>();
        StartCoroutine(playFireEffect());
        yield return new WaitForSeconds(3.0f);
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
