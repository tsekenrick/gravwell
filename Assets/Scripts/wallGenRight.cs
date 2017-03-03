using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallGenRight : MonoBehaviour
{
    public GameObject wallRight;
    public Vector3 genPoint;
    public float distBetween;
    float nextWallHeight;

    float wallHeight;
    float yAtSpawn;

    public float distTo;
    public float xVar;
    public bool canGen;

    public float midPoint;
    public GameObject leftWallGen;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("generation", 3f, 8f);
        midPoint = 0;
        genPoint = transform.position;
        nextWallHeight = 0;
        //nextWallWidth = wallRight.transform.localScale.x;
        for (int i = 0; i < 500; i++)
        {
            wallHeight = nextWallHeight;
            wallRight.transform.localScale = new Vector3(transform.localScale.x, wallHeight, transform.localScale.z);
            GameObject lastBlock = Instantiate(wallRight, genPoint, transform.rotation);
            yAtSpawn = genPoint.y;
            wallHeight = wallRight.transform.localScale.y;
            nextWallHeight = Random.Range(1, 5);

            distTo = lastBlock.GetComponent<wallRayCastRight>().distBetween;

            if (lastBlock.transform.position.x < midPoint + 3)
            {
                xVar = 1;
            }
            else if (lastBlock.transform.position.x < midPoint + 5) //inverse of above weighting
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
            else if (lastBlock.transform.position.x > midPoint + 8)
            {
                xVar = -1;
            }
            else if (lastBlock.transform.position.x > midPoint + 5) //begins weighting towards moving to stay within camera view
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
            else
            {
                xVar = Random.Range(-1, 2);
            }
            genPoint = new Vector3(genPoint.x + xVar, yAtSpawn - 0.5f * (wallHeight + nextWallHeight), genPoint.z);
            midPoint = Random.Range(-2, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //midPoint = leftWallGen.GetComponent<wallGen>().midPoint;

    }

    void generation()
    {

        midPoint = 0;
        //nextWallWidth = wallRight.transform.localScale.x;
        for (int i = 0; i < 75; i++)
        {
            wallHeight = nextWallHeight;
            wallRight.transform.localScale = new Vector3(transform.localScale.x, wallHeight, transform.localScale.z);
            GameObject lastBlock = Instantiate(wallRight, genPoint, transform.rotation);
            yAtSpawn = genPoint.y;
            wallHeight = wallRight.transform.localScale.y;
            nextWallHeight = Random.Range(1, 5);

            distTo = lastBlock.GetComponent<wallRayCastRight>().distBetween;

            if (lastBlock.transform.position.x < midPoint + 3)
            {
                xVar = 1;
            }
            else if (lastBlock.transform.position.x < midPoint + 5) //inverse of above weighting
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
            else if (lastBlock.transform.position.x > midPoint + 8)
            {
                xVar = -1;
            }
            else if (lastBlock.transform.position.x > midPoint + 5) //begins weighting towards moving to stay within camera view
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
            else
            {
                xVar = Random.Range(-1, 2);
            }
            genPoint = new Vector3(genPoint.x + xVar, yAtSpawn - 0.5f * (wallHeight + nextWallHeight), genPoint.z);
            midPoint = Random.Range(-2, 3);

        }
    }
}
