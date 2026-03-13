using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private TextMeshPro tmpro;

    void Awake()
    {
        tmpro = GetComponent<TextMeshPro>();
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
        tmpro.text = health.ToString();
    }
}