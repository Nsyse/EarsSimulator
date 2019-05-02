using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaler : MonoBehaviour
{
    [SerializeField] private float ScaleDuration = 1;
    private float ScaledDuring = 0;
    
    void Update()
    {
            ScaledDuring += Time.deltaTime;
            
            float newScale = RangeMapper.MapToQuad(ScaledDuring/ScaleDuration);
        
            Utils.SetGOScale(gameObject, newScale);
    }
}
