using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPlane;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float spawnDelay = 3f;
    [SerializeField] private float spawnHeight = 1.5f;
    
    private float width;

// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }
    
    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    
    // Update is called once per frame
    
    void SpawnEnemies()
    {
        Renderer ren = groundPlane.GetComponent<Renderer>();
        width = ren.bounds.size.z;
        int randomEnemyIndex = Random.Range(0, enemies.Length);
        GameObject enemyPrefab = enemies[randomEnemyIndex];
        float x = groundPlane.transform.position.x;
        float y = spawnHeight;
        float minZ = groundPlane.transform.position.z - width / 2;
        float maxZ = groundPlane.transform.position.z + width / 2;
        float randomZ = Random.Range(minZ, maxZ);
        
        Vector3 spawnPosition = new Vector3(x, spawnHeight, randomZ);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        if(spawnedEnemy.GetComponent<Rigidbody>() == null)
        {
            spawnedEnemy.AddComponent<Rigidbody>();
        }
    }
    
}
