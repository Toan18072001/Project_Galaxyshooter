using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum GameState
{
    Home,
    Gameplay,
    Pause,
    GameOver
}
public class GameManager : MonoBehaviour
{
    GameState m_GameState;
    [SerializeField] Home _home;
    [SerializeField] GamePlay _gameplay;
    [SerializeField] Pause _pause;
    [SerializeField] GameOver _gameover;
    SpawManager _spaw;
    bool Win_Lose;
    int score;
    [SerializeField] private Player_Script play;
    Vector3 vec = new Vector3(0.06f, -7.3f, 0);

    // Start is called before the first frame update
    void Start()
    {
        _home.gameObject.SetActive(true);
        _gameplay.gameObject.SetActive(false);
        _pause.gameObject.SetActive(false);
        _gameover.gameObject.SetActive(false);
        setState(GameState.Home);
        _spaw = FindObjectOfType<SpawManager>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setState(GameState gamestate)
    {
        m_GameState = gamestate;
        _home.gameObject.SetActive(gamestate == GameState.Home);
        _gameplay.gameObject.SetActive(gamestate == GameState.Gameplay);
        _pause.gameObject.SetActive(gamestate == GameState.Pause);
        _gameover.gameObject.SetActive(gamestate == GameState.GameOver);
        if (m_GameState == GameState.Pause)
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }
    public void _Play()
    {
        setState(GameState.Gameplay);
        score = 0;
        Player_Script _Play = Instantiate(play, vec, Quaternion.identity, null);
        _gameplay.display_score(score);
        _spaw.star_Starcoroutine();
    }
    internal void _Pause()
    {
        setState(GameState.Pause);
    }
    internal void _HOME()
    {
       
        setState(GameState.Home);
    }
    public void gameOver(bool status)
    {
        Win_Lose = status;
        setState(GameState.GameOver);
        _gameover.displayResult(Win_Lose);
        _gameover.setHightScore(score);
    }

    public void update_Score(int _score)
    {
        score += _score;
        _gameplay.display_score(score);
    }
}
