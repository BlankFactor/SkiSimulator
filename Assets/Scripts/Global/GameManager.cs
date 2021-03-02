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
    public bool inRacingTrack = true;

    [Header("Objects")]
    public Transform spawnPoint;
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
        if (gameStarted) return;

        if (Input.GetKeyDown(KeyCode.R))
            StartGame();
    }

    public void StartGame()
    {
        gameStarted = true;
        CameraController.instance.SwitchToPlayerCamera();
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

    public void Restart()
    {
        
    }
}
