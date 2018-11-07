using Assets.Scripts;
using Assets.Scripts.GameInput;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals with player controls and movement.
/// </summary>
public class CharacterController2D : MonoBehaviour {

    /// <summary>
    /// The player's movespeed.
    /// </summary>
    public float moveSpeed=0.05f;

    /// <summary>
    /// Enum to handle player facing direction.
    /// </summary>
    public enum FacingDirection
    {
        Up,
        Right,
        Down,
        Left
    }

    /// <summary>
    /// The direction the player is facing.
    /// </summary>
    public FacingDirection facingDirection;


    /// <summary>
    /// If the player can move or not.
    /// </summary>
    public bool canMove;


    public bool holdingFood {

        get
        {
            if (heldFood == null) return false;
            else return true;
        }
    }
    public Food heldFood;

    /// <summary>
    /// Returns a vector for the player's most recent movement.
    /// </summary>
    private Vector3 playerMovement
    {
        get
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return (new Vector3(input.x, input.y, 0f) * moveSpeed*movementModifier());
        }
    }


    // Use this for initialization
    void Start () {
        this.canMove = true;
        this.facingDirection = FacingDirection.Down;

        this.heldFood = GameManager.getGameManager().getFood("Cookie");
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

    /// <summary>
    /// The direction of the sprite to face.
    /// </summary>
    /// <param name="direction"></param>
    public void faceDirection(FacingDirection direction)
    {
        this.facingDirection = direction;
    }

    /// <summary>
    /// Movement modifier function that determines speed/can move/etc.
    /// </summary>
    /// <returns></returns>
    private float movementModifier()
    {
        if (canMove == false) return 0.0f;
        return 1.0f;
    }
}
