using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallinterractable : Interactable
{
    public bool pickable = false;

    private int rotateIndex = 0;

    public override void GetInteracted(Player player)
    {
        if (player.inventory.barrelcolor != Color.black) {
            gameObject.GetComponent<MeshRenderer>().material.color = player.inventory.barrelcolor;
        }
        

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
