using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class GameOver : MonoBehaviour {

	[YarnCommand("GameEnd")]
    public void GameEnd(string ending)
    {
        PlayerPrefs.SetString("Ending", ending);
        SceneManager.LoadScene("EndOfTheGame");
    }
}
