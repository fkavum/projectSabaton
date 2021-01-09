using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Levelending_door : Interactable

{
    
    private bool isOpen = false;
    public Vector3 openVec3;
    public Vector3 closeVec3;
    public override void GetInteracted(Player player)
    {
        isInteractable = false;
        loadlevel("FatihScene");
        
    }

    public override string GetInteractionText()
    {
        if (isOpen)
            return "Open Door";
        else
            return "Open Door";
    }
    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);

    }
}
