using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX; //Horizontal wall jump force
    [SerializeField] private float wallJumpY; //Vertical wall jump force

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;


    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Flip player when moving left-right
            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(2, 1, 1);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-2, 1, 1);
        }
        else
        {
            if (horizontalInput > 0.01f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }

        if(Input.GetKeyDown(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpPower);

        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);



    }
}
