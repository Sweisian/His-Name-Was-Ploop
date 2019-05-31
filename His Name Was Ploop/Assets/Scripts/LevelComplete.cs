using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private bool triggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered && collision.gameObject.tag == "Player")
        {
            FindObjectOfType<LevelChanger>().ExitSceneTimeline();
            Debug.Log("Tried to trigger exit scene timeline");
            triggered = true;
        }
    }
}
