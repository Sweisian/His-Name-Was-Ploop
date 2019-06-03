using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public PlayableDirector ExitSceneDirector;

    public void ExitSceneTimeline()
    {
        ExitSceneDirector.Play();

    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
