using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class roomClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject cam;
    public GameObject player;
    public GameObject cursor;

    public int room;

    public int objectsInRoom;
    public int resetObjects;

    public bool entering;


    public void Start()
    {

    }

    public void Update()
    {
        if (resetObjects >= objectsInRoom)
        {
            if (entering == true)
            {
                entering = false;
            }
        }

        if (entering == false)
        {
            resetObjects = 0;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.GetComponent<playerMovement>().isMoving == false)
        {
            if (room == 1)
            {
                entering = true;
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = true;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
                cursor.GetComponent<CursorManager>().jitter = false;
                player.GetComponent<playerMovement>().ResetAnim();
            }
            if (room == 2)
            {
                entering = true;
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = true;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
                cursor.GetComponent<CursorManager>().jitter = false;
                player.GetComponent<playerMovement>().ResetAnim();
            }
            if (room == 3)
            {
                entering = true;
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = true;
                cam.GetComponent<cameraMovement>().inRoom4 = false;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
                cursor.GetComponent<CursorManager>().jitter = false;
                player.GetComponent<playerMovement>().ResetAnim();
            }
            if (room == 4)
            {
                entering = true;
                cam.GetComponent<cameraMovement>().onStart = false;
                cam.GetComponent<cameraMovement>().inRoom1 = false;
                cam.GetComponent<cameraMovement>().inRoom2 = false;
                cam.GetComponent<cameraMovement>().inRoom3 = false;
                cam.GetComponent<cameraMovement>().inRoom4 = true;
                cam.GetComponent<cameraMovement>().repos = true;
                player.GetComponent<playerMovement>().getRoom = true;
                cursor.GetComponent<CursorManager>().jitter = false;
                player.GetComponent<playerMovement>().ResetAnim();
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
