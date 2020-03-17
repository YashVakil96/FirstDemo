using UnityEngine;
using UnityEngine.SceneManagement;
public class playercontoller : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public LayerMask WhatIsGround;
    public int extraJumpValues;
    public float speedMultiplyer;
    public float speedIncreaseMilestone;
    public Transform GroundCheck;
    public float checkRadius;
    public GameObject DeadMenu;


    private Rigidbody2D rb;
    private bool isGrounded;
    private int extraJump;
    private Animator anim;
    private float speedMilestoneCount;
    bool gamestart;
    Freezer freezer;


    void Start()
    {
        gamestart = false;
        extraJump = 1 + extraJumpValues;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        anim = GetComponent<Animator>();
        speedMilestoneCount = speedIncreaseMilestone;
        freezer = GameObject.Find("Freeze Manager").GetComponent<Freezer>();
    }

    private void Update()
    {
     
        if (!PauseMenu.GameIsPaused)
        {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, WhatIsGround);
            if (transform.position.x > speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreaseMilestone;
                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplyer;
                speed = speed * speedMultiplyer;
            }
            if (isGrounded == true && speed > 0)
            {
                anim.SetBool("IsRunning", false);
                anim.SetFloat("speed", speed);

            }
            if (isGrounded == true)
            {
                extraJump = 1 + extraJumpValues;
            }
            if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
            {
                gamestart = true;

            }
            if (gamestart)
            {


                if (isGrounded == true)
                {
                    anim.SetBool("IsRunning", true);
                    anim.SetBool("isGround", true);
                    extraJump = 1 + extraJumpValues;
                }

                if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJump > 0)
                {
                    anim.SetBool("isGround", false);
                    rb.velocity = Vector2.up * jumpforce;
                    extraJump--;
                    //Debug.Log("UPDATE : " + extraJump);
                    if (extraJump < 0)
                        extraJump = 0;
                }
                else if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJump == 0 && isGrounded == true)
                {
                    rb.velocity = Vector2.up * jumpforce;
                }

                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -10f, 15f), transform.position.z);
            }
            if (transform.position.y < -9)
                speed = 0;
            if (speed <= 0)
            {
                DeadMenu.SetActive(true);
                Time.timeScale = 1;
            }
        }
        
    }
    void FixedUpdate()
    {
        if (gamestart)
        {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, WhatIsGround);
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && extraJump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                anim.SetBool("isGround", false);
                extraJump--;
                if (extraJump < 0)
                    extraJump = 0;
            }


            if (speed == 0)
            {
                anim.SetBool("IsDead", true);
                

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            speed = 0;
            jumpforce = 0;
            rb.velocity = new Vector2(0, 0);
            Invoke("freeze", 0.5f);
        }
        if (collision.gameObject.tag.Equals("Spike"))
        {
            speed = 0;
            jumpforce = 0;
            rb.velocity = new Vector2(0, 0);
            Invoke("freeze", 0.5f);
        }
    }
    void sceneChange()
    {
        SceneManager.LoadScene("First Demo");
    }
    void freeze()
    {
        freezer.Freeze();
    }
}