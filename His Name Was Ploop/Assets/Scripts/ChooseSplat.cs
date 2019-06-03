using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSplat : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] splats;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, splats.Length);
        rend.sprite = splats[rand];
    }   
}
