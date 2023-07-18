using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smash : MonoBehaviour
{
    public GameObject smashEffect;
    public Sprite[] sprites;
    public int spriteChoice;

    public float LifeTime;
    public float lifeSpan;

    public float randRota;
    public float randScale;

    void Start()
    {
        randRota = Random.Range(0f, 360f);
        randScale = Random.Range(1f, 5f);

        transform.Rotate(0, 0, randRota);
        transform.localScale = new Vector3(randScale, randScale, 0);
        spriteChoice = Random.Range(0, sprites.Length);
    }


    void Update()
    {
        LifeTime += Time.deltaTime;

        smashEffect.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

        if (LifeTime >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
