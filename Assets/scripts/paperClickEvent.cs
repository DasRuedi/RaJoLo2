using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class paperClickEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cam;
    public GameObject gameManager;

    public bool drawing;

    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameManager.GetComponent<miniGameManager>().state == GameState.DELETE || gameManager.GetComponent<miniGameManager>().state == GameState.STARTING || gameManager.GetComponent<miniGameManager>().state == GameState.DRAWING)
        {
            drawing = true;
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {

        drawing = false;
    }
}
