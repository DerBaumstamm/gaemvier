using UnityEngine;
using UnityEngine.Events;

public class TestPlayer : MonoBehaviour
{
    public UnityEvent<int> onScoreChanged;
    [SerializeField] private GameObject uiPrefab;
    private float interval = 2f;
    private float timer;
    void Awake()
    {
        onScoreChanged = new UnityEvent<int>();
        CreateUI();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            int randomScore = Random.Range(1, 101);
            Debug.Log($"Score changed: {randomScore}");
            onScoreChanged?.Invoke(randomScore);
            timer = 0f;
        }
    }

    private void CreateUI()
    {
        if (uiPrefab != null)
        {
            Instantiate(uiPrefab, transform);
        }
    }
}