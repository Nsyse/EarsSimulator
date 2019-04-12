using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private float toggleLength = 0;

    private float timer = 0;
    
    private SpriteRenderer renderer;

    private void OnEnable()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>=toggleLength)
        {
            renderer.flipX = !renderer.flipX;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}