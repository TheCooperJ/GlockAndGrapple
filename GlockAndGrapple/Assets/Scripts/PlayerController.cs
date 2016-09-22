using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 500;

    public float distToGround;
    public float maxGroundDist = 0.85f;
    public float groundSphereCastSize = 0.25f;
    public bool isGrounded;

    public RaycastHit groundHit;
    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        GetInput ();

        GroundDetection ();

        //StandUpright ();
	}

    void GetInput ()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            rb.AddForce(transform.right * moveSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        }
    }

    void GroundDetection ()
    {
        if (Physics.SphereCast(transform.position, groundSphereCastSize, -transform.up, out groundHit))
        {
            distToGround = groundHit.distance;
        }
        if (groundHit.distance < maxGroundDist && groundHit.collider != null)
            isGrounded = true;
        else
            isGrounded = false;
        if (groundHit.collider == null)
            isGrounded = false;
    }

    //void StandUpright ()
    //{
    //    if (isGrounded)
    //    {
    //        rb.constraints = RigidbodyConstraints.None;
    //        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    //    }
    //    else
    //    {
    //        rb.constraints = RigidbodyConstraints.None;
    //        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    //    }
    //}
}
