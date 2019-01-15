using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public float view;
    public float attackrange;
    public float speed;
    public Animator enemyanimator;
    /*public GameObject player;
    public GameObject enemy;*/
    Transform target;
    public Transform[] PatrolPoints;
    Transform CurrentPoint;
    
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyanimator = this.GetComponent<Animator>();
    }


    void Update()
    {
         Chasing();
    }

  
    void Chasing()
    {
        Hitpoints HP;
        Hitpoints MyHP;
        HP = GameObject.FindGameObjectWithTag("Player").GetComponent<Hitpoints>();
        MyHP = this.GetComponent<Hitpoints>();

        if (Vector2.Distance(transform.position, target.position) < view && Vector2.Distance(transform.position, target.position) > attackrange && HP.isDeadChecker == false 
            && MyHP.isDeadChecker == false && target.position.y - this.transform.position.y < 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            this.transform.LookAt(targetPosition);
            enemyanimator.SetBool("isChasing", true);
            enemyanimator.SetBool("isEnemyAttacking", false);

        }
        else if (Vector2.Distance(transform.position, target.position) <= attackrange && HP.isDeadChecker == false && MyHP.isDeadChecker == false)
        {
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", true);
        }
        else if(Vector2.Distance(transform.position, target.position) > attackrange && Vector2.Distance(transform.position, target.position) > view && HP.isDeadChecker == false && MyHP.isDeadChecker == false)
        {
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", false);
        }
        else if(HP.isDeadChecker == true)
        {
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", false);
        }
        else if (MyHP.isDeadChecker == true)
        {
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", false);
        }
        else if (target.position.y - this.transform.position.y > 0.2)
        {
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", false);
        }

    }

}