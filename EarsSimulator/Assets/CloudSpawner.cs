using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Cloud;
    [SerializeField] private GameObject Despawner;

    [SerializeField] private float SpawnInterval = 0.5f;
    
    [SerializeField]private float MinCloudSpeed = 1;
    [SerializeField]private float MaxCloudSpeed = 1;

    [SerializeField] private float MinOpacity;
    [SerializeField] private float MaxOpacity;
    
    [SerializeField] private float MinOffset;
    [SerializeField] private float MaxOffset;
    
    [SerializeField] private Color LightColor = Color.white;
    [SerializeField] private Color DarkestColor;

    

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>SpawnInterval)
        {
            timer = 0;
            SpawnCloud();
        }
    }

    private void SpawnCloud()
    {
        GameObject newCloud = Instantiate(Cloud, transform);

        float cloudSpeed = Random.Range(MinCloudSpeed, MaxCloudSpeed);

        float value = Random.Range(LightColor.r, DarkestColor.r);

        float a = Random.Range(MinOpacity, MaxOpacity);
        
        Color cloudColor = new Color(value,value,value,a);

        float yOffset = Random.Range(MinOffset, MaxOffset);
        
        newCloud.GetComponent<Cloud>().InitCloud(cloudSpeed, cloudColor, Despawner.transform.position.x, yOffset);
    }
}
