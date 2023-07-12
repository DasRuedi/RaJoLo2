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
                muffelBody.GetComponent<muffelbrumm>().speaking = true;
            }
        }
        if (bubble == true)
        {
            dialogue.GetComponent<dialogue>().dialogueProgress++;
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

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
