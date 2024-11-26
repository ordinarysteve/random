using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class DialogueOBJ
{
    public string[] Dialogues;
    public string CharacterName;
    public int questNumber;
}



public class DialogueObject : MonoBehaviour
{
    public PlayerData data;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI DialogueText;
    public PlayerController rigid;
    public MoveCamera movementCamera;
    public PlayerCam playerCamera;

    private int currentDialogueNumber = 0;
    private DialogueOBJ curDialogue = null;

    [Header("Dialogue Objects")]
    public DialogueOBJ dialogue1;
    public DialogueOBJ dialogue1o5;

    [Header("NPCS")]
    public Furina npc1;

    private void OnEnable()
    {
        switch (data.DialogueNumber)
        {
            case 1:
                PlayDialogue(dialogue1);
                curDialogue = dialogue1;
                break;
            case 1.5f:
                PlayDialogue(dialogue1o5);
                curDialogue = dialogue1o5;
                break;
        }
    }

    void PlayDialogue(DialogueOBJ tempobj)
    {
        nameText.text = tempobj.CharacterName;
        if (currentDialogueNumber < tempobj.Dialogues.Length)
        {
            DialogueText.text = tempobj.Dialogues[currentDialogueNumber];
        }
        else
        {
            movementCamera.enabled = true;
            playerCamera.enabled = true;
            rigid.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            switch (data.DialogueNumber)
            {
                case 1:
                    npc1.hasTalked = true;
                    npc1.isInDialogue = false;
                    break;
                case 1.5f:
                    npc1.isInDialogue = false;
                    break;
            }
            data.DialogueNumber = 0;
            currentDialogueNumber = 0;
            data.questNumber = curDialogue.questNumber;
            curDialogue = null;

            this.gameObject.SetActive(false);
        }

    }

    public void NextDialogue()
    {
        if (curDialogue != null)
        {
            currentDialogueNumber++;
            PlayDialogue(curDialogue);
        }
    }
}
