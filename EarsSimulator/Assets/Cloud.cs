using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private SpriteRenderer sprite = null;
    [SerializeField] private float CloudSpeed;
    private float MinX = -100;

    private float MinScale = 0.6f;
    private float MaxScale = 1.2f;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void InitCloud(float cloudSpeed, Color cloudColor, float maxX, float yOffset)
    {
        Debug.Log(cloudSpeed);
        sprite.color = cloudColor;
        CloudSpeed = cloudSpeed;
        MinX = maxX;
        this.transform.position += Vector3.up * yOffset;
        
        Utils.SetGOScale(gameObject, Random.Range(MinScale, MaxScale));
    }

    private void Update()
    {
        this.transform.position += Vector3.left * CloudSpeed;

        if (this.transform.position.x < MinX)
        {
            Destroy(gameObject);
        }
    }
}
