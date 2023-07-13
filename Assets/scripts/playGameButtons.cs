using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class playGameButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject question;

    public bool yes;
    public bool no;

    public float alpha;

    public bool asking;
    public bool answered;

    public Color buttonColor;

    void Start()
    {

    }

    void Update()
    {

        gameObject.GetComponent<SpriteRenderer>().color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, alpha);

        if (yes == true || no == true)
        {
            asking = question.GetComponent<playGameButtons>().asking;
            answered = question.GetComponent<playGameButtons>().answered;
        }

        if (asking == true)
        {
            alpha = 1;
            answered = false;
        }
        if (asking == false)
        {
            alpha = 0;
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (yes == true)
        {
            SceneManager.LoadScene("AngerGame");
        }
        if (no == true)
        {
            Debug.Log("no");
            question.GetComponent<playGameButtons>().asking = false;
            question.GetComponent<playGameButtons>().answered = true;
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
