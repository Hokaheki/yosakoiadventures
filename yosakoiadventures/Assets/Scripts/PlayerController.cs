using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Optymalizacja

    float temporaryHalfHeightOfModel;
    Vector3 velocity;
    Rigidbody rig;

    #endregion

    //  jumping

    [SerializeField] float jumpForce;
    [SerializeField] float jumpTime;
    public GameObject player;
    public Animator playeranimator;
    float jumpTimeCounter;
    bool isJumping;
    

    //  !jumping

    [SerializeField] float speed;


    private void Start()
    {
        temporaryHalfHeightOfModel = transform.localScale.y / 2f + 0.001f;
        rig = GetComponent<Rigidbody>();
        playeranimator = player.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }
    private void Update()
    {
        Jump();
        
    }

    void HorizontalMove()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, rig.velocity.y, 0);
        rig.velocity = velocity;
        if (Input.GetAxis("Horizontal") !=0)
        {
            playeranimator.SetBool("isPlayerrunning", true);
        }
        else
        {
            playeranimator.SetBool("isPlayerrunning", false);
        }

        if (Input.GetKey("d"))
        {
            if (transform.rotation != Quaternion.Euler(0, 90, 0))
                transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey("a"))
        {
           if (transform.rotation != Quaternion.Euler(0, 270, 0))
               transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    void Jump()
    {
        if(Input.GetAxis("Vertical") > 0 && DoTheRayCast())
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            velocity = new Vector3(velocity.x, jumpForce, 0);
            rig.velocity = velocity;         
        }
        if(Input.GetAxis("Vertical") > 0 && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                velocity = new Vector3(velocity.x, jumpForce, 0);
                rig.velocity = velocity;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
                isJumping = false;
        }

    }

    bool DoTheRayCast()
    {
        RaycastHit info;
        Physics.Raycast(transform.position, Vector3.down, out info, temporaryHalfHeightOfModel);
        if(info.collider != null)
            return info.collider.CompareTag("Floor");
        return false;
    }

}
