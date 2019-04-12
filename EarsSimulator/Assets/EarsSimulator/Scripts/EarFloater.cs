using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarFloater : MonoBehaviour
{
    private Animator anim;
    
    [SerializeField]
    private float Threshold;

    private float earsSize;

    // Update is called once per frame
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        EarResizer.OnEarResized += SetEarsSize;
    }

    private void SetEarsSize(float earsscale)
    {
        earsSize = earsscale;
    }

    void Update()
    {
        anim.SetBool("earsFloating", earsSize > Threshold);
    }
}