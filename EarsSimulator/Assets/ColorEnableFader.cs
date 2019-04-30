using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorEnableFader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text = null;
    [SerializeField] private Color TargetColor;
    [SerializeField] private float FadeDuration;

    private Color OnEnableColor;
    private float fadedTimer = 0;
    
    private void OnEnable()
    {
        OnEnableColor = Text.color;
        fadedTimer = 0;
    }

    private void Update()
    {
        if (fadedTimer<FadeDuration)
        {
            fadedTimer += Time.deltaTime;
            Text.color = Color.Lerp(OnEnableColor, TargetColor, fadedTimer / FadeDuration);
        }
        else
        {
            Text.color = TargetColor;
        }
    }
}