using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallGen : MonoBehaviour
{
    public GameObject wall;
    public Vector3 genPoint;
    public float distBetween;
    float nextWallHeight;

    float wallHeight;

    float yAtSpawn;

    float lastxVar;
    public float xVar;
    public float distTo;
    public bool canGen;

    public float midPoint;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("generation", 3f, 8f);
        midPoint = 0;
        genPoint = transform.position;
        nextWallHeight = 0;
        //nextWallWidth = wall.transform.localScale.x;
        for (int i = 0; i < 500; i++)
        {
            wallHeight = nextWallHeight; 
            wall.transform.localScale = new Vector3(transform.localScale.x, wallHeight, transform.localScale.z);
            GameObject lastBlock = Instantiate(wall, genPoint, transform.rotation);
            yAtSpawn = genPoint.y;
            wallHeight = wall.transform.localScale.y;
            nextWallHeight = Random.Range(1, 5);

            
            lastxVar = xVar;

            if (lastBlock.transform.position.x > midPoint - 3) //guarantees walls never intersect
            {
                xVar = -1;
            }
            else if (lastBlock.transform.position.x > midPoint - 5) //inverse of above weighting
            {
                float j = Random.value;

                if (j < .65f)
                {
                    xVar = -1;
                }
                else
                {
                    xVar = 1;
                }
            }
            else if (lastBlock.transform.position.x < midPoint - 8) //ensures that walls never go beyond camera view
            {
                xVar = 1;
            }
            else if (lastBlock.transform.position.x < midPoint - 5) //begins weighting towards moving to stay within camera view
            {
                float j = Random.value;

                if (j < .65f)
                {
                    xVar = 1;
                }
                else
                {
                    xVar = -1;
                }

            }            
            else
            {
                xVar = Random.Range(-1, 2);
            }
            
            genPoint = new Vector3(genPoint.x + xVar, yAtSpawn - 0.5f * (wallHeight + nextWallHeight), genPoint.z);
            midPoint = Random.Range(-2, 3);
        }


    }

    void Update()
    {
    
    }

    //TextAsset var = Resources.Load<TextAsset>("file_path/filename");

    void generation()
    {

        midPoint = 0;
        //nextWallWidth = wall.transform.localScale.x;
        for (int i = 0; i < 75; i++)
        {
            wallHeight = nextWallHeight;
            wall.transform.localScale = new Vector3(transform.localScale.x, wallHeight, transform.localScale.z);
            GameObject lastBlock = Instantiate(wall, genPoint, transform.rotation);
            yAtSpawn = genPoint.y;
            wallHeight = wall.transform.localScale.y;
            //nextWallHeight = Random.Range(1, 5);


            lastxVar = xVar;

            if (lastBlock.transform.position.x > midPoint - 3) //guarantees walls never intersect
            {
                xVar = -1;
            }
            else if (lastBlock.transform.position.x > midPoint - 5) //inverse of above weighting
            {
                float j = Random.value;

                if (j < .65f)
                {
                    xVar = -1;
                }
                else
                {
                    xVar = 1;
                }
            }
            else if (lastBlock.transform.position.x < midPoint - 8) //ensures that walls never go beyond camera view
            {
                xVar = 1;
            }
            else if (lastBlock.transform.position.x < midPoint - 5) //begins weighting towards moving to stay within camera view
            {
                float j = Random.value;

                if (j < .65f)
                {
                    xVar = 1;
                }
                else
                {
                    xVar = -1;
                }

            }
            else
            {
                xVar = Random.Range(-1, 2);
            }

            genPoint = new Vector3(genPoint.x + xVar, yAtSpawn - 0.5f * (wallHeight + nextWallHeight), genPoint.z);
            midPoint = Random.Range(-2, 3);
        }
        
    }
}
