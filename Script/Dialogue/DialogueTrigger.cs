using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject DialoguePanel, DialogueStart, Iphone;
    public bool required = false; // Optional: Set to true if this trigger requires the player to have the required item first.

    public void TriggerDialogue()
    {
        if (required == true)
        {
            DialoguePanel.SetActive(true);
            DialogueStart.SetActive(false);
            Iphone.SetActive(false);
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
