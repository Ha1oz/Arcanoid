using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGO : MonoBehaviour
{

    public Sprite playerSprite;
    void Start()
    {
        gameObject.name = "SuperPuper";
        SpriteRenderer rend = gameObject.AddComponent<SpriteRenderer>();
        rend.sprite = playerSprite;
    }

}
