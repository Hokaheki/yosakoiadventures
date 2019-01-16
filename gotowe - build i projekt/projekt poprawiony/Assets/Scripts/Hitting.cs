using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour {


    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        Hitpoints HP;

        if (HP = other.GetComponent<Hitpoints>())
        {
            if (other.gameObject.tag == "Enemy")
            {
                HP.ChangeHP(-30);
                Debug.Log("enemy lost HP");
            }
        }
        else if (HP = other.GetComponent<Hitpoints>())
        {
            if (other.gameObject.tag == "Player")
            {
                HP.ChangeHP(-10);
                Debug.Log("player lost HP");
            }
        }

    }

}
