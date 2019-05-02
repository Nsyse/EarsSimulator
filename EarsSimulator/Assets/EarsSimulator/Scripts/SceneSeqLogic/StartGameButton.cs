using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Canvas = null;

    [SerializeField] private CharacterMover mover = null;
    [SerializeField] private AAAAAAAAAAAAAAAAAAA sf = null;
    
    public void StartGame()
    {
        //Activate character Mover
        mover.enabled = true;
        sf.enabled = true;
        //Deactivate "Character creation elements"
        Canvas.SetActive(false);
    }
}
