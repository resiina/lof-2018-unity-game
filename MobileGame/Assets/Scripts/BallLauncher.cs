using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {

    public float launchVelocity = 30.0f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(0.0f, launchVelocity, 0.0f, ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
