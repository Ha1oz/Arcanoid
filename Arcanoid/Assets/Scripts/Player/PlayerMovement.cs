using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public float maxY;

    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float shootDelay;

    private bool isFire;
    private bool isStartShoot;

    private float timeNextShoot = 0f;

    public int hp;

    [Header("Ships")]

    public Sprite[] ships;
    private SpriteRenderer rend;

    void Start()
    {
        isFire = false;
        isStartShoot = true;

        rend = GetComponent<SpriteRenderer>();
        switch (PlayerPrefs.GetInt("SpaceShip")) {

            case 0:
                rend.sprite = ships[0];
                break;
            case 1:
                rend.sprite = ships[1];
                break;
        }

        
    }


    void Update()
    {
        float hor = joystick.Horizontal * speed * Time.deltaTime;
        float vert = joystick.Vertical * speed * Time.deltaTime;

        Vector3 movement = new Vector3(-vert, hor, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 0f), Mathf.Clamp(transform.position.y,-maxY,maxY), 0f);

        transform.Translate(movement);

        if (isFire)
        {
            Shoot();
        }
        
        
    }

    public void Shoot()
    {
        if (isStartShoot) {
            foreach (var point in shootPoints) {
                Instantiate(bullet, point.position, bullet.transform.rotation);

            }
            AudioManager.Instance.PlaySFX();
            isStartShoot = false;
            StartCoroutine(ShootDelay());
        }
       
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        isStartShoot = true;
    }

    public void Fire(bool fire)
    {
        isFire = fire;
    }

    public void HitDamage(int damage = 1) {
        hp -= damage;
        GameManager.Instance.UpdateHPBar();

        if (hp <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }
}
