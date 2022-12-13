using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject pauseGameMenu;
    public GameObject pauseButton;
    //[SerializeField]
    //private UnityEvent OnPaused;    
    void Update()
    {
        if (PlayerMove.canMove == true)
        {
            pauseButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseGame)
                {
                    Resume();
                }
                else
                {
                    Pause(true);
                }
            }
            else 
            {
                return;
            }
        }
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }
    public void Pause(bool value)
    {
        if (PlayerMove.canMove == true)
        {
            pauseGameMenu.SetActive(true);
            Time.timeScale = value ? 0 : 1;
            pauseGame = true;
        }
        else
        {
            return;
        }
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }    
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            //OnPaused.Invoke();
            Pause(true);
        }
    }
}
