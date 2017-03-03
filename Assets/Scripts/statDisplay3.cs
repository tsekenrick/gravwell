using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statDisplay3 : MonoBehaviour {
    public Text thisText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        thisText.text = "Score: " + playerMovement.score;
	}
}
