using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float right_left;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isRight = true;
    public float jumpForce = 8f;
    private bool isGrounded;
    [SerializeField] private bool canDoubleJump;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    [SerializeField] public Vector3 direction = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        right_left = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(this.right_left * speed, rb.velocity.y);
        this.ReverseVelocity();
        anim.SetFloat("Move", Mathf.Abs(this.right_left));
        if (this.right_left != 0)
        {
            this.direction = this.right_left < 0 ? Vector3.left : Vector3.right;
        }
        this.CheckOnGround();
        Debug.Log(isGrounded);
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.Jump();
            this.anim.SetTrigger("Jump");
        }
        else if (canDoubleJump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.Jump();
            canDoubleJump = false;
            anim.SetTrigger("DbJump");
        }
        anim.SetBool("isGround", isGrounded);
        anim.SetFloat("VelocityY", rb.velocity.y);
    }
    public virtual void ReverseVelocity()
    {
        if (this.isRight && this.right_left < 0 || !this.isRight && this.right_left > 0)
        {
            isRight = !isRight;
            Vector3 local = transform.localScale;
            local.x = local.x * -1;
            transform.localScale = local;
        }
    }

    public void CheckOnGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            this.canDoubleJump = true;
        }

    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }
}
