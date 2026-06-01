using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject settings;
   
    public void Update()
    {
        if (settings.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            options.SetActive(true);
            settings.SetActive(false);
            Debug.Log("Exiting settings menu");
        }
    }
}
