using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos2D = (Vector2)transform.position;

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 direction = cursorInWorldPos - myPos2D;
            direction.Normalize();
            GameObject projectile = (GameObject)Instantiate(projectilePrefab, myPos2D, Quaternion.identity);

            //Gives the projectile a refernce to the player
            projectile.GetComponent<InertiaTransfer>().player = gameObject;

            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;

        }
    }

    void OnCollisionEnter2D (Collision2D other)
    {


    }
}
