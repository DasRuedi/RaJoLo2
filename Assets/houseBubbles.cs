using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class houseBubbles : MonoBehaviour
{
    public Sprite[] sprites;

    public int spriteChoice;

    public float speed;

    public float lifeTime;
    public float lifeSpan;
    public float popTime;

    public float movementX;
    public float movementY;
    public float movementZ;

    public float scale;

    public bool popping;
    public bool setPop;

    void Start()
    {
        spriteChoice = Random.Range(0, sprites.Length - 1);
        movementX = Random.Range(-0.03f, 0.03f);
        movementY = Random.Range(-0.03f, 0.03f);
        movementZ = Random.Range(-0.03f, 0.03f);
        scale = Random.Range(0.001f, 0.02f);
        lifeSpan = Random.Range(1f, 30f);
    }


    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];
        lifeTime += Time.deltaTime;


        if (lifeTime < lifeSpan - popTime)
        {
            transform.localScale = new Vector3(scale, scale, scale);

            movementX += Random.Range(-0.005f, 0.005f);
            movementY += Random.Range(-0.005f, 0.005f);
            movementZ += Random.Range(-0.005f, 0.005f);


            transform.position += new Vector3(movementX, movementY, movementZ) * Time.deltaTime;

        }

        if (lifeTime >= lifeSpan - popTime && popping == false)
        {
            setPop = true;
            popping = true;
        }


        if (popping == true)
        {
            if (setPop == true)
            {
                lifeTime = lifeSpan - popTime;
                setPop = false;
            }

            transform.localScale = new Vector3(scale, scale, scale);
            spriteChoice = 3;
        }

        if (lifeTime >= lifeSpan || bubbleSpawner.inRoom2notAngy == false)
        {
            if (lifeTime >= lifeSpan)
            {
                Debug.Log("lifeSpan: " +lifeSpan);
            }

            Destroy(gameObject);
        }
    }
}
