﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class InteractableBottle : Interactable
{
    public bool pickable = false;

    private int rotateIndex = 0;
    
    public override void GetInteracted(Player player)
    {
        isInteractable = false;
        if(rotateIndex < 2)
        {
            transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() => { isInteractable = true; }).SetRelative();

            if (pickable)
            {
                rotateIndex++;
            }
        }
        else
        {
            player.inventory.hasBottle = true;
            Destroy(gameObject);
        }
    }

    public override string GetInteractionText()
    {
        if (rotateIndex < 2)
        {
            return "Rotate me baby";
        }
        else
        {
            return "pick my dear wodka!";
        }
    }
}
