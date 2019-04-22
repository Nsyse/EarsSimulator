using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenAnimationUtils : MonoBehaviour
{
    [SerializeField] private GameObject PressToLoadScene;

    [SerializeField]
    private AudioClip DistantExplosionSound;
    
    [SerializeField]
    private AudioClip ShockwaveSound;
    
    public delegate void ParallaxCompleted();
    public static event ParallaxCompleted OnParallaxCompleted;

    public static void FireParallaxCompleted()
    {
        OnParallaxCompleted?.Invoke();
    }

    
    private AudioSource audio = null;
    private Animator anim = null;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        SplashScreenAnimationUtils.OnParallaxCompleted += EnableAnimator;
    }

    private void OnDisable()
    {
        SplashScreenAnimationUtils.OnParallaxCompleted -= EnableAnimator;
    }

    //Triggered by animator
    public void PlayExplosionSoundEffect()
    {
        audio.clip = DistantExplosionSound;
        audio.Play();
    }
    
    //Triggered by animator
    public void PlayShockwaveSoundEffect()
    {
        audio.clip = ShockwaveSound;
        audio.Play();
    }
    

    public void EnableAnimator()
    {
        SetAnimator(true);
    }

    //Called by Izzy splash screen animator 
    public void DisableAnimator()
    {
        SetAnimator(false);
        ShowEndText();
    }

    private void ShowEndText()
    {
        
        //TODO : Warn if null
        PressToLoadScene.SetActive(true);
    }

    private void SetAnimator(bool value)
    {
        anim.enabled = value;
    }
}