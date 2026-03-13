using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Multiplikator : MonoBehaviour
{
    [SerializeField] private EventCollision eventCollision;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    //[SerializeField] private GateEventPublisher publisher;
    [SerializeField] private int troopCount = 10;
    [SerializeField] private TextMeshPro troopCountText;

    public int TroopCount => player != null ? player.TroopCount : troopCount;

    private void Awake()
    {
        if (eventCollision == null)
        {
            eventCollision = GetComponent<EventCollision>();
        }

        if (player == null)
        {
            player = GetComponent<Player>();
        }

        if (player != null)
        {
            troopCount = player.TroopCount;
        }
        troopCountText = GetComponentInChildren<TextMeshPro>();
        troopCountText.text = troopCount.ToString();
    }

    private void OnEnable()
    {
        if (eventCollision == null)
        {
            Debug.LogWarning("EventCollision ist nicht gesetzt, Gate-/Enemy-Events werden nicht abonniert.");
            return;
        }

        eventCollision.OnGateCollision += HandleGateCollision;
        eventCollision.OnEnemyCollision += HandleEnemyCollision;
        Debug.Log("Multiplikator hat Gate-/Enemy-Events abonniert.");
    }

    public void HandleGateCollision(string op, int value)
    {
        if (player == null)
        {
            Debug.LogWarning("Kein Player in Multiplikator gesetzt.");
            return;
        }

        int currentTroops = player.TroopCount;

        switch (op)
        {
            case "+":
                player.TroopCount = currentTroops + value;
                Debug.LogWarning(player.TroopCount);
                break;
            case "-":
                player.TroopCount = currentTroops - value;
                Debug.LogWarning(player.TroopCount);

                break;
            case "x":
            case "*":
                player.TroopCount = currentTroops * value;
                Debug.LogWarning(player.TroopCount);

                break;
            case "/":
                if (value == 0)
                {
                    Debug.LogWarning("Gate-Operation '/' mit Value 0 ignoriert.");
                    return;
                }
                player.TroopCount = currentTroops / value;
                Debug.LogWarning(player.TroopCount);

                break;
            default:
                Debug.LogWarning($"Unbekannter Gate-Operator '{op}'.");
                return;
        }

        troopCount = player.TroopCount;
        troopCountText.text = troopCount.ToString();
        Debug.Log($"Gate collision detected. {currentTroops} {op} {value} = {player.TroopCount}");
    }

    private void HandleEnemyCollision()
    {
        troopCountText.text = troopCount.ToString();
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
}
