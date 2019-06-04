using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using cakeslice;


public class TrackCursor : MonoBehaviour
{

    //[SerializeField] private Queue<GameObject> slimeBallQue;

    private void Start()
    {
        Cursor.visible = false;
        //slimeBallQue = new Queue<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = cursorInWorldPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlimeBall")
        {
            //Debug.Log("Cursor tracker detected slime enter");
            collision.gameObject.GetComponent<Outline>().enabled = true;
            //slimeBallQue.Enqueue(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SlimeBall")
        {
            //Debug.Log("Cursor tracker detected slime exit");
            collision.gameObject.GetComponent<Outline>().enabled = false;
            //slimeBallQue.Dequeue();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "SlimeBall")
        {
            if (Input.GetMouseButtonDown(1))
            {
                collision.gameObject.GetComponent<InertiaTransfer>().TransferInertia();
                GetComponent<CinemachineImpulseSource>().GenerateImpulse();
            }
        }
    }
}

