using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //private bool paused = false;
      public Canvas pauseCanvas;
      public Canvas GameplayUI;
      //public Canvas MainMenu;
      //public Camera mainCamera;
      public Canvas GameOver;

    private void Start()
    {
        GameOver.enabled = false;
        //Time.timeScale = 1f;
        //MainMenu.enabled = true;
        pauseCanvas.enabled = false;
        //GameplayUI.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("is it even working?");
            togglePause();
        }
    }


    public void togglePause()
    {
        print("what about the fucntion?");
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pauseCanvas.enabled = false;
            //return (false);
            
        }
        else
        {
            Time.timeScale = 0f;
            pauseCanvas.enabled = true;
           // return (true);
            
        }
    }

    public void restartGame()
    {
        if (GameOver.enabled == true)
            GameOver.enabled = false;
        print("restart game working?");

        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    /*public void startGame()
    {
        MainMenu.enabled = false;
        GameplayUI.enabled = true;
        Time.timeScale = 1f;
        Destroy(mainCamera.gameObject.GetComponent < UnityStandardAssets.ImageEffects.BlurOptimized > ());

    }*/
}