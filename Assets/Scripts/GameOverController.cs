using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

    public AudioClip GameOverAudio;
    public UILabel messageGame;
    public UILabel TimeGame;

    private string yourTime;
    private string bestTime;
    private bool playSound = true;


    private int result;
    private AudioSource audio;

	// Use this for initialization

    
	void Start () {

        audio = GetComponent<AudioSource>();
	}

    void OnDisable()
    {
        playSound = true;
        
    }
	// Update is called once per frame
	void Update () {

        GameWin();
        if (SoundController.Inst.GetSoundState() == SoundState.ON && playSound)
        {
            PlaySound();
            playSound = false;
        }
	}

    private void PlaySound()
    {
        audio.PlayOneShot(GameOverAudio);
        Debug.Log(SoundController.Inst.GetSoundState());
    }

    public void GameWin()
    {

        messageGame.text = "You win !!!!" + "\n" + "Do you want play more";
        yourTime = PlayerPrefs.GetString("yourTime");
        bestTime = PlayerPrefs.GetString("bestTime");
        result = string.Compare(yourTime, bestTime);
        if (result <= 0)
        {
            PlayerPrefs.SetString("bestTime", PlayerPrefs.GetString("yourTime"));
            TimeGame.text = "New best time: " + PlayerPrefs.GetString("bestTime");
        }
        else
        {
            TimeGame.text = "Your time: " + PlayerPrefs.GetString("yourTime");
        }
    }
}
