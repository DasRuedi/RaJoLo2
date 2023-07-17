using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class SeifenTunk : MonoBehaviour
{
    public Sprite[] sprites;

    public int spriteChoice;

    public float spriteTime;
    public float spriteRate;

    public float speed;

    public bool tunk;
    public bool tunkIn;
    public bool tunkOut;
    public int tunkAmount;
    public int tunkLimit;
    public bool proceed;
    public bool inactive;

    public Vector3 startPos;
    public Vector3 inactPos;
    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

        if (tunk == true)
        {
            spriteTime += Time.deltaTime;

            if (spriteTime >= spriteRate)
            {
                if (tunkIn == true)
                {
                    spriteChoice++;
                    spriteTime = 0;
                }
                if (tunkOut == true)
                {
                    spriteChoice--;
                    spriteTime = 0;
                }

                if (spriteChoice >= 2)
                {
                    if (tunkIn == true)
                    {
                        spriteChoice = 2;
                        tunkIn = false;
                        tunkOut = true;
                    }
                }

                if (spriteChoice <= 0)
                {
                    if (tunkOut == true)
                    {
                        spriteChoice = 0;
                        tunkOut = false;
                        tunkIn = true;
                        tunkAmount++;
                    }
                }
            }
        }

        if (tunkAmount >= tunkLimit)
        {
            tunk = false;
            proceed = true;
        }

        if (proceed == true)
        {
            if (transform.position.y > inactPos.y)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (transform.position.y <= inactPos.y)
            {
                inactive = true;
                proceed = false;
            }
        }
    }
}
