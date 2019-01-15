using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private CheckpointSystem cps;

    void Start()
    {
        cps = GameObject.FindGameObjectWithTag("CPS").GetComponent<CheckpointSystem>();
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            cps.LastCheckpointPos = transform.position;
        }
    }
}
