using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiketrap : MonoBehaviour {

    public float speed = 1.0f;

    void Update()
    {
        /* transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * speed, 1.0f), transform.position.z);*/
      /*  transform.position = new Vector3(this.transform.position.x, PingPong(Time.time * speed, this.transform.position.y, this.transform.position.y + 1.0f), this.transform.position.z);*/
    }
    float PingPong(float t, float minLength, float maxLength)
    {
        return Mathf.PingPong(t, maxLength - minLength) + minLength;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Hitpoints>().ChangeHP(-100);
        }
    }
}