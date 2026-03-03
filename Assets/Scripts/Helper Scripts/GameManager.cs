using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this; 
    }

    public void restartGame()
    {
        Invoke("RestartAfterTime", 1f);
        
    }

    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
