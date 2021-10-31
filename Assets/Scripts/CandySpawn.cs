using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawn : MonoBehaviour
{[SerializeField]
    GameObject[] candies;
    [SerializeField]
    float maxX;
    [SerializeField]
    float spawninter;
    public static CandySpawn instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCandy();
        Startspawn();
    }

    void SpawnCandy()
    {
        int rand = Random.Range(0, candies.Length);
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(candies[rand], randomPos, transform.rotation);

    }
    IEnumerator Cans()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawninter);

        }
    }
    public void Startspawn()
    {
        StartCoroutine("Cans");
    }
    public void Stopspawn()
    {
        StopCoroutine("Cans");

    }
}
