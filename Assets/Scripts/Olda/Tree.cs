using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {


	[SerializeField] int growIndex = 1;

	[SerializeField] GameObject[] trees = new GameObject[2];


	[SerializeField] int countKick = 5;

	[SerializeField] GameObject log;

	public float timer = 0;
	int stepGrow = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (growIndex < 3) {
			timer += Time.deltaTime;
			if (timer > stepGrow) {
				Destroy (gameObject);
				Instantiate (trees [growIndex - 1], transform.position, Quaternion.identity).transform.parent = transform.parent;

			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.CompareTag ("AXE") && growIndex == 3 && countKick > 0 ) {
			GetComponent<Animator> ().SetTrigger ("Chop");
			countKick--;
			if (countKick <= 0) {
				GetComponent<Animator> ().SetTrigger ("Fall");
				StartCoroutine (SpawnLogs());
				FindObjectOfType<SpawnTrees> ().countTree--;
			}
		}
	}

	IEnumerator SpawnLogs(){
		yield return new WaitForSeconds (0.9f);
		for (int i = 0; i < 3; i++) {
			yield return new WaitForSeconds (0.3f);
			Instantiate (log, transform.position, Quaternion.Euler (0, 0, 90));
		}
		Destroy (gameObject);
	}


}
