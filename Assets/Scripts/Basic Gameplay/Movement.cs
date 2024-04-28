using UnityEngine;

public class Movement : MonoBehaviour
{

    public FollowMouse RotationForFlip;

    int playerSpeed = 10;
    bool facingRight = false;
    public float moveX;
    int jumpCounter = 0;
    int playerJumpPower = 500;

    public GameObject arm;
    public Animator animator;
    public ArmMovement armMovement;

    //for anxiety
    public bool isAnxious = false;

    //sounds
    public AudioSource jumpSound;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
   
        //Controls
        if (isAnxious == false)
        {
            moveX = Input.GetAxis("Horizontal");
            //plays animations
            animator.SetFloat("Speed", Mathf.Abs(moveX));
            armMovement.ArmRun();
        }
        else
        {
            moveX = Input.GetAxis("Horizontal") * -1;
            //plays animations
            animator.SetFloat("Speed", Mathf.Abs(moveX));
            armMovement.ArmRun();
        }
      
    if (Input.GetButtonDown("Jump") && jumpCounter == 1)
        {
            Jumpy();
            jumpCounter -= 1;
            //plays animations
            animator.SetBool("IsJumping", true);
            armMovement.ArmJump();
        }

        //Player Direction
        {
            // when mouse is past certain point, the player will flip
            if (Mathf.Abs(RotationForFlip.rotation) > 90 && facingRight == false)
            {
                FlipPlayer();
            }

            else if (Mathf.Abs(RotationForFlip.rotation) < 90 && facingRight == true)
            {
                FlipPlayer();
            }
        }
        //Physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    public void FlipPlayer()
    // This sets the direction that the player will face
    {
        facingRight = !facingRight;
        //rotates player and arm
        arm.transform.Rotate(180f, 0f, 0f);
        transform.Rotate(0f, 180f, 0f);
    }

    // only allows player to jump when on the ground
    public void OnCollisionEnter2D(Collision2D theCollision)
    { 
        if (theCollision.gameObject.tag == "Ground")
        {
            //plays animations
            animator.SetBool("IsJumping", false);
            armMovement.StopArmJump();

            // Find where player hits the platform
            Vector2 hit = theCollision.contacts[0].normal;
            float angle = Vector2.Angle(hit, Vector2.up);

            // If Player hits side of a platform and they are mid jump
            if (Mathf.Approximately(angle, 90) && jumpCounter == 0)
            {
                jumpCounter = 0; // Don't let them jump
            }
            // If player is on top of a platform
            else
            {
                jumpCounter = 1; // Let them jump
            }
        }
    }

    public void Jumpy()
    {
        // Jump
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        jumpSound.Play();
    }
}