using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainStartPage : MonoBehaviour
{
    private void Start()
    {
		//print("start1");
		//StartGame();
    }

    private void FixedUpdate()
    {
		//print("start");
    }

    public void StartGame()
    {
		//Application.LoadLevel
        print("start from game");
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        print("end");
        Application.Quit();
    }
}
