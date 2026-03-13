using System;
using UnityEngine;
using UnityEngine.Events;

public class EventCollision : MonoBehaviour
{
    public event Action OnEnemyCollision;
    public event Action OnGateCollision;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            OnGateCollision?.Invoke();
            Debug.Log("Spieler hat Gate getroffen!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"Collision detected with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyData = collision.gameObject.GetComponent<Enemy>();
            int health = enemyData.health;

            Debug.Log($"Enemy health: {health}");
            OnEnemyCollision?.Invoke();
            Debug.Log("Spieler hat Enemy getroffen!");
        }
        
    }
}