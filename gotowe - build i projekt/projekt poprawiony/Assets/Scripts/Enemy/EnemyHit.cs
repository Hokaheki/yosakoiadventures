using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour {

    public Animator enemyanimator;


    void OnTriggerEnter(Collider other)
    {
        Hitpoints HP;

        if (HP = other.GetComponent<Hitpoints>())
        {
            if (other.gameObject.tag == "Player" && this.enemyanimator.GetCurrentAnimatorStateInfo(0).IsName("NarukoAttack"))
            {
                HP.ChangeHP(-5);
            }
        }

    }
}
