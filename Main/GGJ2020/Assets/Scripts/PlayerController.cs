using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool facingRight = true;
    public LayerMask platformLayer;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float jumpForce;


    [SerializeField]
    private CameraMovement cam;

    [SerializeField]
    private float cameraBoundsMargin;


    [SerializeField]
    private int numberOfRays = 2;


    [SerializeField]
    private float rayLength = 0.1f;


    public float input;


    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private Collider2D collider;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        // animator = GetComponent<Animator>();
    }

    void Update()
    {



        float horizontalInput = Input.GetAxis("Horizontal");
        var mov = new Vector3(horizontalInput * speed, rigidbody2D.velocity.y, 0f);
     
        input = horizontalInput;

        rigidbody2D.velocity = mov;


        if (horizontalInput < 0 && facingRight || horizontalInput > 0 && !facingRight)        
            Flip();
        

        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsStandingOnGround())
        {   
            // Resetting vertical speed to 0 since the player might hit jump when the character is falling down right before hitting the ground
            // in that case the gravity force might overpower the jump force, and the result is that it "feels" like the jump button didn't work
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
            rigidbody2D.AddForce(Vector2.up * jumpForce);
        }

        SwitchAnimation(horizontalInput);
    }







    private void SwitchAnimation(float horizontalMov)
    {
        //if (horizontalMov == 0)
        //{
        //    animator.Play("char_idle");
        //}
        //else
        //{
        //    animator.Play("char_move");
        //}
    }

    // This method shoots down rays, starting from the left side of the boxCollider. The number is adjustable:
    // if the game has only platforms that are wider than the player, 2 is enough. 
    private bool IsStandingOnGround()
    {
        Bounds boxBounds = collider.bounds;
        Vector2 rayOrigin = new Vector2(boxBounds.center.x - boxBounds.extents.x, boxBounds.center.y - boxBounds.extents.y);

        bool atLeastOneRayHittingGround = false;

        for (int i = 0; i < numberOfRays; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, platformLayer);
         //   Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.red);

            if (hit)
            {
                atLeastOneRayHittingGround = true;
            }
            float nextRaySpacing = (boxBounds.extents.x * 2.0f) / (numberOfRays - 1f);
            rayOrigin += Vector2.right * nextRaySpacing;
        }

        return atLeastOneRayHittingGround;
    }



    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1f, 1f, 1f);
    }
    
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("fire"))
            print("dead");

    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if(hitInfo.collider.CompareTag("collectable")){
          print("collect");
          hitInfo.collider.GetComponent<Collectable>().onPickUp();
          
        }
    }



}
