using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] sprites;
    public float speed;
    public const float mePos = 15f;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        RestartPosition();
    }

    private void RestartPosition() {
        rend.sprite = sprites[Random.Range(0, sprites.Length)];
        speed = Random.Range(2f, 10f);
        transform.position = new Vector2(mePos, Random.Range(-6f, 6f));
        transform.localScale = Vector3.one * Random.Range(0.8f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= -20f)
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            RestartPosition();
        }
    }
}
