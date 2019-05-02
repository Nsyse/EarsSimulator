using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarResizer : MonoBehaviour
{
    public delegate void EarResized(float earsScale);

    public static event EarResized OnEarResized;

    public static void FireEarResized(float earsScale)
    {
        OnEarResized?.Invoke(earsScale);
    }
    
    [SerializeField]
    private GameObject leftEar;
    [SerializeField]
    private GameObject rightEar;

    private void OnEnable()
    {
        OnEarResized += SetEarsSize;
    }

    private void OnDisable()
    {
        //unsub to earScaleChange
    }

    public void SetEarsSize(float earSizes)
    {
        Utils.SetGOScale(leftEar, -earSizes);
        Utils.SetGOScale(rightEar, earSizes);
    }
}
