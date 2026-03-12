using UnityEngine;

public class playermovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 left = Vector3.left;
    private Vector3 right = Vector3.right;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        { 
            rb.AddForce(left);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(right);
        }
    }
}
