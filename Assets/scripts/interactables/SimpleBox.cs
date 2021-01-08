using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBox : Interactable
{

    public override void GetInteracted(Player player)
    {
        Destroy(gameObject);
    }

    public override string GetInteractionText()
    {
        return "Wuhahhahah";
    }
}
