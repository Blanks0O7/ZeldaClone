using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : enemy
{
    private Rigidbody2D myRigidbody;

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;


    }


    
    void FixedUpdate()
    {
        checkDistance();
    }
    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius 
            && Vector3.Distance(target.position , transform.position)> attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                myRigidbody.MovePosition(temp);
                ChangeState(EnemyState.walk);
            }
        }
    }
    
    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
