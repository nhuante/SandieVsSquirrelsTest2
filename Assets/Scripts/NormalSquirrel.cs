using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSquirrel : MonoBehaviour
{
    public Corgi Corgi;
    public Transform AcornPrefab;

    private Transform CorgiTransform;
    private SpriteRenderer NormalSquirrelSpriteRenderer;
    private int lives = GameParameters.NormalSquirrelLives;
    public SpriteTools SpriteTools;

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
        return (Vector3.Distance(transform.position, CorgiTransform.position) < GameParameters.RangeToShootFor);
    }

    private void Shoot()
    {
        LaunchAcorn(AimAtCorgi());
    }

    private float AimAtCorgi()
    {
        return SpriteTools.GetAngleBetweenWorldPoints(gameObject.transform.position, CorgiTransform.position);
    }

    private void LaunchAcorn(float angleCalc)
    {
        Transform acornTransform = Instantiate(AcornPrefab, gameObject.transform.position, Quaternion.identity);
        
        //Vector3 shootDirection = (CorgiTransform.position - this.transform.position).normalized;
        acornTransform.GetComponent<Acorn>().SetUp(angleCalc);
    }
}
