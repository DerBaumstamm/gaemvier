using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public UnityEvent<int> onHealthChanged;
    [SerializeField] private GameObject uiPrefab;
    [SerializeField] private int troopCount = 5;


    public int TroopCount
    {
        get => troopCount;
        set
        {
            if (troopCount != value)
            {
                troopCount = value;
                onHealthChanged?.Invoke(troopCount);
            }
        }
    }

    void Awake()
    {
        onHealthChanged = new UnityEvent<int>();
        CreateUI();
        uiPrefab.transform.rotation = Quaternion.Euler(0, -90f, 0);
        onHealthChanged.Invoke(troopCount);
    }

    private void CreateUI()
    {
        if (uiPrefab != null)
        {
            Instantiate(uiPrefab, transform);
        }
    }
}