using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

	public GameObject scoreText = null;
	private int points = 0;

	void Start () {
		points = 0;
		scoreText.GetComponent<TextMesh> ().text = points.ToString();
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Torus")
		{
			points += 10;
			scoreText.GetComponent<TextMesh>().text = points.ToString();
		}
	}
}
