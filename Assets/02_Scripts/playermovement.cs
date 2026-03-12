using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody _rb;
    private Vector3 _left = Vector3.forward * 5;
    private Vector3 _right = Vector3.back * 5;
    
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
