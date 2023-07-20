using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSpawner : MonoBehaviour
{
    public GameObject bubble;

    public GameObject cam;

    public int startSpawn;
    public int SpawnAmount;

    Vector3 startSpawnPos;

    public Vector3 spawnPos;

    public float spawnTime;
    public float spawnRate;

    public static bool inRoom2notAngy;
    public bool inRoom2notAngyvisible;

    public bool startSpawnDone;


    void Start()
    {
    }


    void Update()
    {
        inRoom2notAngyvisible = inRoom2notAngy;

        if (inRoom2notAngy == true)
        {
            Debug.Log("notAngy");
        }

        if (startSpawnDone == false)
        {
            if (cam.GetComponent<cameraMovement>().inRoom2 == true)
            {
                inRoom2notAngy = true;

                if (progressManager.angerGameDone == true)
                {
                    for (int i = 0; i < startSpawn; i++)
                    {
                        startSpawnPos = new Vector3(Random.Range(-8f, 4f), Random.Range(-1f, 5f), Random.Range(5.5f, 7.5f));

                        Instantiate(bubble, startSpawnPos, Quaternion.identity);
                    }
                }
            }

            startSpawnDone = true;
        }

        if (cam.GetComponent<cameraMovement>().inRoom2 == true)
        {

            if (progressManager.angerGameDone == true)
            {
                inRoom2notAngy = true;
                spawnTime += Time.deltaTime;

                if (spawnTime >= spawnRate)
                {
                    SpawnAmount = Random.Range(10, 30);


                    for (int i = 0; i < SpawnAmount; i++)
                    {
                        spawnPos = new Vector3(Random.Range(-8f, 4f), Random.Range(-1f, 5f), Random.Range(5.5f, 7.5f));

                        Instantiate(bubble, spawnPos, Quaternion.identity);
                    }

                    spawnTime = 0;
                }

            }
        }
        if (cam.GetComponent<cameraMovement>().inRoom2 == false)
        {
            inRoom2notAngy = false;
        }
    }
}
