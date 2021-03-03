using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigitbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigitbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
            rigitbodyComponent.velocity = new Vector3(horizontalInput, rigitbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
    
        if (jumpKeyWasPressed == true)
        {
            rigitbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }
    
     
}
