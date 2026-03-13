using UnityEngine;
using UnityEngine.SceneManagement;

public class Multiplikator : MonoBehaviour
{
    [SerializeField] private EventCollision eventCollision;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    //[SerializeField] private GateEventPublisher publisher;
    [SerializeField] private int troopCount = 10;

    public int TroopCount => troopCount;
    
    private void OnEnable()
    {
        if (eventCollision == null) return;
        eventCollision.OnGateCollision += HandleGateCollision;
        eventCollision.OnEnemyCollision += HandleEnemyCollision;
    }

    private void HandleGateCollision()
    {
        Debug.Log("Gate collision detected. Increasing troop count.");
        player.TroopCount += 1;
        Debug.Log("troop count: " + player.TroopCount);
    }

    private void HandleEnemyCollision()
    {
        print($"Player: {player.TroopCount}, Enemy: {enemy.TroopCount}");
        if (enemy.TroopCount > player.TroopCount)
        {
            SceneManager.LoadScene("01_Scenes/GameOver");
        }
        else
        {
            //yanniks Kochung
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null) rb.linearVelocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, -100f, transform.position.z);
        }
    }

    private void OnDisable()
    {
        if (eventCollision != null)
        {
            eventCollision.OnGateCollision -= HandleGateCollision;
            eventCollision.OnEnemyCollision -= HandleEnemyCollision;
        }
    }

    private void OnGateEnter(int value)
    {
        troopCount += value;
    }
    
}
