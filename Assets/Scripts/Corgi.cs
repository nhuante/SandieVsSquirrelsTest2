using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    private Rigidbody CorgiRigidbody;
    public Sprite NormalSprite;
    //public Sprite DeadSprite;
    //public Sprite DrunkSprite;
    public SpriteTools SpriteTools;

    private int lives = GameParameters.CorgiLives;
    private bool isDead = false;

    private void Start()
    {
        CorgiRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    public void Move(int direction)
    {
        switch (direction)
        {
            case 0:
                StopCorgi();
                break;
            case 1:
                CorgiRigidbody.AddForce(Vector3.up);
                FaceCorrectDirection(new Vector2(0, 1));
                break;
            case 2:
                CorgiRigidbody.AddForce(Vector3.left);
                FaceCorrectDirection(new Vector2(-1, 0));
                break;
            case 3:
                CorgiRigidbody.AddForce(Vector3.down);
                FaceCorrectDirection(new Vector2(0, -1));
                break;
            case 4:
                CorgiRigidbody.AddForce(Vector3.right);
                FaceCorrectDirection(new Vector2(1, 0));
                break;
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }

    private void StopCorgi()
    {

    }

    public void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x < 0)
            CorgiSpriteRenderer.flipX = false;
        else if (direction.x > 0)
            CorgiSpriteRenderer.flipX = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Acorn")
        {
            LoseHealth();
        }
        if (collision.gameObject.tag == "Beer")
        {
            GetDrunk();
        }
    }

    private void LoseHealth()
    {
        // lose health
        //check if dead
    }

    private void GetDrunk()
    {
        
    }

    private void Die()
    {
        isDead = true;
        SwitchToDeadSprite();
    }

    private void SwitchToDeadSprite()
    {
        //CorgiSpriteRenderer.sprite = DeadSprite;
    }

    private void SwitchToNormalSprite()
    {
        //CorgiSpriteRenderer.sprite = NormalSprite;
    }

    private void SwitchToDrunkSprite()
    {
        //CorgiSpriteRenderer.sprite = NormalSprite;
    }
}
