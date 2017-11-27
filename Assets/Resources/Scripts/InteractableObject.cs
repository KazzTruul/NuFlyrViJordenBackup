using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                            /*By Björn Andersson && Timmy Alvelöv*/
public class InteractableObject : MonoBehaviour, IInteractable
{
    Material myMat;

    [SerializeField]
    Material highlightMat;

    void Start()
    {
        myMat = GetComponent<Renderer>().material;
    }
    string myDialogueNode;
    public string DialogueNode
    {
        get
        {
            return myDialogueNode;
        }
    }

    public void DoAction()              //Initierar en dialog mellan spelaren och föremålet
    {
        GameObject.Find("PlayerPrefab").GetComponent<PlayerControls>().CurrentInteractable = null;
        Destroy(this.gameObject);
    }

    public void ShowAction(bool show)           //Visar att föremålet kan interageras med
    {
        if (show)
            GetComponent<Renderer>().material = highlightMat;
        else
            GetComponent<Renderer>().material = myMat;
    }
}
