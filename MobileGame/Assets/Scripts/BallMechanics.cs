using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanics : MonoBehaviour {

    public float launchVelocity = 30.0f;

    struct gameColliderObject
    {
        public string name;
        public float bounce;
        public int score;
    }
    private int points = 0;
    public GameObject scoreText = null;
    List<gameColliderObject> collider_objects;

	// Use this for initialization
	void Start ()
    {
        
        points = 0;
        scoreText.GetComponent<TextMesh>().text = points.ToString();
        collider_objects = new List<gameColliderObject>();
        GetComponent<Rigidbody>().AddForce(0.0f, launchVelocity, 0.0f, ForceMode.VelocityChange);
        collider_objects.Add(new gameColliderObject { name = "Torus", bounce = 13.0f, score = 10 });
        collider_objects.Add(new gameColliderObject { name = "flipper", bounce = 28.0f, score = 0 });
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Destroy(collision.gameObject);
        int i = 0;
        for (i=0; i < collider_objects.Count; i++)
        {

            if (collision.gameObject.name.Contains(collider_objects[i].name))
            {
                points += collider_objects[i].score;
                scoreText.GetComponent<TextMesh>().text = points.ToString();
                GetComponent<Rigidbody>().AddForce(0.0f, collider_objects[i].bounce, 0.0f, ForceMode.VelocityChange);
                GetComponent<Rigidbody>().velocity = Vector3.Reflect(GetComponent<Rigidbody>().velocity, collision.contacts[0].normal);

            }

        }


    }

}
