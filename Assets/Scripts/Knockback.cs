using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<pot>().smash();
            }
        
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 diff = hit.transform.position - transform.position;
                diff = diff.normalized * thrust;
                hit.AddForce(diff, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("Enemy"))
                {
                    hit.GetComponent<enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<enemy>().knock(hit, knockTime);
                }
                if (collision.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().knock(knockTime);
                }
                
            }
        }
    }

}
