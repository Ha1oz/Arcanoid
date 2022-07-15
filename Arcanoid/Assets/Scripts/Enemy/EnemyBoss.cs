using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{

    [SerializeField] private float yPos;
    private bool isUp;

    [Space(10)]

    [SerializeField] private Transform[] ShootPoints;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootDelay;

    [Space(10)]

    [SerializeField] private GameObject exposionEffect;

    private void Start()
    {
        StartCoroutine(Shoot());   
    }

    IEnumerator Shoot() {

        yield return new WaitForSeconds(shootDelay);

        foreach (var point in ShootPoints) {
            Instantiate(bulletPrefab,point.position,bulletPrefab.transform.rotation);
        }
        StartCoroutine(Shoot());
    }

    public override void Update()
    {
        if (transform.position.x >= 5) {
            base.Update();
            return;
        }

        if (!isUp) {
            transform.Translate(-Vector2.up * moveSpeed * Time.deltaTime,Space.World);
            if (transform.position.y <= -yPos) {
                isUp = true;
            }
        }
        else if (isUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.World);
            if (transform.position.y >= yPos)
            {
                isUp = false;
            }
        }

    }
    public override void Die()
    {
        for (int i = 0; i < 3; i++) {
            GameObject eff = Instantiate(exposionEffect, transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f),Quaternion.identity);

            Destroy(eff, 1f);
        }
        FindObjectOfType<Generator>().Respawn();

        base.Die();
    }
}
