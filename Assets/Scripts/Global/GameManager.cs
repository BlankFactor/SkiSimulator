using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static GameManager instance;

    public bool gameStarted;
    public bool gamePaused;
    public bool gameCeased;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void CeaseGame()
    {
        gameStarted = false;
        gameCeased = true;
    }

    public void PauseGame()
    {
        if (gamePaused)
        {
            gamePaused = false;
        }
        else
        {
            gamePaused = true;
        }
    }

    public bool CheckIfGaming()
    {
        if (gamePaused || !gameStarted)
            return false;

        return true;
    }
}
