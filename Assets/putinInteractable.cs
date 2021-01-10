using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class putinInteractable : Interactable
{
    public override void GetInteracted(Player player)
    {
        Scene1Manager.instance.PutinHasBottle();
    }

    public override string GetInteractionText()
    {
        return "Give Wodka!";
    }

    public override bool IsInteractable(Player player)
    {
        return player.inventory.hasBottle;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
