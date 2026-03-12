using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;
    private TestPlayer player;

    void Awake()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
        player = GetComponentInParent<TestPlayer>();
    }

    private void OnEnable()
    {
        player?.onScoreChanged.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        player?.onScoreChanged.RemoveListener(UpdateScore);
    }

    private void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}