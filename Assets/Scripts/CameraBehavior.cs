using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
    public GameObject player;
    public static int cameraScroll = 10;
    Vector3 playerPos;
    Vector3 cameraPos;
    public bool following;
    public Vector3 delta;
    // Use this for initialization
    void Start () {
        following = false;
	}
	
	// Update is called once per frame
	void Update () {

        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, transform.position.z);
        cameraPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Vector3 delta = playerPos - cameraPos;
        float moveX = 0;
        float moveY = 30;
        /*if (Mathf.Abs(delta.x) > 1.35f)
        {
            if (delta.x > 0) moveX = delta.x - 1.20f; //zero until the camera moves outside the window  
            else moveX = delta.x + 1.20f; //zero until the camera moves outside the window  
        }*/

        
        if (delta.y > -3f && delta.y < 3f)
        {
            following = true;
            moveY = delta.y;
            transform.position = Vector3.Lerp(cameraPos, cameraPos + new Vector3(moveX, moveY-1, 0), 1f);
        }
        else
        {
            following = false;
            moveY = delta.y;
            transform.position = Vector3.Lerp(cameraPos, cameraPos + new Vector3(moveX, moveY, 0), .9f);
            //transform.position = new Vector3(cameraPos.x, cameraPos.y - moveY*Time.deltaTime, cameraPos.z);
        }
        


        



        transform.rotation = Quaternion.identity;
        /*if (player.transform.position.y < transform.position.y)
        {
            this.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + cameraScroll * Time.deltaTime, transform.position.z);
        }*/
	}
}
