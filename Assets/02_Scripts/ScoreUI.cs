using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Enemy enemy;

    void Awake()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnEnable()
    {
        enemy?.onHealthChanged.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        enemy?.onHealthChanged.RemoveListener(UpdateScore);
    }

    private void UpdateScore(int health)
    {
        scoreText.text = health.ToString();
    }
}