using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    STARTGAME,
    GAMESETTING,
    INGAME,
    GAMEOVER
}
public class GameController : MonoBehaviour {

    public GameObject StartGame;
    public GameObject InGame;
    public GameObject SettingGame;
    public GameObject GameOver;

    public UIButton buttonGo;
    public UILabel hint_Number;

    private GameState currentGameState;
    
    


    public static GameController Inst;

    

	// Use this for initialization
	void Start () {

        Inst = this;

        CallStartGame();
	}
	
	// Update is called once per frame
	void Update () {

        switch (currentGameState)
        {
            case GameState.STARTGAME:
                {
                    InGame.SetActive(false);
                    StartGame.SetActive(true);
                    SettingGame.SetActive(false);
                    GameOver.SetActive(false);
                }
                break;
            case GameState.GAMESETTING:
                {
                    InGame.SetActive(false);
                    StartGame.SetActive(false);
                    SettingGame.SetActive(true);
                    GameOver.SetActive(false);
                }
                break;
            case GameState.INGAME:
                {
                    StartGame.SetActive(false);
                    InGame.SetActive(true);
                    SettingGame.SetActive(false);
                    GameOver.SetActive(false);
                    
                }
                break;
            case GameState.GAMEOVER:
                {
                    GameOver.SetActive(true);
                }
                break;
        }
	}

    public GameState CurrentGameState()
    {
        return currentGameState;
    }


    public void CallGameOver()
    {
        currentGameState = GameState.GAMEOVER;
    }
    public void CallInGame()
    {
        currentGameState = GameState.INGAME;
    }

    public void PlayGame()
    {
        buttonGo.gameObject.SetActive(false);
        SoundController.Inst.PlayGameAudio();
    }

    public void RestartGame()
    {
        InGameController.Inst.ResetGame();
        currentGameState = GameState.INGAME;
        TimeController.Inst.ResetTime();
        SoundController.Inst.PlayGameAudio();
    }

    public void CallStartGame()
    {
        currentGameState = GameState.STARTGAME;
        buttonGo.gameObject.SetActive(true);
        SoundController.Inst.PlayMenuAudio();
    }


    public void CallGameSetting()
    {
        currentGameState = GameState.GAMESETTING;
    }

	public void OpenContact(){
		Application.OpenURL ("http://thudomultimedia.vn/#contact");
	}

	public void OpenMoreGame(){
		Application.OpenURL ("http://thudomultimedia.vn/#home");
	}
   
    
}
