using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorialDisplay : MonoBehaviour {
    public Text tutorial;
    public float displayTime;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        displayTime += Time.deltaTime;

        if (displayTime > 13.3f)
        {
            tutorial.text = "That's all! Press [SPACE] to start!";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
        else if (displayTime < 3.3f)
        {
            tutorial.text = "Oh no! You fell into a bottomless pit where the ground has gravity warping properties!";
        }
        else if (displayTime < 6.6f)
        {
            tutorial.text = "Avoid landing by strafing with [A] and [D], and try to fall as long as possible!";
        }
        else if (displayTime < 10f)
        {
            tutorial.text = "You can occasionally slow time by pressing [SPACE], but your magic resources are limited!"; 
        }
        else if (displayTime < 13.3f)
        {
            tutorial.text = "If you avoid the walls for 5 seconds, you regenerate a point of lost health!"; ;
        }
	
	}
}
