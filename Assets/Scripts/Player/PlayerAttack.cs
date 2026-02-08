using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldowntimer > attackCooldown && playerMovement.CanAttack())
        {
            Attack();
        }

        cooldowntimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldowntimer = 0;
    }
}
