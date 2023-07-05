using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class miniGameCam : MonoBehaviour
{
    public GameObject gameManager;
    public Camera cam;

    public float speed;

    public float timer;
    public float stayTime;

    public float fullScreen;
    public bool zoom;

    // Start is called before the first frame update
    void Start()
    {
        cam.orthographicSize = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<miniGameManager>().state == GameState.TRANSITION)
        {
            if (zoom == false)
            {
                timer += Time.deltaTime;
            }

            if (timer >= stayTime)
            {
                zoom = true;
            }

        }

        if (zoom == true)
        {
            if (cam.orthographicSize < fullScreen)
            {
                cam.orthographicSize += Time.deltaTime * speed;
            }

        }

        if (cam.orthographicSize >= fullScreen)
        {
            cam.orthographicSize = fullScreen;
            zoom = false;
        }
    }
}
