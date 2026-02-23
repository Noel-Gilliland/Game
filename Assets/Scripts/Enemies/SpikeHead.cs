using UnityEngine;

public class SpikeHead : EnemyDamage
{
    private Vector3 destination;
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    private float checkTimer;


    private bool attacking;

    private Vector3[] directions = new Vector3[4];
    private void Update()
    {
        //move spikehead to destination if attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else
        {
                       //check if player is in range
            checkTimer += Time.deltaTime;
            if (checkTimer > checkDelay)
            {
                checkTimer = 0;
                Collider2D hit = Physics2D.OverlapCircle(transform.position, range, LayerMask.GetMask("Player"));
                if (hit != null)
                {
                    attacking = true;
                    destination = (hit.transform.position - transform.position).normalized;
                }
            }
        }
    }
    private void CheckForPlayer()
    {
        //check if spikehead sees player
    }
    private void CalculateDirections()
    {

    }
}
