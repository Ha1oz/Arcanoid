using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public float rangeY;

    public float timeSpawn;

    private bool isBossTime;

    public GameObject bossPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        isBossTime = false;
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeSpawn);

        Vector2 pos = new Vector2(transform.position.x, Random.Range(-rangeY, rangeY));

        int rnd = Random.Range(0, enemyPrefab.Length);

        Instantiate(enemyPrefab[rnd],pos,enemyPrefab[rnd].transform.rotation);

        if (!isBossTime) {
            StartCoroutine(Spawn());
        }

    }

    public void Respawn() {
        StartCoroutine(Spawn());
        isBossTime = false;
    }

    public void CreateBoss() {
        isBossTime = true;
        Instantiate(bossPrefab, transform.position, bossPrefab.transform.rotation);
    }
}
