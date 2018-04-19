using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRotator : MonoBehaviour {

    public float flipperVelocity = 20.0f;
    public float angleHighLimit = 270.0f;
    public float angleLowLimit = 315.0f;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 1000.0f;
        rigidbody.centerOfMass = new Vector3(0.0f, 0.0f, 0.0f);
    }
	
	// Update is called once per frame
	void Update()
    {
        float angle = rigidbody.rotation.eulerAngles.z;
        
        if (name == "Left flipper")
        {
            if (angle <= angleHighLimit)
            {
                // Don't allow control, just turn back
                rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, flipperVelocity);
            }
            else
            {
                // Allow control
                bool leftKeyHit = false;

#if UNITY_EDITOR
                if (Input.GetKey("left"))
                {
                    leftKeyHit = true;
                }
#else
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x < Screen.width / 2)
                    {
                        leftKeyHit = true;
                    }
                }
#endif
                if (leftKeyHit)
                {
                    rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, -flipperVelocity);
                }
                else if (angle >= angleLowLimit)
                {
                    // Stop the flipper if at the original position
                    rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, angleLowLimit);
                    rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
        
        if (name == "Right flipper")
        {
            if (angle <= angleHighLimit)
            {
                // Don't allow control, just turn back
                rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, -flipperVelocity);
            }
            else
            {
                // Allow control
                bool rightKeyHit = false;

#if UNITY_EDITOR
                if (Input.GetKey("right"))
                {
                    rightKeyHit = true;
                }
#else
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x > Screen.width / 2)
                    {
                        rightKeyHit = true;
                    }
                }
#endif
                if (rightKeyHit)
                {
                    rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, flipperVelocity);
                }
                else if (angle >= angleLowLimit)
                {
                    // Stop the flipper if at the original position
                    rigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                }
            }
        }
    }
}
