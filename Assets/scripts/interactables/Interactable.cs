using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool isInteractable = true;
    public abstract void GetInteracted(Player player);
    public abstract string GetInteractionText();
    public abstract bool IsInteractable(Player player);
}
