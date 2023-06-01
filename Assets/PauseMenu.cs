using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame;
    public static bool IsPauseMenuOpen;
    public GameObject pauseGameMenu;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !InventoryScript.IsOpen)
        {
            if (PauseGame)
            {
                Resume();
                pauseGameMenu.SetActive(false);
                IsPauseMenuOpen = false;
            }
            else
            {
                Pause();
                pauseGameMenu?.SetActive(true);
                IsPauseMenuOpen = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Escape) && InventoryScript.IsOpen)
        {
            InventoryScript.IsOpen = false;
            Resume();
        }
        else if (Input.GetKeyUp(KeyCode.Tab) && !IsPauseMenuOpen)
        {
            if (PauseGame)
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
        
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PauseGame = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
