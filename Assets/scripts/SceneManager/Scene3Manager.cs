using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Scene3Manager : MonoBehaviour
{
    public static Scene3Manager instance;

    public bool isPlayerHasQuest = false;
    public bool isPlayerFinishedQuest = false;
    public bool isLevelEnded = false;

    public TextMeshProUGUI stalinGiveQuestText;
    public TextMeshProUGUI stalinGiveRewardText;

    public List<Material> materials;
    public Material referenceMat;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        stalinGiveQuestText.gameObject.SetActive(false);
        stalinGiveRewardText.gameObject.SetActive(false);
    }

    public void CheckQuestStatus()
    {
        isPlayerFinishedQuest = true;
        foreach (var mats in materials)
        {
            if (mats.color != referenceMat.color) isPlayerFinishedQuest = false;
            return;
        }
    }
}
