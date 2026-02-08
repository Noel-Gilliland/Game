using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] private float speed;
    [SerializeField] private float jumppower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;


    private void Awake()
    {
        //Grab references for rigidbody and animator
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Get Horizontal input and move player
        horizontalInput = Input.GetAxis("Horizontal");

        //flip player sprite when moving left or right. +1 if right, -1 if left
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Jump on space key press
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
            Jump();

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());

        //Wall jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

            if (IsOnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            //Wall jump when player is on wall and presses space
            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumppower);
            anim.SetTrigger("jump");

        }
        else if (IsOnWall() && !IsGrounded())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 2);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            else
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;

        }

    }

    private bool IsGrounded()
    {
        //Check if player is grounded by checking for colliders below the player
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool IsOnWall()
    {
        //Check if player is grounded by checking for colliders below the player
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return horizontalInput == 0 && IsGrounded() && !IsOnWall();
    }
}
