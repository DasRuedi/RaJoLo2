using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smash : MonoBehaviour
{
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
    }


    void Update()
    {
        LifeTime += Time.deltaTime;

        if (LifeTime >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
