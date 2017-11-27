using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.AI;

/*By Björn Andersson && Timmy Alvelöv*/

public interface IInteractable              //Ser till att spelaren kan interagera med både föremål och NPCs via samma interface
{
    void DoAction();
    string DialogueNode { get; }
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
    public string DialogueNode
    {
        get
        {
            return myDialogueNode;
        }
    }

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
        if (agent != null)
        {
            if (agent.destination != null && GetComponent<Patrol>().Points.Length > 0)
            {
                anim.SetBool("isWalking", true);
            }
        }

        dR = FindObjectOfType<DialogueRunner>();
    }

    public void DoAction()          //Initierar en dialog mellan spelaren och NPCn
    {
        if (myDialogueNode != "null")
        {
            if (anim != null)
                anim.SetBool("isWalking", false);
            FindObjectOfType<DialogueRunner>().CurrentAgent = GetComponent<NavMeshAgent>();
            if (agent != null)
                agent.isStopped = true;
            FindObjectOfType<PlayerControls>().CurrentInteractable = null;
            dR.SetDialogue(myDialogueNode);
        }
    }
}