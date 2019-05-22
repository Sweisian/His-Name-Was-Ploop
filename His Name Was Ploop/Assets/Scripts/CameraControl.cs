using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public float largestCamSize;
    public float smallestCamSize;
    public float zoomSpeed;
    
    public float moveSpeed = 20f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    public Transform topLeftConstraint;
    public Transform bottomRightConstraint;
    Vector2 wantaBePos;
    Vector2 actualToBePos;

    public CinemachineVirtualCamera myCamera;

 

    void Start() {
        wantaBePos = transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        //Deals with contraining camera
        wantaBePos += new Vector2(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 
                                 Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        wantaBePos.x = Mathf.Clamp(wantaBePos.x, topLeftConstraint.position.x, bottomRightConstraint.position.x);
        wantaBePos.y = Mathf.Clamp(wantaBePos.y, bottomRightConstraint.position.y, topLeftConstraint.position.y);

        //Debug.Log("wantaBePos: " + wantaBePos);
        
        actualToBePos = new Vector2(Mathf.Clamp(wantaBePos.x, topLeftConstraint.position.x, bottomRightConstraint.position.x), 
                                Mathf.Clamp(wantaBePos.y, bottomRightConstraint.position.y, topLeftConstraint.position.y));

        //Debug.Log("actualToBePos: " + actualToBePos);


        //Zoom out function
        float currCamSize = myCamera.m_Lens.OrthographicSize;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currCamSize < largestCamSize)
                myCamera.m_Lens.OrthographicSize += zoomSpeed * Time.deltaTime;
        }
        else
        {
            if (currCamSize >= smallestCamSize)
            {
                //Debug.Log("I'm zooming in");
                myCamera.m_Lens.OrthographicSize -= zoomSpeed * Time.deltaTime;
            }
        }

    }

    void FixedUpdate()
    {
        transform.position = actualToBePos;
    }
}
