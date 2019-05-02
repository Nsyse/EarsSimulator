using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamSlot : MonoBehaviour
{
    [SerializeField] private GameObject ScreamParticle;
    [SerializeField] private float ScreamInterval;
    
    private bool IsScreaming = false;

    public void StartScreaming()
    {
        if (!IsScreaming)
        {
            InvokeRepeating(nameof(SpawnScreamParticle), 0, ScreamInterval);
            IsScreaming = true;
        }
    }

    public void StopScreaming()
    {
        //Debug.Log("Stop screm");
        CancelInvoke(nameof(SpawnScreamParticle));
        IsScreaming = false;
        NukeScreams();
    }
    
    private void SpawnScreamParticle()
    {
        Instantiate(ScreamParticle, transform);
    }

    public void NukeScreams()
    {
        Utils.DestroyAllChildren(gameObject);
    }
}
