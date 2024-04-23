using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchControls : MonoBehaviour
{
    public Animator animator;
    public float knockbackAmt = 500f;
    public static float damage = 5;
    public bool punching, stunned;
    public float health = 100;
    public AudioSource punch, gethit, ko;
    public Transform punchPoint;
    float punchRange = 0.3f;


    int index = 0;
    string animName = "Punch";
    Collider[] colliders;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !stunned)
        {
            //set animation state
            animator.SetTrigger("punch");
            punching = true;
        }
        if(State().IsTag("punch") || State().IsTag("KO"))
        {
            HandlePunchDamage();
            punching = true;
        }
        else if(punching)
        {
            Reset();
        }
    }
    AnimatorStateInfo State()
    {
        return animator.GetCurrentAnimatorStateInfo(0);
    }
    void Reset()
    {
        punching = false;
        index = 0;
        animName = "Punch";
    }
    int GetAllColliders()
    {
        return Physics.OverlapSphereNonAlloc(
                    punchPoint.position,
                    punchRange,
                    colliders
                    );
    }
    void Attack()
    {
        List<Collider> alreadyAttacked = new List<Collider>();
        colliders = new Collider[10];
        for (var i = 0; i < GetAllColliders(); i++)
        {
            Collider collider = colliders[i];
            GameObject obj = collider.transform.gameObject;
            if (obj.tag != "Enemy" || alreadyAttacked.Contains(collider))
            {
                continue;
            }
            else if (State().IsTag("KO"))
            {
                AddKnockback(obj);
            }
            RemoveHealth(obj);
            alreadyAttacked.Add(collider);
        }
    }
    void HandlePunchDamage()
    {
        if (State().IsName(animName))
        {
            switch (index)
            {
                case 0:
                    animName = "Punch 0";
                    index++;
                    break;
                case 1:
                    animName = "Punch 1";
                    index=0;
                    break;
            }
            Attack();
        }
    }
    public void GetHit()
    {
        gethit.Play();
        animator.SetTrigger("hit");
    }
    void AddKnockback(GameObject aggressed)
    {
        ko.Play();
        Rigidbody rb = aggressed.GetComponent<Rigidbody>();
        Vector3 direction = (aggressed.transform.position - transform.position).normalized;
        rb.AddForce(direction * knockbackAmt);
    }
    void RemoveHealth(GameObject aggressed)
    {
        punch.Play();
        Enemy data = aggressed.GetComponent<Enemy>();
        data.animator.SetTrigger("hurt");
        data.health -= damage;
        data.stun();
        if(data.health <= 0)
        {
            data.kill();
        }
    }
}
