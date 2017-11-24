using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.AI;

/*By Björn Andersson && Timmy Alvelöv*/

public interface IInteractable              //Ser till att spelaren kan interagera med både föremål och NPCs via samma interface
{
    void DoAction();
    void ShowAction(bool show);
}

public class NPCScript : MonoBehaviour, IInteractable
{
    GameObject interactionButton;
    
    public string MyDialogueNode
    {
        get { return this.myDialogueNode; }
    }

    [SerializeField]
    string myDialogueNode;
    
    DialogueRunner dR;

    NavMeshAgent agent;

    Animator anim;

    public Animator Anim
    {
        get { return this.anim; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        if (agent.destination != null && GetComponent<Patrol>().Points.Length > 0)
        {
            anim.SetBool("isWalking", true);
        }
        dR = FindObjectOfType<DialogueRunner>();
    }

    public void DoAction()          //Initierar en dialog mellan spelaren och NPCn
    {
        if (myDialogueNode != "null")
        {
            anim.SetBool("isWalking", false);
            FindObjectOfType<DialogueRunner>().CurrentAgent = GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            FindObjectOfType<PlayerControls>().CurrentInteractable = null;
            dR.SetDialogue(myDialogueNode);
        }
    }

    public void ShowAction(bool show)       //Visar att NPCn går att interagera med
    {
        //Här ska det vara nåt sen, men det är det inte
    }
}