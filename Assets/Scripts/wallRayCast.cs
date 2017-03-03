using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRayCast : MonoBehaviour
{
    RaycastHit2D hit;
    public GameObject wallGen;
    public float distBetween;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("player");
        wallGen = GameObject.Find("wallGenLeft");
        /*RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x + .55f, transform.position.y, transform.position.z), Vector2.right, 100f);
        if (hit)
        {
            distBetween = hit.distance;
        }

        else if (distBetween <= 3f)
        {
            float j = Random.value;

            if (j <= .7f)
            {
                wallGen.GetComponent<wallGen>().xVar = -1;
            }
            else
            {
                wallGen.GetComponent<wallGen>().xVar = 1;
            }
        }

        else if (distBetween <= 2f)
        {
            wallGen.GetComponent<wallGen>().xVar = -1;
        }

        else if (transform.position.x <= -6.5f)
        {
            wallGen.GetComponent<wallGen>().xVar = 1;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < transform.position.y - 35f)
        {
            Destroy(this.gameObject);
        }
    }
}
