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
    public Animator animator;


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


    // Use info for initialization
    void Start () {
        info = new Player();
        info.canMove = true;
        info.facingDirection = Player.FacingDirection.Down;
        this.animator = GetComponent<Animator>();
        //info.heldFood = GameManager.getGameManager().getFood("Cookie");
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
        updateMovement(playerMovement);
    }

    /// <summary>
    /// Move the player a certain amount.
    /// </summary>
    /// <param name="translateAmount">A vector3 representing the offset to move the player.</param>
    public void updateMovement(Vector3 translateAmount)
    {
        calculateFacingDirection(translateAmount);
        //calculate if player is moving
        float xAmount = Mathf.Abs(translateAmount.x);
        float yAmount = Mathf.Abs(translateAmount.y);
        if(xAmount==0 && yAmount == 0)
        {
            info.isMoving = false;
        }
        else
        {
            info.isMoving = true;
        }

        //calculate animation;
        this.playAnimation();
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

    private void calculateFacingDirection(Vector2 movementDirection)
    {
        Player.FacingDirection direction = Player.FacingDirection.Down;
        float xAmount=Mathf.Abs(movementDirection.x);
        float yAmount = Mathf.Abs(movementDirection.y);
        if (xAmount > yAmount)
        {
            //Greater x influence
            direction=getHorizontalFacingDirection(movementDirection);
        }
        else
        {
           direction=getVerticalFacingDirection(movementDirection);
        }

        Debug.Log(direction);
        info.facingDirection = direction;
    }

    private Player.FacingDirection getVerticalFacingDirection(Vector2 movement)
    {
        if (movement.y <= 0)
        {
            return Player.FacingDirection.Down;
        }
        else
        {
            return Player.FacingDirection.Up;
        }
    }

    private Player.FacingDirection getHorizontalFacingDirection(Vector2 movement)
    {
        if (movement.x <= 0)
        {
            return Player.FacingDirection.Left;
        }
        else
        {
            return Player.FacingDirection.Right;
        }
    }

    private void playAnimation()
    { 
        if (info.isMoving)
        {
            if (info.facingDirection == Player.FacingDirection.Up) this.animator.Play("Baker_UpWalking") ;
            if (info.facingDirection == Player.FacingDirection.Down) this.animator.Play("Baker_DownWalking");
            if (info.facingDirection == Player.FacingDirection.Left) this.animator.Play("Baker_LeftWalking");
            if (info.facingDirection == Player.FacingDirection.Right) this.animator.Play("Baker_RightWalking");
        }
        else
        {
            Debug.Log("AGGG");
            //is not moving.
            if (info.facingDirection == Player.FacingDirection.Up) this.animator.Play("Baker_UpIdle");
            if (info.facingDirection == Player.FacingDirection.Down) this.animator.Play("Baker_DownIdle");
            if (info.facingDirection == Player.FacingDirection.Left) this.animator.Play("Baker_LeftIdle");
            if (info.facingDirection == Player.FacingDirection.Right) this.animator.Play("Baker_RightIdle");
        }

    }
}
