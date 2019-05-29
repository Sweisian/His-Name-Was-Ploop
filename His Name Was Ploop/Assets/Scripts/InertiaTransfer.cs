using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class InertiaTransfer : MonoBehaviour
{

    //private PlayerMovement playerMov;
    [HideInInspector] public GameObject player;
    [HideInInspector] public AudioManager AM;
    private Vector2 last_velocity_normalized;
    [SerializeField] private float force_scale;
    [SerializeField] private float speed;
    [SerializeField] private float playerParticlePositionScaler;
    [SerializeField] private GameObject forceParticles;
    [SerializeField] private GameObject forceParticlesPlayer;


    //The velocity vector we need is updated here to get the velocity before the collision
    //private void Start()
    //{
    //    playerMov = FindObjectOfType<PlayerMovement>();
    //}

    private void Start()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity * speed;
    }

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

        //Debug.Log("I collided with: " + collision.collider.gameObject);
        //Debug.Log(player);
        //Debug.Log("The Veclocity I transefered: " + last_velocity_normalized);

        if(!collision.gameObject.GetComponent<NoInertiaTransfer>())
        {
            player.GetComponent<PlayerMovement>().ForceToPlayer(last_velocity_normalized * force_scale);
        }
        
        if(AM) AM.Play("projSplat");

        //MAGICAL CODE THAT GETS ME THE RIGHT QUATERNION!
        var dir =  last_velocity_normalized;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var myQuat = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //Instantiate at projectile splat point
        Instantiate(forceParticles, (Vector2) transform.position, myQuat);

        Vector2 playerOffsetCoords = (Vector2) player.transform.position - last_velocity_normalized * playerParticlePositionScaler;

        //Instantiate at offset from player
        Instantiate(forceParticlesPlayer, playerOffsetCoords, myQuat);

        Destroy(gameObject);
    }
}
