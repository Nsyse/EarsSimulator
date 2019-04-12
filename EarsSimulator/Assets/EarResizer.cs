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
        SetGOScale(leftEar, -earSizes);
        SetGOScale(rightEar, earSizes);
    }

    private void SetGOScale(GameObject o, float size)
    {
        o.transform.localScale = new Vector3(size, Mathf.Abs(size), 1);
    }
}
