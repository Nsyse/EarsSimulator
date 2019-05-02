using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchDespawner : VfxDespawner
{
    protected override bool ShouldntDespawn()
    {
        return Input.GetKey(KeyCode.A);
    }

    protected override void FireOnDespawn()
    {
        AAAAAAAAAAAAAAAAAAA.FireOnGlitchDespawned();
    }
}