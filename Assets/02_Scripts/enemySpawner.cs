using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject groundPlane;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject gates;
    [SerializeField] private float spawnDelayEnemy = 3f;
    [SerializeField] private float spawnDelayGate = 7f;
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
            yield return new WaitForSeconds(spawnDelayEnemy);
            SpawnGates();
            yield return new WaitForSeconds(spawnDelayGate);
        }
    }
    
    
    
    
    
    void SpawnEnemies()
    {
        Renderer ren = groundPlane.GetComponent<Renderer>();
        width = ren.bounds.size.z;
        int randomEnemyIndex = Random.Range(0, enemies.Length);
        GameObject enemyPrefab = enemies[randomEnemyIndex];
        enemyPrefab.tag = "Enemy";
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

    void SpawnGates()
    {
        Renderer rendererGate = groundPlane.GetComponent<Renderer>();
        width = rendererGate.bounds.size.z;
      
        float groundZ = groundPlane.transform.position.z;
        float groundY = groundPlane.transform.position.y;
        float groundX = groundPlane.transform.position.x;
        
        float gateOffset = width / 4f;
        Quaternion gateRotation = Quaternion.Euler(0, 90, 0);


        Vector3 leftGatePos = new Vector3(groundX, 5, groundZ - gateOffset);
        GameObject leftGate = Instantiate(gates, leftGatePos, gateRotation);
        leftGate.tag = "Gate";
        if (!leftGate.GetComponent<Rigidbody>())
            leftGate.AddComponent<Rigidbody>();

        // Rechtes Gate
        Vector3 rightGatePos = new Vector3(groundX, 5, groundZ + gateOffset);
        GameObject rightGate = Instantiate(gates, rightGatePos, gateRotation);
        rightGate.tag = "Gate";
        if (!rightGate.GetComponent<Rigidbody>())
            rightGate.AddComponent<Rigidbody>();
        
    }
    
}
