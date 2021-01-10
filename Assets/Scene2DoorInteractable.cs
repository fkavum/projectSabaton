using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2DoorInteractable : Interactable
{

    public override void GetInteracted(Player player)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene3");
    }

    public override string GetInteractionText()
    {
        return "Open Door.";
    }

    public override bool IsInteractable(Player player)
    {
        return Scene1Manager.instance.isLevelEnd;
    }

}
