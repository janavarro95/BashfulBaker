using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    public List<GameObject> pathNodes = new List<GameObject>();
    public bool loops = true;
    public uint debugLineDuration = 15;

    void Awake ()
    {
        if (gameObject.transform.childCount > 1)
        {
            int i = 0;
            foreach (Transform child in gameObject.transform)
            {
                pathNodes.Add(child.gameObject);
                if (pathNodes.Count > 1)
                    Debug.DrawLine(pathNodes[i-1].GetComponent<Transform>().position, pathNodes[i].GetComponent<Transform>().position, Color.green, debugLineDuration);
                ++i;
            }
            if (loops)
            {
                Debug.DrawLine(pathNodes[i - 1].GetComponent<Transform>().position, pathNodes[0].GetComponent<Transform>().position, Color.green, debugLineDuration);
            }
        }
        else
            Debug.LogWarning("Not enough children to create path for "+gameObject.name+"! | "+ gameObject.transform.childCount+" children");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
