using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { STARTING, DRAWING, TRANSITION, PLAYING, PAUSE, END, DELETE }
public class miniGameManager : MonoBehaviour
{

    public GameState state;

    public static bool delete;

    void Start()
    {
        state = GameState.STARTING;
    }


    void Update()
    {
        if (state == GameState.DELETE)
        {
            delete = true;
        }
        else
        {
            delete = false;
        }

        if (state == GameState.END)
        {
            progressManager.angerGameDone = true;
            SceneManager.LoadScene("House");
        }
    }
}
