using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSizeConstrainer : MonoBehaviour
{
    public float largestCamSize;
    public float smallestCamSize;
    public float wantaBeSize;

    private CinemachineVirtualCamera myCamera;

    void Start()
    {
        myCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
    }


    // Update is called once per frame
    void Update()
    {
        wantaBeSize = Mathf.Clamp(wantaBeSize, smallestCamSize, largestCamSize);
        myCamera.m_Lens.OrthographicSize = wantaBeSize;
    }
}
