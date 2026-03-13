using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int troopCount = 1;

    public int TroopCount
    {
        get => troopCount;
        set => troopCount = Mathf.Max(0, value);
    }
}

