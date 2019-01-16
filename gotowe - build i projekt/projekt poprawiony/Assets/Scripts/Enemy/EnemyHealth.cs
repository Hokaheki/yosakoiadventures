using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public Transform HPBar;
    public Slider HPFill;
    public Animator creatureanimator;
    public GameObject creature;

    public float currentHP;
    public float maxHP;

    public float HPBarYOffset = 2;


    #region Monobehaviour API

    void Start()
    {
        creatureanimator = creature.GetComponent<Animator>();
    }


    void Update ()
    {
        PositionHPBar();
        HPinfo();
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

        HPBar.position = new Vector3(currentPos.z, currentPos.y + HPBarYOffset, currentPos.z);

        HPBar.LookAt(Camera.main.transform);
    }

    void HPinfo()
    {
        if (currentHP <=0)
        {
            /*Debug.Log("enemy is dead");
            enemyanimator.SetBool("isChasing", false);
            enemyanimator.SetBool("isEnemyAttacking", false);
            enemyanimator.SetBool("isDead", true);*/
            Destroy(gameObject);
        }
    }

    #endregion
}
