using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour {

    float fader = 0.002f;
    [SerializeField]
    GameObject MSA;
    [SerializeField]
    GameObject ENF;
    [SerializeField]
    GameObject SMU;

    string ending;
    // Use this for initialization
    void Start ()
    {
        ending = PlayerPrefs.GetString("Ending");
		switch(ending)
        {
            case ("MSA"):
                MSA.SetActive(true);
                break;
            case ("ENF"):
                ENF.SetActive(true);
                break;
            case ("SMU"):
                SMU.SetActive(true);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        switch (ending)
        {
            case ("MSA"):
                if (MSA.GetComponent<CanvasGroup>().alpha < 1) //&& and player chose MSA.
                {
                    MSA.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
            case ("SMU"):
                if (SMU.GetComponent<CanvasGroup>().alpha < 1) //&& and player chose enforcers.
                {
                    SMU.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
            case ("ENF"):
                if (ENF.GetComponent<CanvasGroup>().alpha < 1) //&& and player chose smugglers.
                {
                    ENF.GetComponent<CanvasGroup>().alpha += fader;
                }
                break;
        }
        
        
        
        
    }
}
