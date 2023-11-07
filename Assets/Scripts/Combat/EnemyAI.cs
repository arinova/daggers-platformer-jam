using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public Enemy enemy;

    // Use this for initialization
    void Start()
    {

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
        //ChasePlayer();
    }

    public void ChasePlayer()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target)
        {
            enemy.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target.transform.position, enemy.speed * Time.deltaTime);
        }
    }
}
