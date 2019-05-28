using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float speed;
    [SerializeField] private int maxProjectiles;
    [SerializeField] private string projectileTag;
    [SerializeField] private TMP_Text projectileCountText;

    // Update is called once per frame
    private void Start()
    {
        
    }

    void Update()
    {
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 myPos2D = (Vector2)transform.position;

        var currProjectileCount = GameObject.FindGameObjectsWithTag(projectileTag).Length;
        var displayCount = maxProjectiles - currProjectileCount;
        projectileCountText.text = displayCount.ToString();

        if (currProjectileCount < maxProjectiles)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 direction = cursorInWorldPos - myPos2D;
                direction.Normalize();
                GameObject projectile = (GameObject)Instantiate(projectilePrefab, myPos2D, Quaternion.identity);
                //Debug.Log("Created a projectile");

                //Gives the projectile a refernce to the player
                projectile.GetComponent<InertiaTransfer>().player = gameObject;
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
            }
        }

    }

}
