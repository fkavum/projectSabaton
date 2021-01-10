using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening.Plugins.Core.PathCore;

public class Putin_ai : MonoBehaviour
{

    public Animator animator;
    public Transform[] pathTransforms;

    void Start()
    {
   
        StartCoroutine(PutinMove1());

    }


    IEnumerator PutinMove1()
    {

        yield return new WaitForSeconds(1f);

        animator.Play("Putin_sit_to_stand");

        yield return new WaitForSeconds(2f);
        animator.Play("Putin_idle");
        yield return new WaitForSeconds(0.5f);


        List<Vector3> path = new List<Vector3>();
        foreach (var pathTransform in pathTransforms)
        {
            path.Add(pathTransform.position);
        }
        Vector3[] pathArray = path.ToArray();



        TweenerCore<Vector3, Path, PathOptions> tween = transform.DOPath(pathArray, 4, PathType.CatmullRom, PathMode.Full3D).OnStart(() => { animator.Play("putinWalking"); }).OnComplete(() => {

            animator.Play("Putin_idle");

        }).SetLookAt(0.001f, -transform.forward, transform.up).SetEase(Ease.Linear).SetAutoKill(false);

        yield return new WaitForSeconds(10f);
        Scene1Manager.instance.isPutinTalked = true;
        tween.PlayBackwards();
        tween.SetLookAt(0.001f,transform.forward,transform.up);
        animator.Play("putinWalking");
        yield return new WaitForSeconds(4.2f);
        animator.Play("Putin_idle");
        transform.DORotate(new Vector3(0, 180, 0), 1f).OnComplete(()=> {
            animator.Play("Putin_sit");
        });

    }

    void Update()
    {
    }


    public void turn()
    {
        Debug.Log("turned");
    }
    public void walk()
    {
        Debug.Log("Walked");
    }
}
