using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class muffelbrummButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject muffelBody;
    public GameObject speechBubble;
    public GameObject dialogue;

    public GameObject cursor;

    public bool muffelbrumm;
    public bool bubble;

    public bool invisible;

    void Start()
    {
        
    }

    void Update()
    {
        if (muffelbrumm == true)
        {
            invisible = muffelBody.GetComponent<muffelbrumm>().invisible;
        }
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if (muffelbrumm == true)
        {
            if (invisible == false)
            {
                if(muffelBody.GetComponent<muffelbrumm>().speaking == false)
                {
                    FindObjectOfType<AudioManager>().Play("MuffelSound1");
                }

                muffelBody.GetComponent<muffelbrumm>().speaking = true;
            }
        }
        if (bubble == true)
        {
            if (dialogue.GetComponent<dialogue>().dialogueProgress < dialogue.GetComponent<dialogue>().dialogueLength -1)
            {
                dialogue.GetComponent<dialogue>().dialogueProgress++;
            }

            if (dialogue.GetComponent<dialogue>().endOfDialogue == true)
            {

                if (dialogue.GetComponent<dialogue>().chapter1 == true)
                {
                    Debug.Log("restart");
                    dialogue.GetComponent<dialogue>().dialogueProgress = 0;
                }

                if (dialogue.GetComponent<dialogue>().chapter2 == true)
                {
                    dialogue.GetComponent<dialogue>().chapter3 = true;
                    dialogue.GetComponent<dialogue>().chapter2 = false;
                    dialogue.GetComponent<dialogue>().dialogueProgress = 0;
                }

                muffelBody.GetComponent<muffelbrumm>().speaking = false;
                dialogue.GetComponent<dialogue>().endOfDialogue = false;
            }
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        cursor.GetComponent<CursorManager>().jitter = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.GetComponent<CursorManager>().jitter = false;
    }
}
