using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BroadCastEarsSize : MonoBehaviour
{
    private Slider slider;
    private void OnEnable()
    {
        slider = GetComponent<Slider>();
    }

    public void FireEarSize()
    {
        EarResizer.FireEarResized(slider.value);
    }
}
