using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlController : MonoBehaviour
{
    [SerializeField] float speed = 5;

    private Rigidbody rb;
    private Vector3 Direction { get; set; }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal"); float z = Input.GetAxis("Vertical");
        Direction = new Vector3(x,0,z).normalized; 
        
        if(Direction.sqrMagnitude > 0.05f) transform.forward = Vector3.Slerp(transform.forward,Direction,(speed/1.25f) * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Direction * (speed * Time.fixedDeltaTime));
    }
}
