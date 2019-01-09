﻿using Assets.Scripts;
using Assets.Scripts.Character;
using Assets.Scripts.GameInput;
using Assets.Scripts.Objects;
using Assets.Scripts.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals with player controls and movement.
/// </summary>
public class CharacterController2D : MonoBehaviour {


    public Player info;


    public float movementSpeed = 0.5f;

    private Animator animator;
    private AudioSource footstepSound;

    private FrameTimer footstepTimer;
    private Random random;
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
        info.controller = this;
        info.canMove = true;
        info.facingDirection = Player.FacingDirection.Down;
        this.animator = GetComponent<Animator>();
        this.footstepSound = GetComponent<AudioSource>();
        if (GameManager.foodToGive != null)
        {
            this.info.heldFood =Instantiate(GameManager.foodToGive);
            GameManager.foodToGive = null;
            this.info.heldFood.attatchToPlayer();
        }
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

        if (info.isMoving)
        {
            if (this.footstepTimer == null)
            {
                this.footstepTimer = new FrameTimer(15, null, false);
                this.footstepSound.pitch = Random.Range(0.5f, 1f);
                this.footstepSound.Play();
            }

            if(this.footstepTimer.finished())
            {
                this.footstepSound.pitch = Random.Range(0.5f, 1f);
                this.footstepSound.Play();
                this.footstepTimer.lifespanRemaining = 15;
            }
            else
            {
                this.footstepTimer.tick();
                Debug.Log(this.footstepTimer.lifespanRemaining);
            }
        }
        else
        {
            this.footstepSound.Stop();
            this.footstepTimer = null;
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
            //is not moving.
            if (info.facingDirection == Player.FacingDirection.Up) this.animator.Play("Baker_UpIdle");
            if (info.facingDirection == Player.FacingDirection.Down) this.animator.Play("Baker_DownIdle");
            if (info.facingDirection == Player.FacingDirection.Left) this.animator.Play("Baker_LeftIdle");
            if (info.facingDirection == Player.FacingDirection.Right) this.animator.Play("Baker_RightIdle");
        }

    }
}
