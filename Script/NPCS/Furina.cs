using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//namespace UnityStandardAssets.Characters.FirstPerson
//{
public class Furina : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialogueObject;
    public PlayerController rigid;
    public MoveCamera movementCamera;
    public PlayerCam playerCamera;
    public bool hasTalked = false;
    public bool isInDialogue = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isInDialogue && movementCamera.enabled == true && playerCamera.enabled == true)
        {
            triggerText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                isInDialogue = true;
                if (!hasTalked)
                {

                    other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                    DialogueObject.SetActive(true);
                    rigid.enabled = false;
                    movementCamera.enabled = false;
                    playerCamera.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    triggerText.SetActive(false);
                }
                else
                {
                    other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1.5f;
                    DialogueObject.SetActive(true);
                    rigid.enabled = false;
                    movementCamera.enabled = false;
                    playerCamera.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    triggerText.SetActive(false);
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        triggerText.SetActive(false);
    }
}
//}