using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherProperty : MonoBehaviour
{
    Animator _ArcherAnim = null;
    public float ArcherSpeed = 3.0f;
    public float ArcherRotate = 360.0f;

    protected Animator myArcher
    {
        get
        {
            if(_ArcherAnim == null)
            {
                _ArcherAnim = GetComponent<Animator>();
                if(_ArcherAnim == null)
                {
                    _ArcherAnim = GetComponentInChildren<Animator>();
                }

            }
            return _ArcherAnim;
        }
    }

}
