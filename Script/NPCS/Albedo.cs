using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{
    public class Albedo : MonoBehaviour
    {
        public GameObject triggerText;
        public GameObject DialogueObject;
        public RigidbodyFirstPersonController rigid;
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                triggerText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    triggerText.SetActive(false);
                    other.gameObject.GetComponent<PlayerData>().DialogueNumber = 1;
                    DialogueObject.SetActive(true);
                    rigid.enabled = false;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            triggerText.SetActive(false);
        }
    }
}