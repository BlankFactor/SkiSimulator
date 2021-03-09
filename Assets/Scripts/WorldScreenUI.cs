using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldScreenUI : MonoBehaviour
{
    public SpriteRenderer sprite;
    public TextMeshPro text;

    public float lerp = 0.02f;
    public bool trigger = false;

    Color color_Sprite;
    Color color_text;

    Color color_ZA_Sprite;
    Color color_ZA_text;

    public bool selfDestruct;

    // Start is called before the first frame update
    void Start()
    {
        color_Sprite = sprite.color;
        color_text = text.color;

        color_ZA_Sprite = color_Sprite;
        color_ZA_Sprite.a = 0;

        color_ZA_text = color_text;
        color_ZA_text.a = 0;

        sprite.color = color_ZA_Sprite;
        text.color = color_ZA_text;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger)
        {
            sprite.color = Color.Lerp(sprite.color, color_Sprite, lerp);
            text.color = Color.Lerp(text.color, color_text, lerp);
        }
        else
        {
            sprite.color = Color.Lerp(sprite.color, color_ZA_Sprite, lerp);
            text.color = Color.Lerp(text.color, color_ZA_text, lerp);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            trigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger = false;

            if (selfDestruct)
            {
                Destroy(gameObject, 5.0f);
            }
        }
    }
}
