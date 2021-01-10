using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class interacble_barrel : Interactable
{
    public bool pickable = false;

    private int rotateIndex = 0;

    public override void GetInteracted(Player player)
    {
        isInteractable = false;
        if (rotateIndex < 2)
        {
            transform.DORotate(new Vector3(0, 90, 0), 0.5f).OnComplete(() => { isInteractable = true; }).SetRelative();
            MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
            Material barrelmat;
            if (mr.materials.Length > 1)
            {
                barrelmat = mr.materials[1];

            }  
            else
            {
                barrelmat = mr.material;
            }
            player.inventory.barrelcolor = barrelmat.color;

            if (pickable)
            {
                rotateIndex++;
            }
        }
        else
        {
            //player.inventory.hasBottle = true;
            //Destroy(gameObject);
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

    public override bool IsInteractable(Player player)
    {
        return isInteractable;
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
