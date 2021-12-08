using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSquirrel : MonoBehaviour
{
    
    public Corgi Corgi;
    public float rotationDamping;

    private Transform corgiTransform;
    private SpriteRenderer CrackSquirrelSpriteRenderer;
    private bool isDrunk = false;
    private int lives = GameParameters.CrackSquirrelLives;
    private Vector3 corgiPosition;

    void Start()
    {
        corgiTransform = Corgi.transform;
        CrackSquirrelSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if ((!isDrunk) && (!Corgi.GetIsDead()))
        {
            GetCorgiPosition();
            if (WithinRange())
                MoveTowardsCorgi();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beer")
        {
            LoseLife();
        }
    }

    private void GetCorgiPosition()
    {
        corgiPosition = corgiTransform.position;
    }

    private void MoveTowardsCorgi()
    {
        if (CorgiIsAboveSquirrel())
            Move("Up");
        else if (CorgiIsBelowSquirrel())
            Move("Down");


        if (CorgiIsOnLeftOfSquirrel())
            Move("Left");
        else if (CorgiIsOnRightOfSquirrel())
            Move("Right");

    }

    private void Move(string direction)
    {
        Vector2 directionVector;
        if (direction == "Down")
            directionVector = new Vector2(0, -1);
        else if (direction == "Up")
            directionVector = new Vector2(0, 1);
        else if (direction == "Right")
            directionVector = new Vector2(1, 0);
        else
            directionVector = new Vector2(-1, 0);

        transform.Translate(CalculateAmountToMove(directionVector));
        FaceCorrectDirection(directionVector);
    }

    private Vector3 CalculateAmountToMove(Vector2 direction)
    {
        float amountX = GameParameters.CrackSquirrelMoveAmount * direction.x;
        float amountY = GameParameters.CrackSquirrelMoveAmount * direction.y;

        Vector2 amountToMove = new Vector2(amountX, amountY);
        return new Vector3(amountToMove.x, amountToMove.y, 0);
    }

    private bool CorgiIsAboveSquirrel()
    {
        if (corgiPosition.y > transform.position.y)
            return true;
        return false;
    }

    private bool CorgiIsBelowSquirrel()
    {
        if (corgiPosition.y < transform.position.y)
            return true;
        return false;
    }

    private bool CorgiIsOnLeftOfSquirrel()
    {
        if (corgiPosition.x < transform.position.x)
            return true;
        return false;
    }

    private bool CorgiIsOnRightOfSquirrel()
    {
        if (corgiPosition.x > transform.position.x)
            return true;
        return false;
    }

    private bool WithinRange()
    {
        return (Vector3.Distance(transform.position, corgiTransform.position) > GameParameters.minimumDistancefromCorgi);
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x <= 0)
            CrackSquirrelSpriteRenderer.flipX = false;
        else if (direction.x > 0)
            CrackSquirrelSpriteRenderer.flipX = true;
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
