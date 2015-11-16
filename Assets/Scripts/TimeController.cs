using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

    public UILabel TimePlay;
    public UILabel bestTime;
    public GameObject buttonGo;

    public static TimeController Inst;

    private int countTime = 0;
    private float currentsecond = 0f;
    private string timePlay;

	void Start () {

        Inst = this;
        PlayerPrefs.SetString("bestTime", "99 : 99");
	}
	
	void Update () {

        bestTime.text = PlayerPrefs.GetString("bestTime");

        if (!buttonGo.activeSelf)
        {
            currentsecond += Time.deltaTime;
            if (currentsecond > 1)
            {
                countTime++;
                currentsecond = 0;
            }

            timePlay = ((countTime / 60) / 10).ToString() + ((countTime / 60) % 10).ToString() + " : " + ((countTime % 60) / 10).ToString() + ((countTime % 60) % 10).ToString();
            TimePlay.text = timePlay;

            if (InGameController.Inst.ReturnTrueCount() >= 99)
            {
                currentsecond = 0;
                PlayerPrefs.SetString("yourTime", timePlay);
            }
        }
        else
        {
            countTime = 0;
        }
	}


    public void IncreaseTime()
    {
        countTime += 5;
    }


    public void ResetTime()
    {
        countTime = 0;
    }
    
}
