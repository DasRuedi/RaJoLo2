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
    public GameObject cursor;

    public bool startButton;
    public bool ok;
    public bool delete;
    public bool endBreath;
    public bool endAnger;



    public Vector3 startPos;
    public Vector3 inactivePos;

    public void Start()
    {
        startPos = transform.position;
        FindObjectOfType<AudioManager>().Play("malen");
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

        if (endBreath == true || endAnger == true)
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
            FindObjectOfType<AudioManager>().Play("Check");
            FindObjectOfType<AudioManager>().StopPlaying("malen");
            FindObjectOfType<AudioManager>().Play("destroy");
            //CHeck
        }

        if (delete == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.DELETE;
            FindObjectOfType<AudioManager>().Play("DrawAgain");
            //Delete
        }

        if (endAnger == true)
        {
            gameManager.GetComponent<miniGameManager>().state = GameState.PROCEED;
        }

        if (endBreath == true)
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
        cursor.GetComponent<CursorManager>().jitter = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        cursor.GetComponent<CursorManager>().jitter = false;
    }
}
