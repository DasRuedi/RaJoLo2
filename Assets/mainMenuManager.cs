using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuManager : MonoBehaviour
{
    public bool controls;
    public bool moveLeft;
    public bool moveRight;

    public float moveSpeed;

    public Vector3 startPos;
    public Vector3 controlPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if (controls == false)
        {
            transform.position = startPos;
        }

        if (controls == true)
        {
            if (moveLeft == true)
            {
                if (transform.position.x < controlPos.x)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
                }
                if (transform.position.x >= controlPos.x)
                {
                    transform.position = controlPos;
                    moveLeft = false;
                }
            }

            if (moveRight == true)
            {
                if (transform.position.x > startPos.x)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                }
                if (transform.position.x <= startPos.x)
                {
                    transform.position = startPos;
                    moveRight = false;
                    controls = false;
                }
            }
        }
    }
}
