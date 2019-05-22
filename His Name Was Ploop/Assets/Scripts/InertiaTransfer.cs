using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class InertiaTransfer : MonoBehaviour
{

    //private PlayerMovement playerMov;
    public GameObject player;
    private Vector2 last_velocity_normalized;

    //The velocity vector we need is updated here to get the velocity before the collision
    //private void Start()
    //{
    //    playerMov = FindObjectOfType<PlayerMovement>();
    //}

    void FixedUpdate()
    {
        last_velocity_normalized = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        //VERSION THAT APPLIES FORCE BASED ON COLLISION NORMAL
        //ContactPoint2D contact = collision.GetContact(0);
        ////negated so we get the vector in the direction the ball was going
        //Vector2 force_vector = -contact.normal;

        Debug.Log("I collided with: " + collision.collider.gameObject);
        Debug.Log(player);
        //Debug.Log("The Veclocity I transefered: " + last_velocity_normalized);

        player.GetComponent<PlayerMovement>().ForceToPlayer(last_velocity_normalized);
        Destroy(gameObject);
    }


}
