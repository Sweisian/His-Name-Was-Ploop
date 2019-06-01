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
    [SerializeField] private GameObject shootingParticles;

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
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 direction = cursorInWorldPos - myPos2D;
                direction.Normalize();
                GameObject projectile = null;

                if (Input.GetMouseButtonDown(0))
                { projectile = (GameObject)Instantiate(projectilePrefab, myPos2D, Quaternion.identity); }
                //else if (Input.GetMouseButtonDown(1))
                //{ projectile = (GameObject)Instantiate(largeProjectilePrefab, myPos2D, Quaternion.identity); }

                //Gives the projectile a refernce to the player
                projectile.GetComponent<InertiaTransfer>().player = gameObject;
                projectile.GetComponent<InertiaTransfer>().AM = AM;
                projectile.GetComponent<Rigidbody2D>().velocity = direction;

                //MAGICAL CODE THAT GETS ME THE RIGHT QUATERNION!
                var dir = direction;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                var myQuat = Quaternion.AngleAxis(angle - 90, Vector3.forward);

                Instantiate(shootingParticles, myPos2D, myQuat);

                if (AM) AM.Play("fireProj");
            }
        }
    }
}
