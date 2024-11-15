using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthCollectable : MonoBehaviour
{
    void Start(){
        /*
        transform.DOScale(Vector3.one*1.2f,0.5f)
        .SetLoops(-1,LoopType.Yoyo);
        */
        DOTween.To(
            ()=>transform.localScale,
            x => transform.localScale=x,
            Vector3.one * 1.2f,
            0.5f
        ).SetLoops(-1,LoopType.Yoyo)
        .SetEase(Ease.InOutCubic);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("triggerと接触:"+other);
        RubyController rubyCon = other.GetComponent<RubyController>();
        if(rubyCon != null){
            if(rubyCon.health == rubyCon.maxHealth) return;
            rubyCon.ChangeHealth(1);
            Destroy(gameObject);
        }
        
    }

}
