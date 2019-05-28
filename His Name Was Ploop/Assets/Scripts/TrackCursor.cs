using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCursor : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = cursorInWorldPos;
    }
}
