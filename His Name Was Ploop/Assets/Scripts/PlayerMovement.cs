using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private UnityJellySprite myUnityJelly;
    private GameObject jellyCenter;
    private Vector2 last_velocity;
    private Vector2 deltaVelocity;
    public float threshold_delta;
    public float shakeDampening;

    private bool hasCentralPoint = false;


    public void Start()
    {
        myUnityJelly = gameObject.GetComponent<UnityJellySprite>();
        //Debug.Log(myUnityJelly);
        StartCoroutine(LateStart(.1f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        jellyCenter = myUnityJelly.m_CentralPoint.GameObject;
        //Debug.Log(jellyCenter);
        hasCentralPoint = true;
    }

    private void FixedUpdate()
    {
        //if(hasCentralPoint)
        //{
        //    var cur_vel = jellyCenter.GetComponent<Rigidbody2D>().velocity;

        //    deltaVelocity = cur_vel - last_velocity;

        //    if (Mathf.Abs(deltaVelocity.magnitude) > threshold_delta)
        //    {
        //        Debug.Log("deltaVelocity:" + deltaVelocity);
        //        var shakeVeclocity = deltaVelocity - (deltaVelocity.normalized * shakeDampening);
        //        Debug.Log("shakeVeclocity" + shakeVeclocity);
        //        GetComponent<CinemachineImpulseSource>().GenerateImpulse(shakeVeclocity);
        //    }

        //    last_velocity = cur_vel;
        //}
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
