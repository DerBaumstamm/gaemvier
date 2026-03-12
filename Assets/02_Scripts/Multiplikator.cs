using UnityEngine;

public class Multiplikator : MonoBehaviour
{
    [SerializeField] private GateEventPublisher publisher;
    [SerializeField] private int troopCount = 1;

    [Header("Enemy Scaling")]
    [SerializeField] private int currentEnemyTroopCount = 5;
    [SerializeField] private int enemyIncreasePerSpawn = 5;

    public int TroopCount => troopCount;
    public int CurrentEnemyTroopCount => currentEnemyTroopCount;

    private void OnEnable()
    {
        if (publisher != null)
        {
            publisher.OnPlayerPassedGate += OnGateEnter;
        }
    }

    private void OnDisable()
    {
        if (publisher != null)
        {
            publisher.OnPlayerPassedGate -= OnGateEnter;
        }
    }

    private void OnGateEnter(int value)
    {
        troopCount += value;
    }

    public int GetNextEnemyTroopCount()
    {
        int troopAmountToSpawn = currentEnemyTroopCount;
        currentEnemyTroopCount += enemyIncreasePerSpawn;
        return troopAmountToSpawn;
    }

    public void ResetEnemyTroopCount(int newAmount)
    {
        currentEnemyTroopCount = newAmount;
    }
}
