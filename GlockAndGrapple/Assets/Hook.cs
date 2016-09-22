using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other != null && other.tag != "Player")
        {
            rb.isKinematic = true;
        }
    }
}
