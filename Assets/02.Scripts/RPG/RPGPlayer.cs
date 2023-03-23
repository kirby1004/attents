using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGPlayer : CharacterMovement
{
    //public MousePicking myPick = null;
    // Start is called before the first frame update
    void Start()
    {
        //myPick.clickAtcion = OnMove;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void OnMove(Vector3 pos)
    {
        MoveToPos(pos);
    }

}
