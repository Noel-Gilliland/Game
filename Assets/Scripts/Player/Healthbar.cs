using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    

    


    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10f;


    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10f;
    }
}
