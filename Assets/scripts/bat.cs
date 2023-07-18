using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject smash;
    public GameObject smashPoint;
    public GameObject objectToDestroy;
    public GameObject batImg;

    public Sprite[] batSprites;
    public int spriteChoice;

    public bool hitting;
    public bool preImpact;
    public bool canHit;

    public float hittingSpeed;
    public float startRotation;
    public float hitRotation;

    public Vector3 smashSpawn;

    public int hits;


    void Start()
    {
        canHit = true;
    }


    void Update()
    {
        smashSpawn = smashPoint.GetComponent<Transform>().transform.position;

        batImg.GetComponent<SpriteRenderer>().sprite = batSprites[spriteChoice];


        if (gameManager.GetComponent<miniGameManager>().state == GameState.PLAYING)
        {
            if (hitting == false && canHit == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hitting = true;
                    preImpact = true;
                }

            }

            if (hitting == true)
            {
                if (preImpact == true)
                {

                    spriteChoice = 1;

                    if (transform.rotation.z < hitRotation)
                    {
                        transform.Rotate(new Vector3(0, 0, hittingSpeed) * Time.deltaTime);
                    }

                    if (transform.rotation.z >= hitRotation)
                    {
                        Instantiate(smash, smashSpawn, Quaternion.identity);
                        if (objectToDestroy.GetComponent<objectToDestroy>().smashableChoice == 4)
                        {
                            FindObjectOfType<AudioManager>().Play("squeak2");
                        }
                        if (objectToDestroy.GetComponent<objectToDestroy>().smashableChoice == 3)
                        {
                            FindObjectOfType<AudioManager>().Play("KistenSmash");
                        }
                        if (objectToDestroy.GetComponent<objectToDestroy>().smashableChoice == 2)
                        {
                            FindObjectOfType<AudioManager>().Play("SackSmash");
                        }
                        if (objectToDestroy.GetComponent<objectToDestroy>().smashableChoice == 1)
                        {
                            FindObjectOfType<AudioManager>().Play("tvsmash");
                        }
                        hits++;
                        preImpact = false;

                    }
                }

                if (preImpact == false)
                {
                    spriteChoice = 0;

                    if (transform.rotation.z > startRotation)
                    {
                        transform.Rotate(new Vector3(0, 0, -hittingSpeed) * Time.deltaTime);
                    }

                    if (transform.rotation.z <= startRotation)
                    {
                        hitting = false;
                    }
                }
            }
        }
    }
}
