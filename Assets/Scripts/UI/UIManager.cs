using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject settings;
    [SerializeField] private AudioClip gameOverSound;
    private bool isPaused = false;

    private void Awake()
    {
        inGameMenu.SetActive(false);
    }

    public void GameOver()
    {
        inGameMenu.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnSettingsClick()
    {
        options.SetActive(false);
        settings.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        inGameMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
            inGameMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
       
    }

    public void ExitSettings()
    {
        options.SetActive(true);
        settings.SetActive(false);
    }
}
