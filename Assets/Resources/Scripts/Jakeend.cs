using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jakeend : MonoBehaviour {

	void OnTriggerEnter()
    {
        GameObject.Find("FinishGame").GetComponent<GameOver>().GameEnd("SMU");
    }
}
