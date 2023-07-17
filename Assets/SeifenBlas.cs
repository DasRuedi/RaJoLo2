using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeifenBlas : MonoBehaviour
{
    public GameObject seifenTunk;
    public GameObject spawnPoint;

    public GameObject bubbles;

    public float speed;

    public Vector3 startPos;
    public Vector3 actPos;
    public Vector3 bubbleSpawn;

    public int bubbleAmount;

    public bool blowReady;

    public float reBubbleTime;
    public float reBubbleRate;

    void Start()
    {
        
    }

    void Update()
    {
        bubbleSpawn = spawnPoint.GetComponent<Transform>().transform.position;

        if (seifenTunk.GetComponent<SeifenTunk>().inactive == true)
        {
            if (transform.position.y < actPos.y)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }

            if (transform.position.y >= actPos.y)
            {
                transform.position = actPos;
                blowReady = true;
            }


            if (blowReady == true)
            {
                if (Input.GetKey("b"))
                {
                    BlowBubbles();
                }
            }
        }



    }

    public void BlowBubbles()
    {
        reBubbleTime += Time.deltaTime;
        bubbleAmount = Random.Range(0, 5);

        if (reBubbleTime >= reBubbleRate)
        {
            for (int i = 0; i < bubbleAmount; i++)
            {
                Instantiate(bubbles, bubbleSpawn + new Vector3(0, 0, 0.1f), Quaternion.identity);
                reBubbleTime = 0;
            }
        }
    }
}
