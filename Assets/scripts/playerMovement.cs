using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool isMoving;

    public float stepTime;
    public float stepRate;

    public GameObject leftLeg;
    public GameObject rightLeg;

    public Vector3 leftStandOffset;
    public Vector3 rightStandOffset;
    public Vector3 leftMoveOffset;
    public Vector3 rightMoveOffset;

    public int floor;
    public int side;

    public GameObject cam;

    public bool inCurrRoom;
    public bool getRoom;

    public Vector3 enterRoom1;
    public Vector3 enterRoom2;
    public Vector3 enterRoom3;
    public Vector3 enterRoom4;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            leftLeg.GetComponent<Transform>().position = transform.position + leftStandOffset;
            rightLeg.GetComponent<Transform>().position = transform.position + rightStandOffset;
        }

        if (isMoving == true)
        {
            stepTime += Time.deltaTime;

            if (stepTime < stepRate)
            {
                leftLeg.GetComponent<Transform>().position = transform.position + leftMoveOffset;
                rightLeg.GetComponent<Transform>().position = transform.position + rightStandOffset;
            }
            if (stepTime >= stepRate && stepTime < stepRate * 2)
            {
                leftLeg.GetComponent<Transform>().position = transform.position + leftStandOffset;
                rightLeg.GetComponent<Transform>().position = transform.position + rightMoveOffset;
            }
            if (stepTime >= stepRate * 2)
            {
                stepTime = 0;
            }
        }

        if (transform.position.y < -1)
        {
            floor = -1;
        }
        if (transform.position.y > -1)
        {
            floor = 1;
        }

        if (transform.position.x < 0)
        {
            side = -1;
        }
        if (transform.position.x > 0)
        {
            side = 1;
        }

        if (cam.GetComponent<cameraMovement>().inRoom1)
        {
            if (getRoom == true)
            {
                if (floor == 1 && side == -1)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                if (floor != 1 || side != -1)
                {
                    getRoom = false;
                    inCurrRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom1;
                    isMoving = true;
                }

                if (transform.position.x > -1 && isMoving == true)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);

                    if (transform.localScale.x > 0)
                    {
                        transform.localScale *= -1;
                    }
                }
                if (transform.position.x <= -1 && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                }
            }
        }

        if (cam.GetComponent<cameraMovement>().inRoom2)
        {
            if (getRoom == true)
            {
                if (floor == 1 && side == 1)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                if (floor != 1 || side != 1)
                {
                    inCurrRoom = false;
                    getRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom2;
                    isMoving = true;
                }

                if (transform.position.x < 1 && isMoving == true)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);

                    if (transform.localScale.x < 0)
                    {
                        transform.localScale *= -1;
                    }
                }
                if (transform.position.x >= 1 && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                }
            }
        }
        if (cam.GetComponent<cameraMovement>().inRoom3)
        {
            if (getRoom == true)
            {
                if (floor == -1 && side == -1)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                if (floor != -1 || side != -1)
                {
                    inCurrRoom = false;
                    getRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom3;
                    isMoving = true;
                }

                if (transform.position.x > -1 && isMoving == true)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);

                    if (transform.localScale.x > 0)
                    {
                        transform.localScale *= -1;
                    }
                }
                if (transform.position.x <= -1 && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                }
            }
        }

        if (cam.GetComponent<cameraMovement>().inRoom4)
        {
            if (getRoom == true)
            {
                if (floor == -1 && side == 1)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                if (floor != -1 || side != 1)
                {
                    inCurrRoom = false;
                    getRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom4;
                    isMoving = true;
                }

                if (transform.position.x < 1 && isMoving == true)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);

                    if (transform.localScale.x < 0)
                    {
                        transform.localScale *= -1;
                    }
                }
                if (transform.position.x >= 1 && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                }
            }
        }
    }
}
