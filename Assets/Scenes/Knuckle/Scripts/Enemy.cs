using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float health = 50;
    public bool stunned, punching, OnCooldown;
    float knockback = 1000f;
    float damage = 5f;
    public Animator animator;
    void Start()
    {
        health = Stars.EnemyHealth(health);
        damage = Stars.EnemyDamage(damage);
    }
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punch"))
        {
            punching = true;
        }
        else
        {
            punching = false;
        }
        if (OnCooldown)
        {
            StartCoroutine("cooldown");
        }
    }
    public void kill()
    {
        Debug.Log(EnemySpawn.guys);
        Stars.KilledPerson();
        EnemySpawn.guys--;
        animator.SetTrigger("dead");
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(GetComponent<EnemyPathfinding>());
        Destroy(this);
    }
    public void stun()
    {
        stunned = true;
        StartCoroutine("unstun");
    }
    IEnumerator unstun()
    {
        yield return new WaitForSeconds(2);
        stunned = false;
    }
    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(5);
        OnCooldown = false;
        StopCoroutine("cooldown");
    }
    public void attack()
    {
        if (OnCooldown)
        {
            return;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            animator.SetTrigger("punch");
            punching = true;

        }
    }
    void OnTriggerStay(Collider col)
    {
        if(punching && col.transform.gameObject.tag == "Player" && !OnCooldown)
        {
            GameObject plyr = col.transform.gameObject;
            AffectPlayer(plyr);
            AddKnockback(plyr);
            OnCooldown = true;
        }
    }
    void AffectPlayer(GameObject plyr)
    {
        PunchControls punchControls = plyr.GetComponent<PunchControls>();
        punchControls.GetHit();
        punchControls.health -= damage;
        punchControls.stunned = true;
    }
    void AddKnockback(GameObject plyr)
    {
        Vector3 dir = (plyr.transform.position - transform.position).normalized;
        plyr.GetComponent<Rigidbody>().AddForce(dir * knockback);
    }
}
