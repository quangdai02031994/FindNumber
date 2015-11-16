using UnityEngine;
using System.Collections;

public enum SoundState
{
    ON,
    OFF
}

public class SoundController : MonoBehaviour {

    public AudioClip GameAudio;
    public AudioClip ButtonAudio;
    public AudioClip GameOverAudio;
    public AudioClip FalseClickAudio;
    public AudioClip TrueClickAudio;
    public AudioClip MenuAudio;
    public AudioClip WinGameAudio;
    
    public GameObject mutte;
    public static SoundController Inst;

    private SoundState currentSoundState;
    private int Count = 0;
    private AudioSource audio;


	void Start () {
        Inst = this;
        currentSoundState = SoundState.ON;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentSoundState)
        {
            case SoundState.ON:
                {

                }
                break;
            case SoundState.OFF:
                {

                }
                break;
        }
	}

    public void ChangState()
    {
        
        if (Count % 2 == 0)
        {
            currentSoundState = SoundState.OFF;
            mutte.SetActive(true);
            Count++;
            StopGameAudio();
        }
        else
        {
            currentSoundState = SoundState.ON;
            mutte.SetActive(false);
            Count++;
            PlayMenuAudio();
        }
        
    }

    public void PlayButtonAudio()
    {
        if (currentSoundState == SoundState.ON)
        {
            audio.PlayOneShot(ButtonAudio);
        }
       
    }

    public void PlayTrueAudio()
    {
        if (currentSoundState == SoundState.ON)
        {
            audio.PlayOneShot(TrueClickAudio);
        }
        
    }

    public void PlayFalseAudio()
    {

        if (currentSoundState == SoundState.ON)
        {
            audio.PlayOneShot(FalseClickAudio);
        }
        
    }

    public void PlayGameOverAudio()
    {
        if (currentSoundState == SoundState.ON)
        {
            audio.PlayOneShot(GameOverAudio);
        }
        
    }

    public void PlayGameAudio()
    {
        if (currentSoundState == SoundState.ON)
        {
            audio.clip = GameAudio;
            audio.Play();
            audio.loop = true;
        }
    }

    public void StopGameAudio()
    {
        audio.clip = GameAudio;
        audio.Stop();
    }

    public void PlayMenuAudio()
    {
        if (currentSoundState == SoundState.ON)
        {
            audio.clip = MenuAudio;
            audio.Play();
            audio.loop = true;
        }
    }

    public void StopMenuAudio()
    {
        audio.clip = MenuAudio;
        audio.Stop();
    }

    public SoundState GetSoundState()
    {
        return currentSoundState;
    }

}
