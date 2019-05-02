using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxDespawner : MonoBehaviour
{
    [SerializeField] private float FadeDuration = 1;
    private float FadedDuring = 0;
    private SpriteRenderer Renderer;
    
    private void OnEnable()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        float currentOpacity = Renderer.color.a;
        float newOpacity = 1;

        if (ShouldntDespawn())
        {
            FadedDuring = 0;
        }
        else
        {
            if (newOpacity <= 0)
            {
                FireOnDespawn();
                Destroy(gameObject);
            }
            FadedDuring += Time.deltaTime;

            float linearX = FadedDuring / FadeDuration;
            
            /*
             * Makes sure that if the update was slow the mapper still receives
             * a value capped to 0-1 (just started to completed) range
             */
            if (linearX > 1)
            {
                linearX = 1;
            }
            newOpacity = 1- RangeMapper.MapToQuadReflection(linearX);
        
            Color newColor = Renderer.color;
            newColor.a = newOpacity;

            Renderer.color = newColor;
        }
    }

    protected virtual void FireOnDespawn()
    {
        //Nothing by default
    }

    protected virtual bool ShouldntDespawn()
    {
        //Never by default
        return false;
    }
}
