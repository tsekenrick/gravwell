using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {
    
    public bool inAir;
    public bool canHurt;
    public float gravIncrement;
    public static int health = 5;
    public float regenTimer;
    public float moveSpeed;
    public float friction;
    public float drag;
    public static int score;
    public static int highScore;
    Rigidbody2D rb;
    public bool timeSlowed;

    public float slowTimeCap;

    AudioSource[] mySources;
	// Use this for initialization
	void Start () {
        timeSlowed = false;
        inAir = true;
        canHurt = true;
        rb = GetComponent<Rigidbody2D>();
        regenTimer = 5f;
        playerMovement.health = 5;
        Physics2D.gravity = new Vector2(0, -60);
        friction = 2f;
        gravIncrement = 15f;
	}

    // Update is called once per frame
    void Update() {
        AudioSource[] mySources = GetComponents<AudioSource>();
        playerMovement.score = Mathf.Abs((int)transform.position.y * 93);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        //if (rb.velocity.y >= 5f) inAir = true;



        if (inAir)
        {
            regenTimer -= Time.deltaTime;
        }

        if (inAir == false)
        {
            regenTimer = 5;
        }
        else if (regenTimer <= 0)
        {            
            if(health < 5)
            {
                playerMovement.health++;
                mySources[1].Play();
            }
            regenTimer = 5;
        }

        if (health <= 0)
        {
            if (playerMovement.score > playerMovement.highScore)
            {
                playerMovement.highScore = playerMovement.score;
            }
            SceneManager.LoadScene(2);
        }


		if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space) && slowTimeCap >= 0f)
        {
            
            Time.timeScale = .65f;
            Debug.Log(Time.timeScale);
            slowTimeCap -= Time.deltaTime * 5;
            timeSlowed = true;
        } else
        {
            Time.timeScale = 1f;
            timeSlowed = false;
            if (slowTimeCap < 5f) slowTimeCap += Time.deltaTime;
        }        

        if (inAir == false)
        {   
            if (Physics2D.gravity.y < -200)
            {
                moveSpeed = 8000;
            }
            else if (Physics2D.gravity.y < -150)
            {
                moveSpeed = 7500;
            }
            else if (Physics2D.gravity.y < -100)
            {
                moveSpeed = 4500;
            }
            
            //apply friction
            //rb.AddForce(friction * rb.velocity.normalized * rb.velocity.sqrMagnitude); //this force increases as the rigidbody moves faster while not in the air

        }

        if (inAir)
        {
            moveSpeed = 1500;
            //apply drag           
            rb.AddForce(drag * rb.velocity.normalized * rb.velocity.sqrMagnitude); //this force increases as the rigidbody moves faster while in the air

        }
    }

    void OnCollisionEnter2D (Collision2D coll)
    {
        inAir = false;
        AudioSource[] mySources = GetComponents<AudioSource>();
        if (coll.gameObject.tag == "capper" && canHurt)
        {
            mySources[0].Play();
            Debug.Log("i've been hit!");
            inAir = false;
            health--;
            if (friction >= .05f) friction -= .25f;
            if (Physics2D.gravity.y > -200f)
            {
                Physics2D.gravity = new Vector2(0f, Physics2D.gravity.y - gravIncrement);
                gravIncrement += 15;
            }
            
            StartCoroutine(hurtFlash());
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "capper")
        {
            inAir = true;
            
        }
    }

    public IEnumerator hurtFlash()
    {
        canHurt = false;
        GameObject playerBody = GameObject.Find("player");
        Color originalColor = GetComponent<Renderer>().material.color;
        playerBody.GetComponent<Renderer>().material.color = Color.clear;
        yield return new WaitForSeconds(.33f);
        playerBody.GetComponent<Renderer>().material.color = originalColor;
        yield return new WaitForSeconds(.33f);
        playerBody.GetComponent<Renderer>().material.color = Color.clear;
        yield return new WaitForSeconds(.33f);
        playerBody.GetComponent<Renderer>().material.color = originalColor;
        yield return new WaitForSeconds(.33f);
        playerBody.GetComponent<Renderer>().material.color = Color.clear;
        yield return new WaitForSeconds(.33f);
        playerBody.GetComponent<Renderer>().material.color = originalColor;
        yield return new WaitForSeconds(.33f);
        canHurt = true;
    }
}
