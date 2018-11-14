using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayakSailingScript : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}