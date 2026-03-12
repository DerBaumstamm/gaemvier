using UnityEngine;

public class targetplayer : MonoBehaviour
{
    private static Transform cachedPlayer; 

    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float maxDist = 1000f;
    [SerializeField] private float minDist = 1f;

    private void Awake()
    {
        TryAssignPlayer();
    }

    private void Update()
    {
        if (Time.frameCount % 30 == 0)
            TryAssignPlayer();

        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= maxDist && distance > minDist)
        {
            transform.LookAt(player);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        
    }

    private void TryAssignPlayer()
    {
        if (cachedPlayer == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if (p != null) cachedPlayer = p.transform;
        }

        player = cachedPlayer;
    }
}

