using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;
    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;
    ///////////////////////////////////////////////
    public Animator animator;
    public bool groundedPlayer;
    private CharacterController controller;
    bool m_Jump;
    private bool hasJumped = false;
    //public bool isdead = false;
    public void Awake()
    {
        instance = this;
    }
    /// ///////////////////////////////////////////
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
        m_Jump = false;
    }
    public void FixedUpdate()
    {

        if (!alive)
        {
            return;
        }
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;// เคลื่อนที่ไปข้างหน้า
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;// เคลื่อนที่ ซ้าย ขวา
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        //animator.SetFloat("Speed", Mathf.Abs(movementDirection.x) + Mathf.Abs(movementDirection.z));
        //animator.SetBool("Ground", controller.isGrounded);

    }

    // Update is called once per frame
    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && alive && transform.position.y < 0)//บอกว่าเป็น ground
        {
            m_Jump = true;
            Jump();
        }
        else
        {
            m_Jump = false;
            Jump();
        }
        if (transform.position.y < -0.5)//-5
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.S) && alive)
        {
            animator.SetBool("Roll", true);
        }
        else
        {
            animator.SetBool("Roll", false);
        }
    }
    public void Die()
    {
        alive = false;
        //isdead = true;
        //Invoke("Restart", 2);
        animator.SetBool("Dead", true);

    }
    /*void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/
    void Jump()
    {
        //check whether we r currently ground
        //float height = GetComponent<Collider>().bounds.size.y;
        float height = GetComponent<CharacterController>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);
        //if we jump

        //If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
        if (m_Jump == false)
        {
            animator.SetBool("Jump", false);

        }

        //The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
        if (m_Jump == true)
        {
            animator.SetBool("Jump", true);
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
