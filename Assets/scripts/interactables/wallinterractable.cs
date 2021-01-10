using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallinterractable : Interactable
{
    public bool pickable = false;

    private int rotateIndex = 0;

    public override void GetInteracted(Player player)
    {
        gameObject.GetComponent<MeshRenderer>().material.color = player.inventory.barrelcolor;
        Scene3Manager.instance.CheckQuestStatus();
    }

    public override string GetInteractionText()
    {
        if (rotateIndex < 2)
        {
            return "Interact";
        }
        else
        {
            return "Come On";
        }
    }

    public override bool IsInteractable(Player player)
    {
        return (player.inventory.barrelcolor != Color.black);

    }

    // Start is called before the first frame update
    void Start()
    {
        Scene3Manager.instance.materials.Add(gameObject.GetComponent<MeshRenderer>().material);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
