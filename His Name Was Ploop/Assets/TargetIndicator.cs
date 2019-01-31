using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    Vector2 target;   

    // Update is called once per frame
    void Update()
    {
        //sets target as where ever the mouse is
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var dir = target - (Vector2) transform.position;

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
