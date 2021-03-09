using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    private Sprite sprite_Origin;
    public Sprite sprite;

    public float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sprite_Origin = sr.sprite;

        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSprite()
    {
        if (sr.sprite == sprite_Origin)
            sr.sprite = sprite;
        else
            sr.sprite = sprite_Origin;

        Invoke("ChangeSprite", 1.0f);
    }
}
