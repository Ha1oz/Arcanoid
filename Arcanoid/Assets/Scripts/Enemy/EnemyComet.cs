using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComet : Enemy
{
    private SpriteRenderer rend;
    [SerializeField] private Sprite[] comets;
    [SerializeField] private GameObject explosionPrefab;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = comets[Random.Range(0, comets.Length)];
    }

    public override void Die()
    {
        GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(obj, 0.7f);

        int rnd = Random.Range(0, 100);
        if (rnd <= 19)
        {
            Debug.Log("Бонус");
        }


        //Добавить бонусы
        base.Die();
    }

}
