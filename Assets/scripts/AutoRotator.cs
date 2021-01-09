using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AutoRotator : MonoBehaviour
{

    public Vector3 endRotation;
    public Ease easeType;
    public float duration;
    bool isRotating = false;
    // Update is called once per frame
    private void Start()
    {
        Rotate();
    }

    public void Rotate() {

        if (isRotating) return;
        isRotating = true;
        
        transform.DORotate(Vector3.zero, 0.2f).OnComplete(() =>
        {
            transform.DORotate(endRotation, duration).SetLoops(-1, LoopType.Yoyo).SetEase(easeType);
        });
    }

    public void StopRotate()
    {
        if (!isRotating) return;
        isRotating = false;
        transform.DOKill();
    }
}
