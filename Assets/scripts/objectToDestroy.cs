using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectToDestroy : MonoBehaviour
{
    public GameObject bat;
    public GameObject gameManager;
    public GameObject mood;

    public int smashableChoice;
    public int prevChoice;
    public GameObject image;
    public int spriteChoice;


    public Sprite[] tv;
    public Sprite[] sack;
    public Sprite[] karton;

    public int hitsTaken;

    public int damageThreshold;
    public float damageValue;
    public int destroyThreshold;
    public float destroyValue;

    public float nextThreshold;

    public float swipeSpeed;

    public Vector3 resetPos;

    public bool reset;
    public bool repos;


    void Start()
    {
        smashableChoice = Random.Range(1, 4);
        prevChoice = smashableChoice;

        if (smashableChoice == 1)
        {
            image.GetComponent<SpriteRenderer>().sprite = tv[spriteChoice];
        }
        if (smashableChoice == 2)
        {
            image.GetComponent<SpriteRenderer>().sprite = sack[spriteChoice];
        }
        if (smashableChoice == 3)
        {
            image.GetComponent<SpriteRenderer>().sprite = karton[spriteChoice];
        }

    }


    void Update()
    {
        hitsTaken = bat.GetComponent<bat>().hits;

        if (smashableChoice == 1)
        {
            image.GetComponent<SpriteRenderer>().sprite = tv[spriteChoice];
        }
        if (smashableChoice == 2)
        {
            image.GetComponent<SpriteRenderer>().sprite = sack[spriteChoice];
        }
        if (smashableChoice == 3)
        {
            image.GetComponent<SpriteRenderer>().sprite = karton[spriteChoice];
        }

        if (hitsTaken >= damageThreshold && hitsTaken < destroyThreshold)
        {
            spriteChoice = 1;
        }
        if (hitsTaken >= destroyThreshold)
        {
            spriteChoice = 2;
        }
        if (hitsTaken >= nextThreshold)
        {
            bat.GetComponent<bat>().canHit = false;
            transform.Translate(Vector3.left * Time.deltaTime * swipeSpeed);
        }

        if (smashableChoice <= 0)
        {
            smashableChoice = 3;
        }

        if (transform.position.x <= -40)
        {
            reset = true;
            repos = true;

            smashableChoice = Random.Range(1, 4);

            if (smashableChoice == prevChoice)
            {
                smashableChoice--;
            }
            else
            {
                prevChoice = smashableChoice;
            }

            spriteChoice = 0;
        }
        if (repos == true)
        {
            transform.position = resetPos;
            repos = false;
        }

        if (reset == true)
        {

            bat.GetComponent<bat>().hits = 0;

            if (transform.position.x > 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * swipeSpeed);
            }
            if (transform.position.x <= 0)
            {
                reset = false;
                bat.GetComponent<bat>().canHit = true;
                mood.GetComponent<moodIcon>().progress++;
            }
        }
    }
}
