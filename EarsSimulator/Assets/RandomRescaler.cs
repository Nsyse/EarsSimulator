using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRescaler : MonoBehaviour
{
    [SerializeField] private float BaseScale = 1;
    [SerializeField] private float MaxStartScaleOffset;

    [SerializeField] private float MinScaleOffsetPercent;
    [SerializeField] private float MaxScaleOffsetPercent;

    private Vector3 startingScale;
    private Vector3 TargetScale;


    private void OnEnable()
    {
        float randomXScale = Random.value * MaxStartScaleOffset + BaseScale;
        float randomYScale = Random.value * MaxStartScaleOffset + BaseScale;
        startingScale = new Vector3(randomXScale, randomYScale, 1);
        this.transform.localScale = startingScale;
    }

    private void Update()
    {
        Vector3 scale = transform.localScale;
        if (TargetScale == scale)
        {
            ChooseNewTargetScale();
        }
        else
        {
            ScaleTowardsTarget(scale);
        }
    }

    private void ScaleTowardsTarget(Vector3 currentScale)
    {
        //limits movement to get to scale from 1-3 frames
        int randomStep = Random.Range(1,3);

        transform.localScale = currentScale + (TargetScale - currentScale) / randomStep;
    }

    private void ChooseNewTargetScale()
    {
        float xOffset = Utils.ChooseRandomOffset(MinScaleOffsetPercent, MaxScaleOffsetPercent);
        float yOffset = Utils.ChooseRandomOffset(MinScaleOffsetPercent, MaxScaleOffsetPercent);

        TargetScale = startingScale + new Vector3(xOffset, yOffset);
    }
}