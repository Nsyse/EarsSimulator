using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyToLoadScene : MonoBehaviour
{
    private bool alreadyLoading = false;
    private void Update()
    {
        if (Input.anyKey && !alreadyLoading)
        {
            alreadyLoading = true;
            StartGame();
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneNames.FadeScreen);
        SceneManager.LoadScene(SceneNames.Game, LoadSceneMode.Additive);
    }
}