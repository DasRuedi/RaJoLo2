using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManagerHouse : MonoBehaviour
{
    

    void Start()
    {
        
    }


    void Update()
    {
        if (progressManager.angerGameDone == true)
        {
            Debug.Log("not angy");
        }
    }
}
