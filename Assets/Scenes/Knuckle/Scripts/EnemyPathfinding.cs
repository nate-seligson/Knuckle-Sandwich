using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform player;
    public Animator animator;
    bool attackPosition = false;
    float PlayerRange = 10;
    float AttackRange = 2;
    float zPunchDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = Move();
        attackPosition = CheckForAttackPosition();
        if (attackPosition)
        {
            GetComponent<Enemy>().attack();
        }
        float dir = (transform.position.x - player.transform.position.x);
        if(dir < 0 && transform.localScale.x < 0)
        {
            //take abs -- make positive
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        }
        else if (dir > 0 && transform.localScale.x > 0)
        {
            //make negative
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }
    }
    Vector3 Move()
    {
        if (!GetComponent<Enemy>().stunned && !attackPosition && !OutOfRange())
        {
            if (!animator.GetBool("walking"))
            {
                animator.SetBool("walking", true);
            }
            return player.position;
        }
        else
        {
            if (animator.GetBool("walking"))
            {
                animator.SetBool("walking", false);
            }
            return transform.position;
        }
    }
    bool CheckForAttackPosition()
    {
        return (Mathf.Abs(player.position.z - transform.position.z) <= zPunchDistance) && Vector3.Distance(player.position, transform.position) <= AttackRange;
    }
    bool OutOfRange()
    {
        return Vector3.Distance(player.position, transform.position) >= PlayerRange;
    }
}
