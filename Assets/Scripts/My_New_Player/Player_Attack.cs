using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [SerializeField] private float Basicattackcooldown;
    [SerializeField] private Transform BasicattackOrigin;
    [SerializeField] private AudioClip BasicattackClip;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldowntimer = Mathf.Infinity;


    private void awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldowntimer > Basicattackcooldown && playerMovement.canAttack())
        {
            Basicattack();  
        }
        Basicattackcooldown += Time.deltaTime;
    }

    private void Basicattack()
    {
        //SoundManager.instance.PlaySound(BasicattackClip);
        anim.SetTrigger("Basicattack");
        cooldowntimer = 0;
    }
}
