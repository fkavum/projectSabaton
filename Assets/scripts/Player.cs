using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("interaction")]
    public float maxInteractionDistance;

    [NonSerialized]
    public PlayerInventory inventory;

    private void Start()
    {
        CreateInventory();
    }

    private void CreateInventory()
    {
        inventory = new PlayerInventory();
        inventory.hasBottle = false;
    }

    private void Update()
    {
        CheckInteractables();
    }

    private void CheckInteractables()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2));

        if (Physics.Raycast(ray, out hit, maxInteractionDistance, LayerMask.GetMask("Interactable")))
        {
            Interactable interactable = hit.collider.gameObject.GetComponentInParent<Interactable>();
            if (interactable.IsInteractable(this))
            {
                UIManager.instance.ShowInteractionText(interactable.GetInteractionText());

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.GetInteracted(this);
                }
            }
            else
            {
                UIManager.instance.HideInteractionText();
            }
        }
        else
        {
            UIManager.instance.HideInteractionText();
        }
    }
}


public struct PlayerInventory
{
    public bool hasBottle;

}