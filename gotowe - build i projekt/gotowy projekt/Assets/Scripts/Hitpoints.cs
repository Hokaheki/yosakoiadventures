using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hitpoints : MonoBehaviour {

    public Transform HPBar;
    public Slider HPFill;
    Animator creatureanimator;
    public bool isDeadChecker=false;
    float timeLeft = 3f;
    private CheckpointSystem cps;
    Transform SpawnPoint;


    public float currentHP;
    public float maxHP;

    public float HPBarYOffset = 2;




    void Start()
    {
        creatureanimator = this.GetComponent<Animator>();
        SpawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>();

        if (gameObject.tag == "Player")
        {
            cps = GameObject.FindGameObjectWithTag("CPS").GetComponent<CheckpointSystem>();
            /*transform.position = cps.LastCheckpointPos;*/
            transform.position = SpawnPoint.position;
        }
    }


    void Update()
    {

        PositionHPBar();
        HPinfo();

        if (isDeadChecker == true)
        {
            CountdownResurrection();
        }

        if(Input.GetKeyDown(KeyCode.R) && gameObject.tag == "Player")
        {
            transform.position = cps.LastCheckpointPos;
        }
       
    }


    void CountdownResurrection()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0 && gameObject.tag == "Player")
        {
            currentHP = 100f;
            HPFill.value = 1;
            transform.position = cps.LastCheckpointPos;

            isDeadChecker = false;
            timeLeft = 3f;
            creatureanimator.SetBool("isDead", false);
            creatureanimator.SetBool("isAlive", true);

        }
        else if (timeLeft <= 0 && gameObject.tag == "Enemy")
        {
            timeLeft = 3f;
            Destroy(gameObject);
            creatureanimator.SetBool("isDead", false);
        }
    }

    public void ChangeHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        HPFill.value = currentHP / maxHP;
    }

    private void PositionHPBar()
    {
        Vector3 currentPos = transform.position;

        HPBar.LookAt(Camera.main.transform);
    }

    void HPinfo()
    {
        if (currentHP <= 0 && gameObject.tag == "Enemy")
        {
            creatureanimator.SetBool("isChasing", false);
            creatureanimator.SetBool("isEnemyAttacking", false);
            creatureanimator.SetBool("isDead", true);
            isDeadChecker = true;
        }
        else if (currentHP <= 0 && gameObject.tag == "Player")
        {
            creatureanimator.SetBool("isPlayerrunning", false);
            creatureanimator.SetBool("isPlayerAttacking", false);
            creatureanimator.SetBool("isDead", true);
            isDeadChecker = true;
        }
    }
}