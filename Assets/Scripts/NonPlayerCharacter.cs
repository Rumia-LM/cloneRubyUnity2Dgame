using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class NonPlayerCharacter : MonoBehaviour
{
    //public float displayTime = 4f;
    Transform dialogBox;
    TextMeshProUGUI tmp;
    //float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox = transform.GetChild(0).gameObject.transform;
        dialogBox.localScale=Vector2.zero;

        tmp = dialogBox.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        //timerDisplay = -1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(timerDisplay >= 0){
            timerDisplay -=Time.deltaTime;
            if(timerDisplay < 0){
                dialogBox.SetActive(false);
            }
        }
        */
        
    }
    public void DisplayDialog(){
        //timerDisplay = displayTime;
        DOTween.Kill(dialogBox);
        dialogBox.DOScale(0.01f, 0.5f).SetEase(Ease.OutBounce);
        string fullText=tmp.text;

        tmp.text="";
        DOTween.To(
            ()=> tmp.text,
            x => tmp.text = x,
            fullText,
            0.05f * fullText.Length
        ).SetEase(Ease.Linear)
        .SetDelay(0.7f);


        dialogBox.DOScale(0f,0.2f)
        .SetEase(Ease.OutSine)
        .SetDelay(4f + 0.05f*fullText.Length);
    }
}
