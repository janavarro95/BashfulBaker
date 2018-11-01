using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach to camera.
/// </summary>
public class CameraControlls : MonoBehaviour {


    public bool followPlayer;

    public GameObject player;
    // Use this for initialization

    public Vector3 offset;

    public float moveSpeed;


    private float startTime;
    private Vector3 targetPanDestination;
    private bool panningCamera;


    public enum PanType
    {
        offset,
        snapToPlayer
    }

    public PanType panType;

	void Start () {
        targetPanDestination = player.transform.position;

        //panCamera(new Vector3(10, 0, 0),5);
        snapToPlayer(true, true);
	}
	
	// Update is called once per frame
	void Update () {
        if (followPlayer)
        {
            this.gameObject.transform.position = player.transform.position + offset + Vector3.back;
        }
        panCamera();
    }


    private void panCamera()
    {
        if (panningCamera)
        {
            if (panType == PanType.offset)
            {
                // Distance moved = time * speed.
                float distCovered = (Time.time - startTime) * moveSpeed;

                // Fraction of journey completed = current distance divided by total distance.
                float fracJourney = distCovered / Vector3.Distance(player.gameObject.transform.position, targetPanDestination);

                // Set our position as a fraction of the distance between the markers.
                offset = Vector3.Lerp(player.transform.position, targetPanDestination, fracJourney);

                if (fracJourney == 1.00f)
                {
                    panningCamera = false;
                }
            }
            if(panType== PanType.snapToPlayer)
            {
                // Distance moved = time * speed.
                float distCovered = (Time.time - startTime) * moveSpeed;

                // Fraction of journey completed = current distance divided by total distance.
                float fracJourney = distCovered / Vector3.Distance(targetPanDestination, player.gameObject.transform.position);

                // Set our position as a fraction of the distance between the markers.
                this.transform.position = Vector3.Lerp(targetPanDestination, player.transform.position+Vector3.back, fracJourney);
                

                if (fracJourney == 1.00f)
                {
                    panningCamera = false;
                    snapToPlayer(true, false);
                }
            }
        }
    }
    
    /// <summary>
    /// Pan the camera by setting a target offset and then lerping towards that position.
    /// </summary>
    /// <param name="amount"></param>
    public void panCamera(Vector3 amount)
    {
        targetPanDestination = amount;
        panningCamera = true;
        this.moveSpeed = 1f;
        panType = PanType.offset;
        startTime = Time.time;
    }

    /// <summary>
    /// Pan the camera by setting a target offset and then lerping towards that position.
    /// </summary>
    /// <param name="amount">The amount to pan the camera</param>
    /// <param name="speed">The speed to pan the camera</param>
    public void panCamera(Vector3 amount,float speed)
    {
        targetPanDestination = amount;
        panningCamera = true;
        this.moveSpeed = speed;
        panType = PanType.offset;
        startTime = Time.time;
    }

    /// <summary>
    /// Set the camera's position.
    /// </summary>
    /// <param name="pos">The position for the camera to be at.</param>
    public void setCameraPosition(Vector3 pos)
    {
        followPlayer = false;
        this.gameObject.transform.position = pos;

    }

    /// <summary>
    /// Snap the camera back to the player. AKA center it back on the player.
    /// </summary>
    /// <param name="resetOffset">Whether or not to reset the offset for the camera from the player.</param>
    /// <param name="panPlayer">Whether the camera pans to the player or instantly warps to the player.</param>
    /// <param name="followPlayer">Whether the camera should follow the player once it is done panning.</param>
    /// <param name="speed">The move speed for the panning. If panPlayer=false then this value is ignored.</param>
    public void snapToPlayer(bool resetOffset = true,bool panPlayer=false,bool followPlayer=true,float speed=1f)
    {
        if (resetOffset)
        {
            offset = new Vector3();
        }
        
        if (panPlayer)
        {
            panType = PanType.snapToPlayer;
            startTime = Time.time;
            targetPanDestination = this.gameObject.transform.position;
            panningCamera = true;
            this.followPlayer = followPlayer;
            this.moveSpeed = speed;
        }
        else
        {
            followPlayer = true;
        }
    }
}
