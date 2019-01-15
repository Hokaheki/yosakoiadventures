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
    Animator playeranimator;
    float jumpTimeCounter;
    bool isJumping;


    //  !jumping

    [SerializeField] float speed;


    private void Start()
    {
        temporaryHalfHeightOfModel = transform.localScale.y / 2f + 0.001f;
        rig = GetComponent<Rigidbody>();
        playeranimator = this.GetComponent<Animator>();
        playeranimator.SetBool("isAlive", false);
    }

    private void FixedUpdate()
    {
        HorizontalMove();
        
    }
    private void Update()
    {
        Jump();
        Attack();
    }


    void HorizontalMove()
    {
        Hitpoints MyHP;
        MyHP = this.GetComponent<Hitpoints>();

        
        if (Input.GetAxis("Horizontal") !=0 && MyHP.isDeadChecker == false) //isDeadChecker sluzy do uniemożliwienia postaci wykonującej animacje smierci 
        {
            if (Input.GetAxis("Vertical") == 0 && DoTheRayCast())
            {
                playeranimator.SetBool("isPlayerrunning", true);
                playeranimator.SetBool("isJumping", false);
            }
            else
            {
                playeranimator.SetBool("isPlayerrunning", false);
            }
            velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, rig.velocity.y, 0);
            rig.velocity = velocity;
        }
        else
        {
            playeranimator.SetBool("isPlayerrunning", false);
        }

        if (Input.GetKey("d") && MyHP.isDeadChecker == false) //obracanie
        {
            if (transform.rotation != Quaternion.Euler(0, 90, 0))
                transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey("a") && MyHP.isDeadChecker == false) //obracanie
        {
           if (transform.rotation != Quaternion.Euler(0, 270, 0))
               transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    void Attack()
    {
        Hitpoints MyHP;
        MyHP = this.GetComponent<Hitpoints>();

        if (Input.GetKeyDown("space") && MyHP.isDeadChecker == false)
        {
            playeranimator.SetBool("isPlayerAttacking", true);
        }
        else
        {
            playeranimator.SetBool("isPlayerAttacking", false);
        }

    }

    void Jump()
    {
        Hitpoints MyHP;
        MyHP = this.GetComponent<Hitpoints>();

           if (Input.GetAxis("Vertical") > 0 && DoTheRayCast())
           {
               isJumping = true;
               jumpTimeCounter = jumpTime;
               velocity = new Vector3(velocity.x, jumpForce, 0);
               rig.velocity = velocity;         
           }
           if((Input.GetAxis("Vertical") > 0 && isJumping && MyHP.isDeadChecker == false))
           {
               if (jumpTimeCounter > 0)
               {
                    rig.velocity = velocity;
                    jumpTimeCounter -= Time.deltaTime;

                   velocity = new Vector3(velocity.x, jumpForce, 0);
                   playeranimator.SetBool("isJumping", true);
            }
               else
               {
                   isJumping = false;
                   playeranimator.SetBool("isJumping", false);
            }
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
