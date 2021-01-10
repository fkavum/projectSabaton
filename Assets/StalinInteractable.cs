using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalinInteractable : Interactable
{
    public override void GetInteracted(Player player)
    {
        if (!Scene3Manager.instance.isPlayerHasQuest)
        {
            Scene3Manager.instance.isPlayerHasQuest = true;
            Scene3Manager.instance.stalinGiveQuestText.gameObject.SetActive(true);
            StartCoroutine(HideText());
        }
        else
        {
            Scene3Manager.instance.isLevelEnded = true;
            Scene3Manager.instance.stalinGiveRewardText.gameObject.SetActive(true);
            StartCoroutine(HideText2());

        }
    }

    IEnumerator HideText2()
    {
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene4");
    }

    IEnumerator HideText()
    {
        yield return new WaitForSeconds(5f);
        Scene3Manager.instance.stalinGiveQuestText.gameObject.SetActive(false);
    }

    public override string GetInteractionText()
    {
        if (Scene3Manager.instance.isPlayerHasQuest) return "Give quest to Stalin.";
        return "Say Hello to Stalin.";
    }

    public override bool IsInteractable(Player player)
    {
        if(!Scene3Manager.instance.isPlayerHasQuest || (Scene3Manager.instance.isPlayerFinishedQuest && Scene3Manager.instance.isPlayerHasQuest && !Scene3Manager.instance.isLevelEnded))
        {

            return true;
        }
        return false;
    }

    // Start is called before the first frame update

}
