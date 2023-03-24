using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherPlay : ArcherMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            myArcher.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myArcher.SetTrigger("Skill");
        }
    }

    public void ArcherOnMove(Vector3 pos)
    {
        ArcherMovingToPos(pos);
    }
    public void ArcherOnAttack(Vector3 pos)
    {

    }
}
