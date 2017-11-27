using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogue : MonoBehaviour
{
    GameObject Intro;

    void Start()
    {
        if (PlayerPrefs.GetInt("Load") == 1)
        {
            GameObject.Find("IO").GetComponent<SaveLoad>().Load();
        }

        Intro = GameObject.Find("Intro");
        StartCoroutine(StartIntroDialogue());

    }
    IEnumerator StartIntroDialogue()
    {
        yield return new WaitForEndOfFrame();
        Intro.GetComponent<NPCScript>().DoAction();
    }
}
