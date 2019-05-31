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


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(1))

        {
            Debug.Log("Cursor tracker detected right click");

            if (collision.gameObject.tag == "SlimeBall")
            {
                collision.gameObject.GetComponent<InertiaTransfer>().TransferInertia();

            }
        }
    }
}
