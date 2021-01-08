using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI interactionText;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        HideInteractionText();
    }

    public void ShowInteractionText(string text)
    {
        interactionText.gameObject.SetActive(true);
        interactionText.text = "[E] " + text;
    }

    public void HideInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }


   
}
