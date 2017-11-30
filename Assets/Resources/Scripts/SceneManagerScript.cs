using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SceneManagerScript : MonoBehaviour
{

    public void NewGame() //Used to load a new game.
    {
        PlayerPrefs.SetInt("Load", 0);
        SceneManager.LoadScene(1, LoadSceneMode.Single); //TODO Change XXX to scene of game.
    }
    public void LoadGame()
    {
        if (File.Exists("SaveFile"))
        {
            PlayerPrefs.SetInt("Load", 1);
            SceneManager.LoadScene(2, LoadSceneMode.Single); //TODO Change XXX to scene of game.
        }
        else
            print("No saved game to load.");
    }

    //TODO Add load function here.

    public void QuitGame() //Used to quit the game.
    {
        Application.Quit(); //Doesn't work when debugging in unity.
    }

    public void QuitToMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
