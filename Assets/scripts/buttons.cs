using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameManager;
    public GameObject mood;
    public GameObject breath;

    public bool startButton;
    public bool ok;
    public bool delete;
    public bool end;



    Vector3 startPos;
    public Vector3 inactivePos;

    public void Start()
    {
        startPos = transform.position;
    }

    public void Update()
    {

        if (ok == true || delete == true)
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

        if (end == true)
        {

            if (gameManager.GetComponent<miniGameManager>().state == GameState.PLAYING)
            {
                if (gameManager.GetComponent<miniGameManager>().smash == true)
                {
                    if (mood.GetComponent<moodIcon>().enough == true)
                    {
                        transform.position = startPos;
                    }
                    if (mood.GetComponent<moodIcon>().enough == false)
                    {
                        transform.position = inactivePos;
                    }
                }
                if (gameManager.GetComponent<miniGameManager>().breathe == true)
                {
                    if (breath.GetComponent<ringGrow>().breaths < 5)
                    {
                        transform.position = inactivePos;
                    }
                    if (breath.GetComponent<ringGrow>().breaths >= 5)
                    {
                        transform.position = startPos;
                    }
                }
            }
            else
            {
                transform.position = inactivePos;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (startButton == true)
        {
            SceneManager.LoadScene("House");
        }

        if (ok == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.TRANSITION;
        }

        if (delete == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.DELETE;
        }

        if (end == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.END;
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
