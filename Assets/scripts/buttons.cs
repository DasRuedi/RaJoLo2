using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameManager;
    public bool ok;
    public bool delete;

    public Vector3 startPos;
    public Vector3 inactivePos;

    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {
        if (gameManager.GetComponent<miniGameManager>().state == GameState.DRAWING)
        {
            transform.position = startPos;
        }
        else
        {
            transform.position = inactivePos;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ok == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.TRANSITION;
        }
        if (delete == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.DELETE;
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
