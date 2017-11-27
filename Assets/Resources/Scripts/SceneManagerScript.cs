using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {

    public void NewGame() //Used to load a new game.
    {
        PlayerPrefs.SetInt("Load", 0);
        SceneManager.LoadScene (1, LoadSceneMode.Single); //TODO Change XXX to scene of game.
    }
    public void LoadGame()
    {
        PlayerPrefs.SetInt("Load", 1);
        SceneManager.LoadScene(1, LoadSceneMode.Single); //TODO Change XXX to scene of game.
    }

    //TODO Add load function here.

    public void QuitGame() //Used to quit the game.
    {
        Application.Quit(); //Doesn't work when debugging in unity.
    }
}
