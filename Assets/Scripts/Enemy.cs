using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] checkPoints;
    int i;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (i == 0)
        {
            i = 1;
        }
        else
            i = 0;
        StartCoroutine("Wander", checkPoints[i].transform.position);  // Random Wandering between two checkpoints
        
    }
    IEnumerator Wander(Vector3 targetPosition)
    {
        
        while (Vector3.Distance(transform.position,targetPosition)>0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 3f * Time.deltaTime);
            yield return null;
        }
    }
}
