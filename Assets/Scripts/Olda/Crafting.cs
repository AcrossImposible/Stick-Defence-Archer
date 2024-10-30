using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour {

	[SerializeField] Text txtCountBoards;
	[SerializeField] Text txtCountLogs;
	[SerializeField] Text txtCountSticks;
	[SerializeField] Text txtCountStrela_1;
	[SerializeField] Text txtCountStrela_2;
	[SerializeField] GameObject panelCrafting;

	Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory = FindObjectOfType<Inventory> ();
		panelCrafting.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
}
