using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

                                                                // Script by Mattias Eriksson

public class Introduction : MonoBehaviour {
    //Collecting the slides as gameobjects.
    [SerializeField]
    GameObject slide1;
    [SerializeField]
    GameObject slide2;
    [SerializeField]
    GameObject slide3;
    [SerializeField]
    GameObject slide4;
    [SerializeField]
    GameObject movingOn;
    [SerializeField]
    GameObject DiaBox;

    IEnumerator coroutine;
    int timecheckpoint = 8;
    float fader = 0.002f;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        coroutine = fadingSlide(12.0f);
        StartCoroutine(coroutine);
    }
    private IEnumerator fadingSlide(float waitTime)
    {
        while (timecheckpoint > 0)
        {
            yield return new WaitForSeconds(waitTime);
            timecheckpoint = timecheckpoint - 1;
        }
        
    }
    void Update()
    {
        if (DiaBox.GetComponent<CanvasGroup>().alpha < 1 && timecheckpoint == 8)
        {
            DiaBox.GetComponent<CanvasGroup>().alpha += fader;
        }

        switch (timecheckpoint)
        {
            case 8:
                if (slide1.GetComponent<CanvasGroup>().alpha < 1)
                {
                    slide1.GetComponent<CanvasGroup>().alpha += fader;
                }

                break;
            case 7:
                if (slide1.GetComponent<CanvasGroup>().alpha > 0)
                {
                    slide1.GetComponent<CanvasGroup>().alpha -= fader;
                }
                break;
            case 6:
                if (slide2.GetComponent<CanvasGroup>().alpha < 1)
                {
                    slide2.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
            case 5:
                if (slide2.GetComponent<CanvasGroup>().alpha > 0)
                {
                    slide2.GetComponent<CanvasGroup>().alpha -= fader;
                }
                break;
            case 4:
                if (slide3.GetComponent<CanvasGroup>().alpha < 1)
                {
                    slide3.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
            case 3:
                if (slide3.GetComponent<CanvasGroup>().alpha > 0)
                {
                    slide3.GetComponent<CanvasGroup>().alpha -= fader;
                }
                break;
            case 2:
                if (slide4.GetComponent<CanvasGroup>().alpha < 1)
                {
                    slide4.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
            case 1:
                if (slide4.GetComponent<CanvasGroup>().alpha > 0)
                {
                    slide4.GetComponent<CanvasGroup>().alpha -= fader;
                }
                audioSource.volume -= fader/10;
                break;
            case 0:
                if (Input.anyKey)
                    {
                    SceneManager.LoadScene(2, LoadSceneMode.Single);
                    }

                if (DiaBox.GetComponent<CanvasGroup>().alpha > 0)
                    {
                    DiaBox.GetComponent<CanvasGroup>().alpha -= fader;
                    }

                audioSource.volume += fader; //Audio goes to max now, change this to make it stop at set audio. (Example stay 0 if set 0 in settings.)

                movingOn.GetComponent<CanvasGroup>().alpha += fader;

                
                break;
            default:
                print("Fade time checkpoints are incorrect!");

                break;
        }
    }
}
