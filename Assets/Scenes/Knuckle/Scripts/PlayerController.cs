using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float speed = 4;
    float jumpForce = 200;
    Rigidbody rb;
    PunchControls pc;
    bool ground;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //used to get if player is punching, stops movement
        pc = GetComponent<PunchControls>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            Jump();
        }
        if ((Input.GetAxis("Horizontal") < 0 && transform.localScale.x > 0) || (Input.GetAxis("Horizontal") > 0 && transform.localScale.x < 0))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            GetComponent<BoxCollider>().size = Vector3.Scale(GetComponent<BoxCollider>().size, new Vector3(-1, 1, 1));
        }
        if (pc.stunned)
        {
            StartCoroutine("unstun");
        }
        if(pc.health <= 0)
        {
            Money.changeMoney(-500);
            EnemySpawn.guys = 0;
            SceneManager.LoadScene("House");
        }
        if((Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1f || Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1f) && Walkable())
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }


    }
    bool Walkable()
    {
        if (!pc.punching && !pc.stunned)
        {
            return true;
        }
        return false;
    }
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //disallow movement if punching
        if (Walkable())
        {
            rb.MovePosition(transform.position + input * Time.deltaTime * speed);
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce);
        ground = false;
    }
    void OnCollisionEnter(Collision col)
    {
        ground = true;
    }
    IEnumerator unstun()
    {
        yield return new WaitForSeconds(1);
        pc.stunned = false;
        StopCoroutine("unstun");
    }
}
