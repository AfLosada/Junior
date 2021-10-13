using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float spawnRange = 15;
    public float spawnRate = 1.5f;


    public GameObject[] prefabArray;
    private bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnBalls());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPostX = Random.Range(-spawnRange, spawnRange);
        float spawnPostZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPostX, 0.8f, spawnPostZ);
        return randomPos;
    }

    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, prefabArray.Length);
            Vector3 spawnPos = GenerateSpawnPosition();
            Instantiate(prefabArray[index], spawnPos, new Quaternion(0,0,0,0));
        }
    }

}
