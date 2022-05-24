using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public void knock(Rigidbody2D myRigidbody, float Knocktime)
    {
        StartCoroutine(KnockCo(myRigidbody, Knocktime));
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidbody,float knocktime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knocktime);
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.GetComponent<enemy>().currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
