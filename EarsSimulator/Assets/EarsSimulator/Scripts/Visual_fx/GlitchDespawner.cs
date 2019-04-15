using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchDespawner : MonoBehaviour
{

    [SerializeField] private float FadeDuration = 1;

    private float fadedDuring = 0;
    
    private SpriteRenderer Renderer;

    private void OnEnable()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentOpacity = Renderer.color.a;
        float newOpacity = currentOpacity;

        if (Input.GetKey(KeyCode.A))
        {
            newOpacity = 1;
            fadedDuring = 0;
        }
        else
        {
            if (newOpacity < 0)
            {
                ScreenFucker.FireOnGlitchDespawned();
                Destroy(gameObject);
            }
            fadedDuring += Time.deltaTime;

            if (fadedDuring > 1)
            {
                fadedDuring = 1;
            }
            
            newOpacity -= Utils.MapToQuadReflection(fadedDuring);
        
            Color newColor = Renderer.color;
            newColor.a = newOpacity;

            Renderer.color = newColor;
        }
    }
}