using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    DialogueManager dm;

    private void Start()
    {
        dm = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue()
    {
        if(dm.dialogStarted == false)
        {
            dm.StartDialogue(dialogue);
        }

        else
        {
            dm.DisplayNextSentence();
        }
    }
}
