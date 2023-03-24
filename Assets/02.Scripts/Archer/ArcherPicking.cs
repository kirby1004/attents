using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void ClickAct(Vector3 pos);

public class ArcherPicking : MonoBehaviour
{
    public LayerMask PickMask;
    public LayerMask enemyMask;
    public LayerMask GroundMask;
    public UnityEvent<Vector3> ArcherClickAction = null;
    //public UnityEvent<Vector3> ArcherAttackAction = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 1000, PickMask))
            {
                if (((1 << transform.gameObject.layer) & GroundMask) == 0)
                {
                    ArcherClickAction?.Invoke(hit.point);
                }
            }
            //else if (Physics.Raycast(ray, out RaycastHit enemy, 1000, enemyMask))
            //{
            //    if (((1 << transform.gameObject.layer) & enemyMask) == 0)
            //    {
            //        ArcherAttackAction?.Invoke(hit.point);
            //    }
            //}

        }

    }
}