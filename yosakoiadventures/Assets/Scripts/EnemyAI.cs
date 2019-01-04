using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float view;
    public float speed;
    public Animator enemyanimator;
    public GameObject player;
    public GameObject enemy;

    private Transform target;
    
	void Start ()
    {
        target = player.GetComponent<Transform>();
        enemyanimator = enemy.GetComponent<Animator>();
    }

    void Update()
    {
        Chasing();
    }

  
    void Chasing()
    {
        if (Vector2.Distance(transform.position, target.position) < view)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            /*transform.LookAt(Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime));*/
            Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            this.transform.LookAt(targetPosition);
            enemyanimator.SetBool("isChasing", true);
        }
        else
        {
            enemyanimator.SetBool("isChasing", false);
        }
    }
}
