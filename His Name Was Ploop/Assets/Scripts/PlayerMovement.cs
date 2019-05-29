using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private UnityJellySprite myUnityJelly;
    

    public void Start()
    {
        myUnityJelly = gameObject.GetComponent<UnityJellySprite>();
        //myAE = gameObject.GetComponent<AreaEffector2D>();
    }

    //TODO: maybe move this to the player controller, not sure if I need most of the controller though
    public void ForceToPlayer(Vector2 force_vector)
    {
        //Debug.Log("I activated");
        //Debug.Log("Force Vector is: " + force_vector);
        var forceToAdd = force_vector;
        //myUnityJelly.m_CentralPoint.GameObject.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Force);
        foreach ( var rp in myUnityJelly.ReferencePoints)
        {
            rp.GameObject.GetComponent<Rigidbody2D>().AddForce(forceToAdd, ForceMode2D.Force);
        }


    }
}
