using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;

    // Update is called once per frame
void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
    }
}
