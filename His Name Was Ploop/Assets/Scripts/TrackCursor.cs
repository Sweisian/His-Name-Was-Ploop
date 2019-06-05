using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using cakeslice;
using System.Linq;


public class TrackCursor : MonoBehaviour
{
    public float checkRadius;
    private Collider2D[] inRadiusArray;

    //[SerializeField] private Queue<GameObject> slimeBallQue;

    private void Start()
    {
        Cursor.visible = false;
        inRadiusArray = new Collider2D[5];
        //slimeBallQue = new Queue<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = cursorInWorldPos;

        var curColliderArray =  Physics2D.OverlapCircleAll(transform.position, checkRadius);

        foreach (Collider2D col in curColliderArray)
        {
            if (col.gameObject.tag == "SlimeBall")
            {
                col.gameObject.GetComponent<Outline>().enabled = true;
                if (Input.GetMouseButtonDown(1))
                {
                    col.gameObject.GetComponent<InertiaTransfer>().TransferInertia();
                    GetComponent<CinemachineImpulseSource>().GenerateImpulse();
                    AudioManager.instance.Play("shock");
                }
            }
        }
        foreach (Collider2D col in inRadiusArray.Except(curColliderArray))
        {
            if (col)
            {
                var myOut = col.gameObject.GetComponent<Outline>();

                if (myOut)
                {
                    col.gameObject.GetComponent<Outline>().enabled = false;
                }
            }

            
            
        }

        inRadiusArray = curColliderArray;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "SlimeBall")
    //    {
    //        //Debug.Log("Cursor tracker detected slime enter");
    //        collision.gameObject.GetComponent<Outline>().enabled = true;
    //        //slimeBallQue.Enqueue(collision.gameObject);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "SlimeBall")
    //    {
    //        //Debug.Log("Cursor tracker detected slime exit");
    //        collision.gameObject.GetComponent<Outline>().enabled = false;
    //        //slimeBallQue.Dequeue();
    //    }
    //}


    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if (collision.gameObject.tag == "SlimeBall")
    //    {
    //        if (Input.GetMouseButtonDown(1))
    //        {
    //            collision.gameObject.GetComponent<InertiaTransfer>().TransferInertia();
    //            GetComponent<CinemachineImpulseSource>().GenerateImpulse();
    //        }
    //    }
    //}
}

