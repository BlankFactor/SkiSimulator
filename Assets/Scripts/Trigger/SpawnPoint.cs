using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool origination;
    private bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (trigger) return;

        if(collision.tag == "Player")
        {
            GameManager.instance.SetSpawnPoint(transform);

            trigger = true;

            if (origination)
            {
                GameManager.instance.Restart_WithAni();
                Judge.instance.SetJudgable(true);
            }
        }
    }
}
