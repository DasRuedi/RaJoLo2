using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class jiggle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool hoverOver;


    public bool jiggling;

    public float jiggleSpeed;
    public float jiggleTime;
    public float jiggleRate;


    void Start()
    {
        
    }


    void Update()
    {
        if (jiggling == true)
        {
            if (hoverOver == true)
            {
                jiggleTime += Time.deltaTime;
                transform.Rotate(new Vector3(0, 0, jiggleSpeed) * Time.deltaTime);

                if (jiggleTime >= jiggleRate)
                {
                    jiggleSpeed *= -1;
                    jiggleTime = 0;
                }
            }
            if (hoverOver == false)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                jiggleTime = 0;
            }
        }

    }


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
        hoverOver = true;

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hoverOver = false;
    }
}
