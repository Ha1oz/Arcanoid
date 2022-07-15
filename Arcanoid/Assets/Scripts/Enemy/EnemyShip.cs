
using UnityEngine;

public class EnemyShip : Enemy
{
    public float timeToShoot;

    public GameObject bullet;

    public Transform pointShoot;

    public GameObject explosionPrefab;
    
    void Start()
    {
        AddHP();
        InvokeRepeating("Shoot",0f,timeToShoot);
    }

    private void Shoot()
    {
        Instantiate(bullet, pointShoot.position, bullet.transform.rotation);
    }

    public override void Die()
    {
        GameObject obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(obj, 0.7f);
        base.Die();
    }

}
