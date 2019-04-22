using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyToLoadScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }
    }
}
