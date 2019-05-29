using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    private AudioManager AM;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject largeProjectilePrefab;
    [SerializeField] private int maxProjectiles;
    [SerializeField] private string projectileTag;
    [SerializeField] private TMP_Text projectileCountText;

    private void Start()
    {
        AM = FindObjectOfType<AudioManager>();
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
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                Vector2 direction = cursorInWorldPos - myPos2D;
                direction.Normalize();
                GameObject projectile = null;

                if (Input.GetMouseButtonDown(0))
                { projectile = (GameObject)Instantiate(projectilePrefab, myPos2D, Quaternion.identity); }
                else if (Input.GetMouseButtonDown(1))
                { projectile = (GameObject)Instantiate(largeProjectilePrefab, myPos2D, Quaternion.identity); }

                //Gives the projectile a refernce to the player
                projectile.GetComponent<InertiaTransfer>().player = gameObject;
                projectile.GetComponent<InertiaTransfer>().AM = AM;
                projectile.GetComponent<Rigidbody2D>().velocity = direction;

                if (AM) AM.Play("fireProj");
            }
        }
    }
}
