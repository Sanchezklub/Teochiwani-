using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	private float movementInputDirection;
    private float jumpTimer;
    private float turnTimer;
    private float wallJumpTimer;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;

    private int amountOfJumpsLeft;
    private int facingDirection = 1;
    private int lastWallJumpDirection;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isRising;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isAttemptingToJump;
    private bool checkJumpMultiplier;
    private bool canMove;
    private bool canFlip;
    private bool hasWallJumped;
    private bool isTouchingLedge;
    private bool canClimbLedge = false;
    private bool ledgeDetected;
    private bool isDashing;
    private bool isWallHigher;
    private int ladderEnterCount = 0;

    public bool ladderMode;
    public bool ladderInRange;

    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private GameObject[] skeletonStuff;
    [SerializeField] private GameObject LadderSprite;

    public int amountOfJumps = 1;

    //public float movementSpeed = 10.0f;
    //public float jumpForce = 16.0f;
    public float fallingGravity = 1.5f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier = 0.95f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float wallHopForce;
    public float wallJumpForce;
    public float jumpTimerSet = 0.15f;
    public float turnTimerSet = 0.1f;
    public float wallJumpTimerSet = 0.5f;
    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    public float LadderSpeed;

    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;
    private Vector2 CollidedLadderPosition;

    public Transform groundCheck;
    public Transform wallCheck;
    public Transform ledgeCheck;
    public Transform higherWallCheck;
	public Transform flipAxis;
    public LayerMask whatIsGround;
    public LayerMask whatIsWall;

    // Start is called before the first frame update
	
	public float BasicSpeed;
    public float currentspeed;
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLeft = amountOfJumps;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();
        BasicSpeed = GameController.instance.DataStorage.PlayerInfo.speed;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
        //CheckIfWallSliding();
        CheckJump();
        CheckLedgeClimb();
        //CheckDash();
        CheckIfCanMove();
        AlterGravity();
        currentspeed = GameController.instance.DataStorage.PlayerInfo.speed;
        anim.SetFloat("Speed1", currentspeed/BasicSpeed);
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }
    
    /*
    private void CheckIfWallSliding()
    {
        if (isTouchingWall && movementInputDirection == facingDirection && rb.velocity.y < 0 && !canClimbLedge)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }
    */
    

    private void CheckLedgeClimb()
    {
        if(ledgeDetected && !canClimbLedge)
        {
            if (anim.GetBool("IsAttacking"))
            {
                StopMove();
            }

            canClimbLedge = true;

            if (isFacingRight)
            {
                ledgePos1 = new Vector2(Mathf.Floor((ledgePosBot.x + wallCheckDistance)/10)*10 - ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y/10)*10 + ledgeClimbYOffset1);
                Debug.Log(Mathf.Floor((ledgePosBot.x + wallCheckDistance) / 10) * 10 - ledgeClimbXOffset1);
                Debug.Log("During check 1, ledgePos2 was:"+Mathf.Floor((ledgePosBot.x + wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);
                ledgePos2 = new Vector2(Mathf.Floor((ledgePosBot.x + wallCheckDistance)/10)*10 + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y/10)*10 + ledgeClimbYOffset2); //Ta 30 balansuje nieznany b��d, gdzie przesuwa gracza o 30 w prawo
                Debug.Log("During check 2, ledgePos2 was:"+Mathf.Floor((ledgePosBot.x + wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);
                //Debug.Log(Mathf.Floor((ledgePosBot.x + wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);

            }
            else
            {
                ledgePos1 = new Vector2(Mathf.Ceil((ledgePosBot.x - wallCheckDistance)/10)*10 + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y/10)*10 + ledgeClimbYOffset1);
                Debug.Log(Mathf.Floor((ledgePosBot.x - wallCheckDistance) / 10) * 10 + ledgeClimbXOffset1);
                ledgePos2 = new Vector2(Mathf.Ceil((ledgePosBot.x - wallCheckDistance)/10)*10 - ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y/10)*10 + ledgeClimbYOffset2);
                Debug.Log(Mathf.Floor((ledgePosBot.x + wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);
            }

            StopMove();

            anim.SetBool("canClimbLedge", canClimbLedge);
        }

        if (canClimbLedge)
        {
            transform.position = ledgePos1;
        }
    }

    public void FinishLedgeClimb()
    {
        canClimbLedge = false;
        anim.SetBool("canClimbLedge", canClimbLedge);
        Debug.Log(Mathf.Floor((ledgePosBot.x - wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);
        transform.position = ledgePos2;
        Debug.Log(Mathf.Floor((ledgePosBot.x - wallCheckDistance) / 10) * 10 + ledgeClimbXOffset2);
        StartMove();
        ledgeDetected = false;
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (isGrounded)
        {
            rb.gravityScale = 1;
        }

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsWall);
        isTouchingLedge = Physics2D.Raycast(ledgeCheck.position, transform.right, wallCheckDistance, whatIsWall);
        isWallHigher = Physics2D.Raycast(higherWallCheck.position, transform.right, wallCheckDistance, whatIsWall);

        if(isTouchingWall && !isTouchingLedge && !ledgeDetected && !isWallHigher && !ladderMode)
        {
            ledgeDetected = true;
            ledgePosBot = wallCheck.position;
        }
        if (ladderMode)
        {
            LadderSprite.SetActive(true);
            foreach (GameObject obj in skeletonStuff)
            {
                obj.SetActive(false);
            }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        }
        else
        {
            foreach (GameObject obj in skeletonStuff)
            {
                obj.SetActive(true);
            }
            LadderSprite.SetActive(false);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void CheckIfCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0.01f)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        if (isTouchingWall)
        {
            checkJumpMultiplier = false;
            canWallJump = true;
        }

        if(amountOfJumpsLeft <= 0)
        {
            canNormalJump = false;
        }
        else
        {
            canNormalJump = true;
        }
      
    }

    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if(Mathf.Abs(rb.velocity.x) >= 0.01f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    void AlterGravity()
    {
        if (isRising)
        {
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallingGravity;
                isRising = false;
            }
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isWallSliding", isWallSliding);
        anim.SetBool("ladderMode", ladderMode);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded || (amountOfJumpsLeft > 0))
            {
                NormalJump();
            }
            else
            {
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;
            }
        }

        if(Input.GetButtonDown("Horizontal") && isTouchingWall)
        {
            if(!isGrounded && movementInputDirection != facingDirection)
            {
                StopMove();

                turnTimer = turnTimerSet;
            }
        }

        if (turnTimer >= 0)
        {
            turnTimer -= Time.deltaTime;

            if(turnTimer <= 0 && !canClimbLedge)
            {
                StartMove();
            }
        }

        if (checkJumpMultiplier && !Input.GetButton("Jump"))
        {
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
        }

        if (Input.GetKeyDown(KeyCode.E) && ladderEnterCount > 0)
        {
            ladderMode = !ladderMode;
            if (ladderMode)
            {
                transform.position = new Vector2(CollidedLadderPosition.x, transform.position.y);
            }
        }

      /*  if (Input.GetButtonDown("Dash"))
        {
            if(Time.time >= (lastDash + dashCoolDown))
            AttemptToDash();
        }*/

    }

    /* private void AttemptToDash()
     {
         isDashing = true;
         dashTimeLeft = dashTime;
         lastDash = Time.time;

         PlayerAfterImagePool.Instance.GetFromPool();
         lastImageXpos = transform.position.x;
     }
     */
    public int GetFacingDirection()
    {
        return facingDirection;
    }

    void CheckIfCanMove()
    {
        if (!canClimbLedge && ( !anim.GetBool("IsAttacking") ))
        {
            StartMove();
        }
        else
        {
            StopMove();
        }
    }

    /*private void CheckDash()
    {
        if (isDashing)
        {
            if(dashTimeLeft > 0)
            {
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(dashSpeed * facingDirection, 0.0f);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }

            if(dashTimeLeft <= 0 || isTouchingWall)
            {
                isDashing = false;
                canMove = true;
                canFlip = true;
            }
            
        }
    }*/

    private void CheckJump()
    {
        if(jumpTimer > 0)
        {
            //WallJump
            /*if(!isGrounded && isTouchingWall && movementInputDirection != 0 && movementInputDirection != facingDirection)
            {
                WallJump();
            }*/
            /*else */if (isGrounded)
            {
                NormalJump();
            }
        }
       
        if(isAttemptingToJump)
        {
            jumpTimer -= Time.deltaTime;
        }
        /*
        if(wallJumpTimer > 0)
        {
            if(hasWallJumped && movementInputDirection == -lastWallJumpDirection)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWallJumped = false;
            }else if(wallJumpTimer <= 0)
            {
                hasWallJumped = false;
            }
            else
            {
                wallJumpTimer -= Time.deltaTime;
            }
        }
        */
    }

    private void NormalJump()
    {
        if (canNormalJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, GameController.instance.DataStorage.PlayerInfo.jumpforce);
            amountOfJumpsLeft--;
            jumpTimer = 0;
            isAttemptingToJump = false;
            isRising = true;
            checkJumpMultiplier = true;
        }
    }

    /*
    private void WallJump()
    {
        if (canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            isWallSliding = false;
            amountOfJumpsLeft = amountOfJumps;
            amountOfJumpsLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canMove = true;
            canFlip = true;
            hasWallJumped = true;
            wallJumpTimer = wallJumpTimerSet;
            lastWallJumpDirection = -facingDirection;

        }
    }*/

    private void ApplyMovement()
    {

        if (!isGrounded && !isWallSliding && movementInputDirection == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
        }
        else if(canMove)
        {
            rb.velocity = new Vector2(GameController.instance.DataStorage.PlayerInfo.speed * movementInputDirection, rb.velocity.y);
        }
        if (ladderMode)
        {
            float PlayerInput = Input.GetAxisRaw("Vertical");
            switch (PlayerInput)
            {
                case -1:
                    rb.isKinematic = false;
                    rb.velocity = new Vector2(rb.velocity.x, -LadderSpeed);
                    break;
                case 1:
                    rb.isKinematic = false;
                    rb.velocity = new Vector2(rb.velocity.x, LadderSpeed);
                    break;
                case 0:
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    break;
            }
        }
        
        /*
        if (isWallSliding)
        {
            if(rb.velocity.y < -wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
            }
        }*/
    }

    public void DisableFlip()
    {
        canFlip = false;
    }

    public void EnableFlip()
    {
        canFlip = true;
    }

    private void Flip()
    {
        if (canFlip == true)
        {
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
    public void StopMove()
    {
        canMove=false;
        canFlip=false;
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void StartMove()
    {
        canMove=true;
        canFlip=true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            //ladderInRange = true;
            ladderEnterCount += 1;
            CollidedLadderPosition = collision.gameObject.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            //ladderInRange = false;
            ladderEnterCount -= 1;
            if (ladderEnterCount == 0)
            {
                ladderMode = false;
            }


        }
    }
}
