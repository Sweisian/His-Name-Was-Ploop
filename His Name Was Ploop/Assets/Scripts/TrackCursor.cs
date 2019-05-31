using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class TrackCursor : MonoBehaviour
    {


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
                collision.gameObject.GetComponent<Outline>().enabled = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "SlimeBall")
            {
                collision.gameObject.GetComponent<Outline>().enabled = false;
            }
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
}
