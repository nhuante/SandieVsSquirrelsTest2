using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    private Rigidbody acornRigidbody;
    private float shootAngle;
    private float acornSpeed = GameParameters.AcornSpeed;

    public void SetUp(float shootAngle)
    {
        this.shootAngle = shootAngle;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += shootDirection * acornSpeed * Time.deltaTime;
        transform.Translate(VectorFromAngle(shootAngle));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Corgi")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Barrier")
        {
            Destroy(gameObject);
        }
    }

    private Vector3 VectorFromAngle(float theta)
    {
        return new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0); // Trig is fun
    }
}
