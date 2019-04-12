using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shaker : MonoBehaviour
{
    [SerializeField] private float maxOffset;
    [SerializeField] private float minOffset;
    
    private Vector2 StartingPosition;
    private Vector2 TargetPosition;

    private void Start()
    {
        StartingPosition = gameObject.transform.position;
        TargetPosition = StartingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
    }

    private void Translate()
    {
        Vector2 currentPosition = transform.position;
        if (TargetPosition == currentPosition)
        {
            ChooseNewTargetPosition();
        }
        else
        {
            TranslateTowardsTarget(currentPosition);
        }
    }

    private void ChooseNewTargetPosition()
    {
        float xOffset = Utils.ChooseRandomOffset(minOffset, maxOffset); 
        float yOffset = Utils.ChooseRandomOffset(minOffset, maxOffset);

        TargetPosition = new Vector2(StartingPosition.x + xOffset, StartingPosition.y + yOffset);
    }

    private void TranslateTowardsTarget(Vector2 currentPosition)
    {
        int randomStep = Random.Range(1,3);

        transform.position = currentPosition + (TargetPosition - currentPosition) / randomStep;
    }
}