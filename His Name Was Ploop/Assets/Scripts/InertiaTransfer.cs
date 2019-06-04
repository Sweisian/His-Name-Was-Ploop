using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
//using DigitalRuby.LightningBolt;

public class InertiaTransfer : MonoBehaviour
{

    //private PlayerMovement playerMov;
    [HideInInspector] public GameObject player;
    [HideInInspector] public AudioManager AM;
    private Vector2 last_velocity_normalized;
    private bool isStuck = false;
    [SerializeField] private float force_scale;
    [SerializeField] private float speed;
    [SerializeField] private float playerParticlePositionScaler;
    [SerializeField] private GameObject forceParticles;
    [SerializeField] private GameObject forceParticlesPlayer;
    [SerializeField] private GameObject collisionParticles;
    [SerializeField] private GameObject slimeSplat;
    //[SerializeField] private GameObject lightingBolt;


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
        if (!isStuck) last_velocity_normalized = gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
    }

    //Write function to initiate momentum transfer!


    public void TransferInertia()
    {
        player.GetComponent<PlayerMovement>().ForceToPlayer(last_velocity_normalized * force_scale);

        //MAGICAL CODE THAT GETS ME THE RIGHT QUATERNION!
        var dir = last_velocity_normalized;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var myQuat = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        //Instantiate at projectile splat point
        Instantiate(forceParticles, (Vector2)transform.position, myQuat);

        Vector2 playerOffsetCoords = (Vector2)player.transform.position - last_velocity_normalized * playerParticlePositionScaler;

        //Instantiate at offset from player
        Instantiate(forceParticlesPlayer, playerOffsetCoords, myQuat);

       
        gameObject.GetComponent<GenerateLightning>().makeLighting(player);


        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Instantiate Slime Splat
        Instantiate(slimeSplat, (Vector2)transform.position, Quaternion.identity);

        if (!isStuck && !collision.gameObject.GetComponent<NoInertiaTransfer>())
        {
            //VERSION THAT APPLIES FORCE BASED ON COLLISION NORMAL
            //ContactPoint2D contact = collision.GetContact(0);
            ////negated so we get the vector in the direction the ball was going
            //Vector2 force_vector = -contact.normal;

            //Debug.Log("I collided with: " + collision.collider.gameObject);
            //Debug.Log(player);
            //Debug.Log("The Veclocity I transefered: " + last_velocity_normalized);

            if (AM) AM.Play("projSplat");

            transform.parent = collision.transform; // make the object collision object it's parent

            //It appears that destroying the rigid body breaks the OUTLINE script
            GetComponent<Rigidbody2D>().Sleep();

            isStuck = true;
            //gameObject.GetComponent<Collider2D>().enabled = false; //disable your collider, otherwise it may stick to something else

            //Destroy(gameObject);

            //Instantiate Collision Particles
            Instantiate(collisionParticles, (Vector2)transform.position, Quaternion.identity);





        }
    }
}

