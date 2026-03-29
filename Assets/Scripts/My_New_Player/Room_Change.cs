using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room_Change : MonoBehaviour
{

    //[SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private Transform endlocation;
    [SerializeField] private string End_Location_Scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    /*
    void awake()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(End_Location_Scene);
        }
    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));

    }*/
}
