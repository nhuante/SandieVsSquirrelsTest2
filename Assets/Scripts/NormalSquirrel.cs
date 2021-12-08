using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSquirrel : MonoBehaviour
{
    public Corgi Corgi;

    private Transform CorgiTransform;
    private SpriteRenderer NormalSquirrelSpriteRenderer;
    private int lives = GameParameters.NormalSquirrelLives;

    private void Start()
    {
        NormalSquirrelSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        CorgiTransform = Corgi.transform;
    }

    private void Update()
    {
        if (CheckCorgiWithinRange())
            Shoot();
    }

    private bool CheckCorgiWithinRange()
    {
        return (Vector3.Distance(transform.position, CorgiTransform.position) > GameParameters.rangeToShootFor);
    }

    private void Shoot()
    {
        AimAtCorgi();
        LaunchAcorn();
    }

    private void AimAtCorgi()
    {
        // aim stuff
    }

    private void LaunchAcorn()
    {
        // launch stuff
    }
}
