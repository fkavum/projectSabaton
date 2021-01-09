using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LightArea : MonoBehaviour
{
    public Light lightSource;
    public AutoRotator rotator;
    public float noSpotAngle;
    public float yesSpotAngle;
    public float radius;
    public Vector3 center;
    bool isCought = false;
  

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center,radius/2.5f);
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, LayerMask.GetMask("Statics")))
        {
            radius = Mathf.Tan(lightSource.spotAngle*Mathf.Deg2Rad) * hit.distance;
            center = hit.point;
        }
        
        Collider[] colliders = Physics.OverlapSphere(center, radius / 2.5f, LayerMask.GetMask("Player"));
        
        if(colliders.Length > 0 )
        {
            PlayerCought();
        }
        else
        {
            PlayerGone();
        }
    }

    void PlayerCought()
    {
        if (isCought) return;
        isCought = true;
        lightSource.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        lightSource.spotAngle = yesSpotAngle;
        rotator.StopRotate();
    }

    void PlayerGone()
    {
        if (!isCought) return;
        isCought = false;
        lightSource.DOKill();
        lightSource.color = Color.white;
        lightSource.spotAngle = noSpotAngle;
        rotator.Rotate();
    }
}
