using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statDisplay : MonoBehaviour {
    public Text uiDisp;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        uiDisp.text = "Health: " + playerMovement.health.ToString() + "\nRegen Timer: " + string.Format("{0:0.0}", player.GetComponent<playerMovement>().regenTimer);

	}
}
