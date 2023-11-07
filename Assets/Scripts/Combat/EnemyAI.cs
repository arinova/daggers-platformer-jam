using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    enum EnemyAIState
    {
        NOCHASE,
        IDLE,
        CHASE,
        ATTACK
    }

    public Enemy enemy;
    public bool damageOnCollision = false;
    public bool noChase = false;
    EnemyAIState aiState = EnemyAIState.IDLE;

    // Use this for initialization
    void Start()
    {
        if (noChase) aiState = EnemyAIState.NOCHASE;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.IsAlive())
        {
            RunAI();
        }
    }

    public virtual void RunAI()
    {
        switch (aiState)
        {
            case EnemyAIState.IDLE:
                break;
            case EnemyAIState.CHASE:
                RunChase();
                break;
            case EnemyAIState.ATTACK:
                RunAttack();
                break;
        }
    }

    public virtual void RunChase()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target)
        {
            enemy.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.transform.position, enemy.speed * Time.deltaTime);
        }
    }

    public virtual void RunAttack()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(damageOnCollision)
            collision.gameObject.GetComponent<PlayerHealth>().Damage(enemy.damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aiState = EnemyAIState.CHASE;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            aiState = EnemyAIState.IDLE;
        }
    }
}
