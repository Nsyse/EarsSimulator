using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorEnableFader : MonoBehaviour
{
    public delegate void FadeCompleted(String fadedObjectName);

    public static event FadeCompleted OnFadeCompleted;

    public static void FireOnFadeCompleted(String fadedObjectName)
    {
        OnFadeCompleted?.Invoke(fadedObjectName);
    }

    [SerializeField] private TextMeshProUGUI Text = null;
    [SerializeField] private SpriteRenderer Sprite = null;
    [SerializeField] private Color TargetColor;
    [SerializeField] private float FadeDuration;

    private bool fadeCompleted = false;
    private Color m_ActiveColor = new Color();
    private Color m_OnEnableColor;
    private float m_FadedTimer = 0;
    private bool m_AffectsText;
    private bool m_AffectsSprite;

    private void OnEnable()
    {
        m_AffectsText = Text != null;
        m_AffectsSprite = Sprite != null;

        if (!m_AffectsText && !m_AffectsSprite)
        {
            Debug.LogError("GO config error on :"+ Utils.GetGOPath(gameObject.transform));
            Debug.LogError("A color fade script has no object to fade the color of.");
        }
        else if (m_AffectsText && m_AffectsSprite)
        {
            Debug.LogError("A color fade script has 2 objects to fade.");
        }

        else
        {
            if (m_AffectsText)
            {
                m_OnEnableColor = Text.color;
            }
            else
            {
                m_OnEnableColor = Sprite.color;
            }

            m_ActiveColor = m_OnEnableColor;
            m_FadedTimer = 0;
        }
    }

    private void Update()
    {
        if (!fadeCompleted)
        {
            UpdateActiveColor();
            UpdateTextAndSpriteColor();
        }
    }

    private void UpdateTextAndSpriteColor()
    {
        if (m_AffectsText)
        {
            Text.color = m_ActiveColor;
        }

        if (m_AffectsSprite)
        {
            Sprite.color = m_ActiveColor;
        }
    }

    private void UpdateActiveColor()
    {
        if (m_FadedTimer < FadeDuration)
        {
            m_FadedTimer += Time.deltaTime;
            m_ActiveColor = Color.Lerp(m_OnEnableColor, TargetColor, m_FadedTimer / FadeDuration);
        }
        else
        {
            m_ActiveColor = TargetColor;
            fadeCompleted = true;
            FireOnFadeCompleted(gameObject.name);
        }
    }
}