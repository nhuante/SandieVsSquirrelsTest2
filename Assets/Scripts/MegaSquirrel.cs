using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaSquirrel : MonoBehaviour
{
    public Corgi Corgi;

    private SpriteRenderer MegaSquirrelSpriteRenderer;
    private Rigidbody MegaSquirrelRigidbody;
    private int randomMoveCount = 0;
    private int lastRandomDirection;
    private bool barrierTouched = false;
    private bool isDrunk = false;
    private int lives = GameParameters.MegaSquirrelLives;

    void Start()
    {
        MegaSquirrelSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        MegaSquirrelRigidbody = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if ((!isDrunk) && (!Corgi.GetIsDead()))
        {
            MoveRandomly();
        }
    }

    public void Move(int direction)
    {   
        switch (direction)
        {
            case 0: //up
                MegaSquirrelRigidbody.AddForce(Vector3.up);
                FaceCorrectDirection(new Vector2(0, 1));
                break;
            case 1: //left
                MegaSquirrelRigidbody.AddForce(Vector3.left);
                FaceCorrectDirection(new Vector2(-1, 0));
                break;
            case 2: //down
                MegaSquirrelRigidbody.AddForce(Vector3.down);
                FaceCorrectDirection(new Vector2(0, -1));
                break;
            case 3: //right
                MegaSquirrelRigidbody.AddForce(Vector3.right);
                FaceCorrectDirection(new Vector2(1, 0));
                break;
        }
    }

    private void MoveRandomly()
    {
        int newDirection = lastRandomDirection;

        if ((randomMoveCount == 0) || (barrierTouched == true))
        {
            randomMoveCount = GameParameters.TimesToMoveInSameRandomDirectionMegaSquirrel;
            while (newDirection == lastRandomDirection)
                newDirection = Random.Range(0, 4);
            lastRandomDirection = newDirection;
        }

        Move(newDirection);
        randomMoveCount = randomMoveCount - 1;
        barrierTouched = false;
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x < 0)
            MegaSquirrelSpriteRenderer.flipX = false;
        else if (direction.x > 0)
            MegaSquirrelSpriteRenderer.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beer")
        {
            LoseLife();
        }
        if (collision.gameObject.tag == "Barrier")
        {
            barrierTouched = true;
        }
    }

    private void LoseLife()
    {
        lives = lives - 1;
        if (lives == 0)
            BeDrunk();
    }

    private void BeDrunk()
    {
        isDrunk = true;

        //switch sprite to drunk sprite

        //other drunk things
    }
}
