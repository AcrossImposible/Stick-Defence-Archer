using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 300);
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate (FindObjectOfType<Player> ().transform.position);
	}
}
