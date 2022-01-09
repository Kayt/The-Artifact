using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] animSprites;
    public float timeThreshold = 0.1f;
    private float timer;
    private int state = 0;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            Debug.Log("Index number is " + animSprites.Length);
            sr.sprite = animSprites[state];
            Debug.Log("Index is " + state);
            state++;

            if (state == animSprites.Length)
                state = 0;

            timer = Time.time + timeThreshold;
        }
    }
}
