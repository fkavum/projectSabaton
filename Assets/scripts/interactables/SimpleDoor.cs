using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimpleDoor : Interactable
{
    private bool isOpen = false;
    public Vector3 openVec3;
    public Vector3 closeVec3;
    public override void GetInteracted(Player player)
    {
        isInteractable = false;
        if (isOpen)
            transform.DORotate(closeVec3, 0.5f).OnComplete  ( () => { isOpen = false;  isInteractable = true; });
        else
            transform.DORotate(openVec3, 0.5f).OnComplete  ( () => { isOpen = true; isInteractable = true; });
    }

    public override string GetInteractionText()
    {
        if (isOpen)
            return "FBI open the door";
        else
            return "FBI close the door!";
    }

}
