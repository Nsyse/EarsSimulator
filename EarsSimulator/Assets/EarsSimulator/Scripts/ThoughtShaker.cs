using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ThoughtShaker : MonoBehaviour
{
    [SerializeField] private float maxOffset = 0;
    [SerializeField] private float MaxRotation;
    [SerializeField] float rotationDelay = 0;
    [SerializeField]
    private float StartingRotationZ = -7;
    
    private float nextRotationTime = 0;
    private Vector2 StartingPosition;
    private Vector2 TargetPosition;
    private float TargetRotation;

    private void Start()
    {
        StartingPosition = gameObject.transform.position;
        TargetPosition = StartingPosition;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, StartingRotationZ);
    }

    private void OnEnable()
    {
        nextRotationTime = Time.time + rotationDelay;
    }

    // Update is called once per frame
    void Update()
    {
        Translate();
        Rotate();
    }

    private void Translate()
    {
        Vector2 position = transform.position;
        if (TargetPosition == position)
        {
            ChooseNewTargetPosition();
        }
        else
        {
            TranslateTowardsTarget();
        }
    }

    private void Rotate()
    {
        if (nextRotationTime<=Time.time)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -transform.eulerAngles.z);
            nextRotationTime += rotationDelay;
        }
    }

    private void ChooseNewTargetPosition()
    {
        float xOffset = Random.Range(-maxOffset, maxOffset);
        float yOffset = Random.Range(-maxOffset, maxOffset);

        TargetPosition = new Vector2(StartingPosition.x + xOffset, StartingPosition.y + yOffset);
    }

    private void ChooseNewTargetRotation()
    {
        float randomDegrees = Random.Range(-MaxRotation, MaxRotation);
        TargetRotation = randomDegrees;
    }

    private void RotateTowardsTarget()
    {
        float currentRotation = transform.rotation.z;

        int randomStep = Random.Range(2, 6);
        int luckRoll = Random.Range(1, 21);

        if (luckRoll == 20)
        {
            randomStep = 1;
        }

        float zRotation = currentRotation + (TargetRotation - currentRotation) / randomStep;
        transform.eulerAngles = new Vector3(0, 0, zRotation);
    }

    private void TranslateTowardsTarget()
    {
        Vector2 position = transform.position;
        int randomStep = Random.Range(2, 6);
        int luckRoll = Random.Range(1, 21);

        if (luckRoll == 20)
        {
            randomStep = 1;
        }

        transform.position = position + (TargetPosition - position) / randomStep;
    }
}