using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 4f;
    private bool ISJUMPING;
    private float jumpTime;
    private float btnTime = 0.3f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D coll;
    [SerializeField] private Animator anim;

    private enum MovemenState {idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if ( Input.GetButtonDown("Jump") && IsGound()) {
            ISJUMPING = true;
            jumpTime = 0f;
        }

        if (ISJUMPING) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") | jumpTime > btnTime ) 
        { 
            ISJUMPING = false;
        }


        Flip();
        AnimSet();
        

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip() {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void AnimSet() {
        MovemenState state;

        if (horizontal > 0.1f || horizontal < -0.1f){
            state = MovemenState.running;
        }
        else{
            state = MovemenState.idle;
        }
        if (rb.velocity.y > 1f && !IsGound())
        {
            state = MovemenState.jumping;
        }
        else if (rb.velocity.y < -1f) {
            state = MovemenState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGound() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
