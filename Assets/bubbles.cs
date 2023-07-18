using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    public Sprite[] sprites;

    public int spriteChoice;

    public int popChoice;

    public float speed;

    public float lifeTime;
    public float lifeSpan;
    public float popTime;
    public float blowTime;

    public bool getSpeed;

    public float movementX;
    public float blowMovementX;
    public float movementY;
    public float blowMovementY;


    public float blowScale;
    public float scale;
    public float growth;


    void Start()
    {
        spriteChoice = Random.Range(0, sprites.Length -1);
        blowMovementX = Random.Range(-10, 10);
        blowMovementY = Random.Range(-5, 25);
        lifeSpan = Random.Range(0.1f, 5f);
        blowScale = Random.Range(0.01f, 0.15f);
        growth = Random.Range(-0.1f, 0.1f);
        popChoice = Random.Range(1,5);
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];
        lifeTime += Time.deltaTime;

        if (lifeTime < lifeSpan - popTime)
        {
            if (lifeTime < blowTime)
            {
                transform.localScale = new Vector3(blowScale, blowScale, blowScale);


                blowMovementX -= Time.deltaTime;
                blowMovementY -= Time.deltaTime;

                if (blowScale >= 0)
                {
                    blowScale -= Time.deltaTime * 0.1f;
                }


                transform.position += new Vector3(blowMovementX, blowMovementY, 0) * Time.deltaTime;
            }

            if (lifeTime >= blowTime)
            {
                if (getSpeed == true)
                {
                    movementX = blowMovementX /3f;
                    movementY = blowMovementY /3f;
                    scale = blowScale;
                    getSpeed = false;
                }

                transform.localScale = new Vector3(scale, scale, scale);

                movementX += Random.Range(-0.1f, 0.1f);
                movementY += Random.Range(-0.1f, 0.1f);

                if (scale >= 0.01f)
                {
                    scale += Time.deltaTime * growth;
                }

                transform.position += new Vector3(movementX, movementY, 0) * Time.deltaTime;
            }

        }

        if (lifeTime >= lifeSpan - popTime)
        {
            transform.localScale = new Vector3(scale, scale, scale);
            spriteChoice = 3;
            /*if(popChoice == 1)
            {
                FindObjectOfType<AudioManager>().Play("bubblePop");
            }
            if(popChoice == 2)
            {
                FindObjectOfType<AudioManager>().Play("bubblePop2");
            }
            if(popChoice == 3)
            {
                FindObjectOfType<AudioManager>().Play("bubblePop3");
            }
            if(popChoice == 4)
            {
                FindObjectOfType<AudioManager>().Play("bubblePop4");
            }*/

            
        }

        if (lifeTime >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
