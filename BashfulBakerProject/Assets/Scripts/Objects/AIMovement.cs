using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
    public float moveSpeed = 5.0f;
    GameObject path;
    Vector3 movingTo;
    int i = 1;

	// Use this for initialization
	void Start () {
        path = GameObject.Find("GuardPath");
        transform.position = path.GetComponent<Path>().pathNodes[0].transform.position; // Agent starts at first node of the path
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position == path.GetComponent<Path>().pathNodes[i % path.GetComponent<Path>().pathNodes.Count].transform.position) // If the agent reaches the node, move towards the next one (only works for looping walks)
        {
            ++i;
        }
        movingTo = path.GetComponent<Path>().pathNodes[i % path.GetComponent<Path>().pathNodes.Count].transform.position;

        float moveStep = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movingTo, moveStep);

        // Debug.Log(i % path.GetComponent<Path>().pathNodes.Count);
    }
}
