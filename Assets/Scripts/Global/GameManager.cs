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
    public GameObject player;
    private Animator ani;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted) return;

        if (gameCeased && Input.GetKeyDown(KeyCode.R))
        {
            gameCeased = false;

            Restart_WithAni();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        CameraController.instance.SwitchToPlayerCamera();

        PlayerController.instance.SetControlable(true);
        CameraController.instance.SetEnableMainAnimator(true);
    }

    public void CeaseGame()
    {
        gameStarted = false;
        gameCeased = true;

        CameraController.instance.SetEnableMainAnimator(false);
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
        player.GetComponent<Animator>().Play("Idle");
        player.GetComponent<Character>().Reset();
        StartGame();

        player.transform.position = spawnPoint.position;
        player.transform.eulerAngles = Vector3.zero;

        Judge.instance.Reset();

        DataRecorder.instance.ResetTime();

        StopAllCoroutines();
    }

    public void Restart_WithAni()
    {
        ani.Play("Restart");
        GUIController.instance.DisplayTip_Restart(false);
    }

    public void SetSpawnPoint(Transform _v)
    {
        spawnPoint = _v;
    }
}
