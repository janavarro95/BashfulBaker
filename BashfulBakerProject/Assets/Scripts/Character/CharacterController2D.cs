using Assets.Scripts;
using Assets.Scripts.Character;
using Assets.Scripts.GameInput;
using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals with player controls and movement.
/// </summary>
public class CharacterController2D : MonoBehaviour {


    public Player info;
    /// <summary>
    /// Returns a vector for the player's most recent movement.
    /// </summary>
    private Vector3 playerMovement
    {
        get
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            return (new Vector3(input.x, input.y, 0f) * info.moveSpeed*movementModifier());
        }
    }


    // Use this for initialization
    void Start () {
        info = new Player();
        info.canMove = true;
        info.facingDirection = Player.FacingDirection.Down;

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
    public void faceDirection(Player.FacingDirection direction)
    {
        info.facingDirection = direction;
    }

    /// <summary>
    /// Movement modifier function that determines speed/can move/etc.
    /// </summary>
    /// <returns></returns>
    private float movementModifier()
    {
        if (info.canMove == false) return 0.0f;
        return 1.0f;
    }
}
