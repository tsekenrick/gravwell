using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showHighScore : MonoBehaviour {
    public Text thisText;
	// Use this for initialization
	void Start () {
        thisText.text += "\n High Score:" + playerMovement.highScore;
    }
	
	// Update is called once per frame
	void Update () {
       

    }
}
