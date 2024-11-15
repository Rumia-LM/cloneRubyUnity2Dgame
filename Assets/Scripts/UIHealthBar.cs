using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance{get; private set;}
    public Image mask;
    float originalSize;
    // Start is called before the first frame update
    void Awake(){
        instance = this;
    }
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void SetValue(float value){

        float target = value * originalSize;
        DOTween.To(
            ()=>mask.rectTransform.rect.width,
            x => mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,x),
            target,
            0.5f
        ).SetEase(Ease.OutCubic);
        //mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,originalSize * value);
        
    }
}
