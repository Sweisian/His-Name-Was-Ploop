using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float force_scale;

    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    //TODO: maybe move this to the player controller, not sure if I need most of the controller though
    public void ForceToPlayer(Vector2 force_vector)
    {
        //Debug.Log("Force Vector is: " + force_vector);
        rb.AddForce(force_vector * force_scale, ForceMode2D.Impulse);

    }
}
