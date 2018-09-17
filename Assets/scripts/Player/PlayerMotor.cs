using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam; //a reference to the Camera object attached to this gameobject.

    [SerializeField] //serialzefield lets us see private variables in the inspector
    private Rigidbody rb; //creating a rigidbody variable called 'rb'

    [SerializeField] //serialzefield lets us see private variables in the inspector
    private Vector3 velocity = Vector3.zero; //so we are going to store the _velocity from PlayerController as 'velocity' in this script

    [SerializeField] //serialzefield lets us see private variables in the inspector
    private Vector3 rotation = Vector3.zero; //so we are going to store the _rotation from PlayerContorller as 'rotation' in this script

    [SerializeField] //serialzefield lets us see private variables in the inspector
    private Vector3 camRotation = Vector3.zero; //so we are going to store the _rotation from PlayerContorller as 'rotation' in this script

    [SerializeField]
    private float jumpForce; //amount of energy for intial jump

    [SerializeField]
    private float doubleJumpForce; //amount of energy for a double jump

    [SerializeField]
    private bool grounded; //tells us whether we are touching the floor or not

    [SerializeField]
    private bool canDoubleJump; //tells us whether we can jump again while in the air



    





    private void Start()
    {
        rb = GetComponent<Rigidbody>();//here we actually tell unity that rb is the rigidbody attached to this object
        
    }



    public void CollectVelocityFromPlayerController(Vector3 _velocity)
    {
        velocity = _velocity; //we are taking that _velocity vector from PlayerController (see above) and we are calling it "velocity" so it does not have the same name as _velocity.
    }



    public void CollectRotationFromPlayerController(Vector3 _rotation)
    {
        rotation = _rotation; //we are taking that _rotation vector from PlayerController (see above) and we are calling it "rotation" so it does not have the same name as _rotation.
    }

    public void CameraRotation(Vector3 _camRotation)
    {
        camRotation = _camRotation; //we are taking that _camRotation vector from PlayerController (see above) and we are calling it "rotation" so it does not have the same name as _camRotation.
    }
    public void CollectJumpForceFromPlayerController(float _jumpForce, float _doubleJumpForce)
    {
        jumpForce = _jumpForce;
        doubleJumpForce = _doubleJumpForce;

        PerformJump();
    }

	

	void FixedUpdate ()
    {
        PerformMovement(); //calling PerformMovement in fixed because any physics calls should always be done in FixedUpdate
        PerformRotation(); //calling PerformRotation in FixedUpdate because any physics calls should always be done in FixedUpdate
        Debug.Log("Grounded = " + grounded);
	}

    void PerformMovement()
    {
        if (velocity != Vector3.zero) //if our velocity is not 0 (aka we are pushing something on our controller to make him move)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //we are taking his current position and adding it to the velocity
        }
        
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation)); //take the player's current rigidbody rotation and multiply it by rotation
        if (cam != null)
        {
           
            cam.transform.Rotate(camRotation); //rotate the camera to match camRotation.
            
            //Debug.Log("CamRotation Value = " + camRotation);
        }
    }

    void PerformJump()
    {
        if (grounded)
        {
            rb.AddForce((transform.up * jumpForce));
        }

        if (!grounded)
        {
            if (canDoubleJump == true)
            {
                rb.AddForce((transform.up * jumpForce));
                canDoubleJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = true;
            canDoubleJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            grounded = false;
        }



    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "ground")
        {
            transform.parent = collision.gameObject.transform.parent; //become a child of collision's parent.

        }

    }


}

