using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidscript : MonoBehaviour
{
    GameObject Player;
    Rigidbody rb;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        Vector3 movementVector = Player.transform.position - transform.position;
        movementVector = movementVector.normalized * 10;
        rb.AddForce(movementVector, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)));
        Destroy(gameObject, 5);
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("bullet")){
            Destroy(other);
            Destroy(gameObject);

        }
    }
}