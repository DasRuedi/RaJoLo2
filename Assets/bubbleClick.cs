using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class bubbleClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public bool minigame;
    public bool house;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (house == true)
        {
            gameObject.GetComponent<houseBubbles>().popping = true;
            gameObject.GetComponent<houseBubbles>().setPop = true;

        }
        if (minigame == true)
        {
            gameObject.GetComponent<bubbles>().popping = true;
            gameObject.GetComponent<bubbles>().setPop = true;
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
