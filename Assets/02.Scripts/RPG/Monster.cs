using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Monster : CharacterMovement,IPerception,IBattle
{
    public enum State
    {
        Create,Normal,Battle,Death
    }
    public static int TotalCount = 0;
    public State myState = State.Create;
    Vector3 orgPos;

    public Transform myTarget = null;
    public bool IsLive
    {
        get => myState != State.Death;
    }
    public float DeathCount = 0.0f;
    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case State.Normal:
                myAnim.SetBool("IsMoving", false);
                StopAllCoroutines();
                StartCoroutine(Roaming(Random.Range(1.0f, 3.0f)));
                break;
            case State.Battle:
                StopAllCoroutines();
                FollowTarget(myTarget);
                break;
            case State.Death:
                Collider[] list = transform.GetComponentsInChildren<Collider>();
                foreach (Collider col in list) col.enabled = false;
                DeathAlarm?.Invoke();
                StopAllCoroutines();
                DeathCount = 0.0f;
                StartCoroutine(DeadDisappear());
                myAnim.SetTrigger("Dead");
                myAnim.SetBool("isDead", true);
                break;
            default:
                Debug.Log("처리 되지 않는 상태 입니다.");
                break;
        }
    }
    public void OnDisappear()
    {
        StartCoroutine(DeadDisappear());
    }
    void StateProcess()
    {
        switch (myState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                Debug.Log("처리 되지 않는 상태 입니다.");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        orgPos = transform.position;
        ChangeState(State.Normal);
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }
    IEnumerator Roaming(float delay)
    {
        yield return new WaitForSeconds(delay);
        Vector3 pos = orgPos;
        pos.x += Random.Range(-5.0f, 5.0f);
        pos.z += Random.Range(-5.0f, 5.0f);
        MoveToPos(pos, ()=> StartCoroutine(Roaming(Random.Range(1.0f,3.0f))));
    }
    IEnumerator DeadDisappear()
    {
        yield return new WaitForSeconds(3.0f);
        while (DeathCount < 3.0f)
        {
            DeathCount += Time.deltaTime;
            transform.Translate(Vector3.down * DeathCount * FallSpeed, Space.World);
            if (DeathCount >= 3.0f)
            {
                Destroy(gameObject);
                TotalCount--;
                yield break;
            }
            yield return null;
        }
    }

    public void Find(Transform target)
    {
        myTarget = target;
        myTarget.GetComponent<CharacterProperty>().DeathAlarm += () => { if (IsLive) ChangeState(State.Normal); };
        ChangeState(State.Battle);
    }

    public void LostTarget()
    {
        myTarget = null;
        ChangeState(State.Normal);
    }

    public void OnAttack()
    {
        myTarget.GetComponent<IBattle>()?.OnDamage(AttackPoint);
    }

    public void OnDamage(float dmg)
    {
        curHp -= dmg;
        if (Mathf.Approximately(curHp,0.0f))
        {
            ChangeState(State.Death);
        }
        else
        {
            myAnim.SetTrigger("getDamage");
        }
    }

}
