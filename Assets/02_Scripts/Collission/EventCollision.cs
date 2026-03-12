using System;
using UnityEngine;
using UnityEngine.Events;
public class EventCollision : MonoBehaviour
{
    public event Action OnEnemyCollision;
    public event Action OnGateCollision;
    private void OnCollisionEnter(Collision collision)
    {
        print($"Collision detected with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemyData = collision.gameObject.GetComponent<Enemy>();
            int index = enemyData.enemyIndex;
        
            Debug.Log($"Enemy Index: {index}");
            OnEnemyCollision?.Invoke();
            Debug.Log("Spieler hat Enemy getroffen!");
        }
        else if (collision.gameObject.CompareTag("Gate"))
        {
            OnGateCollision?.Invoke();
            Debug.Log("Spieler hat Gate getroffen!");
        }

    }
}