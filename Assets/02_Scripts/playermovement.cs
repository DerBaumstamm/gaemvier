using UnityEngine;

public class playermovement : MonoBehaviour
{

    private Rigidbody _rb;
    private Vector3 _left = Vector3.left;
    private Vector3 _right = Vector3.right;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        { 
            _rb.AddForce(_left);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            _rb.AddForce(_right);
        }
    }
}
