using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public UnityEvent<int> onHealthChanged;
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] public int health = 10;

    void Awake()
    {
        onHealthChanged = new UnityEvent<int>();
        CreateUI();
        onHealthChanged.Invoke(health);
    }

    private void CreateUI()
    {
        if (uiPrefab != null)
        {
            Instantiate(uiPrefab, transform);
        }
    }

}
