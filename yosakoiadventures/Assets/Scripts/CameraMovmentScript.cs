using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovmentScript : MonoBehaviour {

    [SerializeField] GameObject target;
    public float smoothTime = 0.3F;

    public float distance;
    Vector3 startPosition;

    Transform player;
    Rigidbody rig;

    Vector3 velocity;

    private void Start()
    {
        player = target.transform;
        rig = target.GetComponent<Rigidbody>();
        velocity = rig.velocity;

        startPosition = player.position + new Vector3(0, 1, distance);
        transform.position = startPosition;
        startPosition = new Vector3(0, 1, distance);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + startPosition, ref velocity, smoothTime);
    }

}
