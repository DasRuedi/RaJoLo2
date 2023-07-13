using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringEffect : MonoBehaviour
{
    public float direction;
    public float growSpeed;
    public float minGrow;
    public float maxGrow;
    public float scale;
    public float fadeSpeed;
    public float minfade;
    public float maxfade;
    public float alpha;

    void Start()
    {
        direction = Random.Range(1, 3);

        if (direction < 2)
        {
            growSpeed = Random.Range(-minGrow, -maxGrow);
        }
        if (direction >= 2)
        {
            growSpeed = Random.Range(minGrow, maxGrow);
        }

        fadeSpeed = Random.Range(minfade, maxfade);

        scale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        transform.localScale = new Vector3(scale, scale, scale);

        alpha -= Time.deltaTime * fadeSpeed;

        scale += Time.deltaTime * growSpeed;

        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
}
