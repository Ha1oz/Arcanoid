using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    public string nameEnemy;

    public float moveSpeed;

    public int score;







    public virtual void Die() {
        AudioManager.Instance.PlaySFX(1);
        Destroy(gameObject); 
        
    }



    public virtual void AddHP() {
        health = 6;
    }

    public virtual void Update()
    {
        transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        if (transform.position.x < -15f) {
            Destroy(gameObject);

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player") {
            Die();
            collision.collider.GetComponent<PlayerMovement>().HitDamage();
            GameManager.Instance.UpdateScore(score);
        }

    }

    public virtual void HitDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            GameManager.Instance.UpdateScore(score);
            Die();
        }
    }
}
