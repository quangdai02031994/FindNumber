using UnityEngine;
using System.Collections;

public class PrefabsController : MonoBehaviour {

    public UILabel number;
    public UISprite true_icon;
    public UISprite false_icon;

    private bool click = true;
    //private int request;
	void Start () {

	}
	
	void Update () {
	
	}

    public void showTrue_icon()
    {
       
            true_icon.gameObject.SetActive(true);
            false_icon.gameObject.SetActive(false);
    }

    public void showFalse_icon()
    {
        false_icon.gameObject.SetActive(true);
        true_icon.gameObject.SetActive(false);
    }


    public void ClickEvent()
    {
        if (click)
        {
            if (number.text == InGameController.Inst.ReturnRequest())
            {
                click = false;
                showTrue_icon();
                InGameController.Inst.IncreateTrueCount();
                SoundController.Inst.PlayTrueAudio();
                if (InGameController.Inst.ReturnTrueCount() < 99)
                    InGameController.Inst.ChangRequest();
            }
            else
            {
                showFalse_icon();
                SoundController.Inst.PlayFalseAudio();
                TimeController.Inst.IncreaseTime();
            }
        }
        
    }
}
