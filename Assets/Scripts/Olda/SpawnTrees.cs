using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour {

	[SerializeField] GameObject tree;
	public int countTree = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn(){
		while (true) {
			yield return new WaitForSeconds (Random.Range(4,8)); // 8 15
			if (countTree < 18) {
				float posX = Random.Range (-8, 8) + Random.Range (-0.3f, 0.3f);
				Instantiate (tree, transform).transform.localPosition = new Vector3 (posX, -2.9f, 3);
				countTree++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
