using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roomClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cam;
    public GameObject player;
    public int room;

    public Collider hitBox;

    public void Start()
    {

    }

    public void Update()
    {
        if (cam.GetComponent<cameraMovement>().onStart == true)
        {
            hitBox.enabled = true;
        }
        if (room == 1)
        {
            if (cam.GetComponent<cameraMovement>().inRoom1 == true)
            {
                hitBox.enabled = false;
            }
        }
        if (room == 2)
        {
            if (cam.GetComponent<cameraMovement>().inRoom2 == true)
            {
                hitBox.enabled = false;
            }
        }
        if (room == 3)
        {
            if (cam.GetComponent<cameraMovement>().inRoom3 == true)
            {
                hitBox.enabled = false;
            }
        }
        if (room == 4)
        {
            if (cam.GetComponent<cameraMovement>().inRoom4 == true)
            {
                hitBox.enabled = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (cam.GetComponent<cameraMovement>().onStart == true)
        {
            if (room == 1)
            {
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = true;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
            }
            if (room == 2)
            {
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = true;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
            }
            if (room == 3)
            {
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = true;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
            }
            if (room == 4)
            {
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = true;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
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

    }
    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
