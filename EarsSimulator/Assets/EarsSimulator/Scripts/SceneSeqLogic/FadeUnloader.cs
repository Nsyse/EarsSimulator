using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeUnloader : MonoBehaviour
{
    private void OnEnable()
    {
        ColorEnableFader.OnFadeCompleted += UnloadFadeScreen;
    }

    private void UnloadFadeScreen(string fadedobjectname)
    {
        if (fadedobjectname == "blackscreen")
        {
            SceneManager.UnloadSceneAsync("ScreenFade");
        }
    }
}
