using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFucker : MonoBehaviour
{
    [SerializeField] private GameObject GlitchArtifact;
    [SerializeField] private GameObject Scream;

    public delegate void GlitchDespawned();

    public static event GlitchDespawned OnGlitchDespawned;

    public static void FireOnGlitchDespawned()
    {
        OnGlitchDespawned?.Invoke();
    }
    
    private Camera MainCamera;
    
    private int NumberOfHoles = 0;
    private int MaxHoleQty = 100;

    private void OnEnable()
    {
        OnGlitchDespawned += DecrementGlitchCount;
        MainCamera = Camera.main;
    }

    private void OnDisable()
    {
        OnGlitchDespawned -= DecrementGlitchCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && NumberOfHoles < MaxHoleQty)
        {
            SpawnGlitchSquare();
        }

        if (NumberOfHoles == 0)
        {
            HideScream();
        }
        else
        {
            UpdateScream();
        }
        
        if (NumberOfHoles>=MaxHoleQty)
        {
            CrashGame();
        }
    }

    private void HideScream()
    {
        Scream.SetActive(false);
    }

    private void UpdateScream()
    {
        Scream.SetActive(true);
        
        Debug.Log("test");
        
        Utils.SetGOScale(Scream, Utils.MapToQuad(NumberOfHoles/((float)MaxHoleQty)));
    }

    public void DecrementGlitchCount()
    {
        NumberOfHoles--;
    }
    
    private void SpawnGlitchSquare()
    {
        Vector3 screenPosition = RandomScreenPosition();
        Instantiate(GlitchArtifact, screenPosition, Quaternion.identity);
        NumberOfHoles++;
    }

    private void CrashGame()
    {
        Debug.Log("Please crash");
    }

    private Vector3 RandomScreenPosition()
    {
        
        Vector2 target = MainCamera.ScreenToWorldPoint(
            new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0));
        //Automatically convert to Vec3, means Z=0
        return target;
    }
}