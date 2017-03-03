using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statDisplay2 : MonoBehaviour {
    public Text thisText;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        thisText.text = "Slow Time Capacity: " + string.Format("{0:0.0}", player.GetComponent<playerMovement>().slowTimeCap);
	}
}
