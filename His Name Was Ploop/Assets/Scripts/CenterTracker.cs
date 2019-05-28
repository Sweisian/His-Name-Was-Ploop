using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterTracker : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector3 centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
        gameObject.transform.position = centerPos;
    }
}
