using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

    public Animator playeranimator;

    void OnTriggerEnter(Collider other)
    {
        Hitpoints HP;

        if (HP = other.GetComponent<Hitpoints>())
        {
            if (other.gameObject.tag == "Enemy" && this.playeranimator.GetCurrentAnimatorStateInfo(0).IsName("NarukoAttack"))
            {
                 HP.ChangeHP(-50);
            }
        }

    }
}
