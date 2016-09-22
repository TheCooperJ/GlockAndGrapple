using UnityEngine;
using System.Collections;

public class GrapplingGun : MonoBehaviour {

    public Rigidbody hookRb;

    private Vector3 mousePos;
    private Vector3 mouseWorldPos;
    private Vector3 aimDir;
    private Ray mouseRay;
    private RaycastHit mouseRayHit;
    public float range;

    private LineRenderer rope;
	
    void Start ()
    {
        rope = GetComponent<LineRenderer>();
    }

	void Update ()
    {
        GetInput ();

        Rope ();
	}

    void GetInput ()
    {
        GetAimVector();

        if (Input.GetButtonDown ("Fire1"))
        {
            Fire ();
        }
    }

    void Fire ()
    {
        hookRb.isKinematic = false;
        hookRb.MovePosition(transform.position);
        hookRb.velocity = Vector3.zero;

        hookRb.AddForce((transform.position - mouseWorldPos).normalized * -range);
    }

    void GetAimVector ()
    {
        mousePos = Input.mousePosition;

        mouseRay = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(mouseRay, out mouseRayHit))
        {
            mouseWorldPos = mouseRayHit.point;
        }
    }

    void Rope ()
    {
        rope.SetPosition(0, transform.position);
        rope.SetPosition(1, hookRb.position);
    }
}
