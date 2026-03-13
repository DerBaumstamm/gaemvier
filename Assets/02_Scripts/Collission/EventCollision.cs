using System;
using UnityEngine;
using UnityEngine.Events;
public class EventCollision : MonoBehaviour
{
    public event Action OnEnemyCollision;
    public event Action<string, int> OnGateCollision;

    private void OnTriggerEnter(Collider collision)
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
        else
        {
            // Viele Gate-Prefabs triggern ueber Child-Collider; daher GateInfo robust im Hierarchiebaum suchen.
            GateInfo gateInfo = collision.gameObject.GetComponent<GateInfo>()
                                ?? collision.gameObject.GetComponentInParent<GateInfo>();

            if (gateInfo == null) return;

            OnGateCollision?.Invoke(gateInfo.op, gateInfo.value);
            Debug.Log($"Gate-Event gesendet: {gateInfo.op}{gateInfo.value}");
        }

    }
}