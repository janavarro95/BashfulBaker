using Assets.Scripts.GameInput;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals with player controls and movement.
/// </summary>
/// 
public class CharacterController2D : MonoBehaviour {

    /// <summary>
    /// The player's movespeed.
    /// </summary>
    public float moveSpeed=0.05f;

    /// <summary>
    /// Returns a vector for the player's most recent movement.
    /// </summary>
    private Vector3 playerMovement
    {
        get
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return (new Vector3(input.x, input.y, 0f) * moveSpeed);
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updateMovement();
	}

    /// <summary>
    /// Update the player's movement via controller input.
    /// </summary>
    private void updateMovement()
    {
        this.gameObject.transform.position += playerMovement;
    }

    /// <summary>
    /// Move the player a certain amount.
    /// </summary>
    /// <param name="translateAmount">A vector3 representing the offset to move the player.</param>
    public void updateMovement(Vector3 translateAmount)
    {
        this.gameObject.transform.position += translateAmount;
    }

    /// <summary>
    /// Set the character's position.
    /// </summary>
    /// <param name="position">The position that the player should "warp" to.</param>
    public void setPositon(Vector3 position)
    {
        this.gameObject.transform.position += position;
    }
}
