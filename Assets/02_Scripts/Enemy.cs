using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int troopCount = 5;

    public int TroopCount
    {
        get => troopCount;
        set => troopCount = value;
    }

    
    
    public int enemyIndex;
}




