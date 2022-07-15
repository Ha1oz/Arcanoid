using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    //public bool isEnemyBullet;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime,Space.World);

        if (transform.position.x>15 || transform.position.x<-15) {
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {

            EnemyShip ship = collision.GetComponent<EnemyShip>();
            if (ship!=null) {
                ship.HitDamage(damage);
            }

            EnemyComet comet = collision.GetComponent<EnemyComet>();
            if (comet != null)
            {
                comet.HitDamage(damage+1);
            }

            Enemy boss = collision.GetComponent<EnemyBoss>();
            if (boss != null)
            {
                boss.HitDamage(damage + 1);
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player")) {
            Destroy(gameObject);
            collision.GetComponent<PlayerMovement>().HitDamage();
        }
        if (collision.CompareTag("Playerbullet"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemybullet"))
        {
            Destroy(gameObject);
            
        }
    }
}
