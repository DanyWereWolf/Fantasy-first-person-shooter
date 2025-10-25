using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject crosshairUI;

    public FirstPersonController personController;
    public InventoryManager inventoryManager;

    

    private bool isPaused = false;
    private void Start()
    {
        pauseMenuUI.SetActive(false);
        crosshairUI.SetActive(true);
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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        personController.enabled = true;
        inventoryManager.enabled = true;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (crosshairUI != null) crosshairUI.SetActive(true);
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        personController.enabled = false;
        inventoryManager.enabled = false;
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (crosshairUI != null) crosshairUI.SetActive(false);
        isPaused = true;
    }

   
    public void ResumeButton()
    {
        Resume();
    }
    public void RestartButton()
    {
        RestartLevel();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
