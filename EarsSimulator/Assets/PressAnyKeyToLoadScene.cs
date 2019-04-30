using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyToLoadScene : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("CustomizationScreen");
        }
    }
}
