using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform paper;
    public GameObject paperSheet;
    public GameObject gameManager;

    public Image crayon;


    line activeLine;

    public float lifeTime;
    public float lifeSpan;

    public float alpha;

    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<miniGameManager>().state == GameState.DELETE)
        {
            lifeTime = 0;
        }

        if (Input.GetKeyDown("f"))
        {
            lifeTime = 0;
        }


        if (gameManager.GetComponent<miniGameManager>().state == GameState.DRAWING || gameManager.GetComponent<miniGameManager>().state == GameState.STARTING || gameManager.GetComponent<miniGameManager>().state == GameState.DELETE)
        {
            crayon.fillAmount = 0.95f - (lifeTime / lifeSpan);
        }
        else
        {
            crayon.fillAmount = 0;
        }


        if (paperSheet.GetComponent<paperClickEvent>().drawing == true)
        {
            if (lifeTime <= lifeSpan)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (gameManager.GetComponent<miniGameManager>().state == GameState.DELETE || gameManager.GetComponent<miniGameManager>().state == GameState.STARTING)
                    {
                        gameManager.GetComponent<miniGameManager>().state = GameState.DRAWING;
                    }

                    GameObject newLine = Instantiate(linePrefab, transform.position, transform.rotation, paper);
                    activeLine = newLine.GetComponent<line>();
                }

                if (Input.GetMouseButtonUp(0))
                {
                    activeLine = null;
                }

                if (activeLine != null)
                {
                    lifeTime += Time.deltaTime;

                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    activeLine.UpdateLine(mousePos);
                }
            }
        }

        if (paperSheet.GetComponent<paperClickEvent>().drawing == false)
        {
            activeLine = null;
        }



    }
}
