using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoX : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawIcon(transform.position, "CloudDespawner.png");
    }
}
