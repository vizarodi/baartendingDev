using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int dineroTotal;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Mas de un Game Manager en escena!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        }
    }

    public void AddMoney(int dineroSumar)
    {
        dineroTotal += dineroSumar;
        Debug.Log("$" + dineroTotal);
    }


    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void closeGame()
    {
        Application.Quit();
    }
}
