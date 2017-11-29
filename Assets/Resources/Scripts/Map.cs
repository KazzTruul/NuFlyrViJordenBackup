using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    bool toggle = true;
    GameObject map;
    PauseGame pG;
	void Start ()
    {
        pG = FindObjectOfType<PauseGame>();
        map = transform.GetChild(0).gameObject;
        map.SetActive(false);	
	}
	
	
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.M) && !pG.Paused && pG.CanPause)
        {
            map.SetActive(toggle);
            toggle = !toggle;
        }	
	}
}
