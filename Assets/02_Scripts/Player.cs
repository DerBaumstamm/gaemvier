using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int troopCount = 1;

    public GameObject Prefab => prefab;

    public int TroopCount
    {
        get => troopCount;
        set => troopCount = Mathf.Max(0, value);
    }
}


