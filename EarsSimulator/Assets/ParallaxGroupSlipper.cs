using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxGroupSlipper : MonoBehaviour
{
    
    
    
    [SerializeField] private float SlipDuration;
    [SerializeField] private float SlipDelay;

    private float StartTime = 0;
    
    private Dictionary<GameObject, float> parallaxedObjectsSpeeds = new Dictionary<GameObject, float>();
    
    private float SlipSpeed =0;
    
    private void Start()
    {
        foreach (Transform child in transform)
        {
            float objectSpeed = child.position.y*-1/SlipDuration;
            parallaxedObjectsSpeeds.Add(child.gameObject, objectSpeed);
        }
        
    }

    private void OnEnable()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time>SlipDelay)
        {
            UpdateChildrenPositions();
            DeactivateSelfIfFinishedRising();   
        }
    }

    private void DeactivateSelfIfFinishedRising()
    {
        bool allObjectsDoneRising = true;
        
        foreach (GameObject child in parallaxedObjectsSpeeds.Keys)
        {
            if (child.transform.position.y <0)
            {
                allObjectsDoneRising = false;
                break;
            }
        }
        
        if (allObjectsDoneRising)
        {
            FireScrollCompletedEvent();
            SplashScreenAnimationUtils.FireParallaxCompleted();
            enabled = false;
        }
    }

    private void FireScrollCompletedEvent()
    {
        Debug.Log("Parallax complete");
    }

    private void UpdateChildrenPositions()
    {
        foreach (var pair in parallaxedObjectsSpeeds)
        {
            
            //Move up at given speed.
            float targetPosiY = (pair.Key.transform.position + Vector3.up * pair.Value * Time.deltaTime).y;

            if (targetPosiY > 0)
            {
                targetPosiY = 0;
            }

            Vector2 newPosition = pair.Key.transform.position;
            newPosition.y = targetPosiY;
        
            pair.Key.transform.position = newPosition;
        }
    }
}
