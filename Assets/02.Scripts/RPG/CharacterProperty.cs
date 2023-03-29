using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CharacterProperty : MonoBehaviour
{
    Animator _anim = null;
    public UnityAction DeathAlarm;

    public float moveSpeed = 2.0f ;
    public float RotSpeed = 360.0f;
    public float AttackRange = 1.0f;
    public float AttackDelay = 1.0f;
    protected float playTime = 0.0f;
    public float MaxHealthPoint = 100.0f;
    //protected float HealthPoint = 100.0f;
    float _curHp = -100.0f;
    public float AttackPoint = 35.0f;
    public float FallSpeed = 0.1f;

    protected float curHp
    {
        get
        {
            if (_curHp < 0.0f) _curHp = MaxHealthPoint;
            return _curHp;
        }
        set => _curHp = Mathf.Clamp(value, 0.0f, MaxHealthPoint);
    }

    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = GetComponent<Animator>();
                if(_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
            }
            return _anim;
        }
    }



}
