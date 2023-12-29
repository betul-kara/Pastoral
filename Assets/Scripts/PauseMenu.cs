using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject cursor;
    public bool isPause;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && optionMenu.active == false)
        {
            isPause = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            cursor.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
        cursor.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPause = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        Cursor.lockState= CursorLockMode.None;
    }
}
