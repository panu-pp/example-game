using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoSingleton<StateManager>
{
    public enum GameState
    {
        Home,
        Play,
        Lose
    }

    public GameState gameState;


    private Coroutine _onPlayCorroutine;

    public void SwitchState(GameState state)
    {
        gameState = state;
        Debug.Log($"Game State: {gameState}");

        switch (gameState)
        {
            case GameState.Home:
                OnHome();
                break;
            case GameState.Play:
                OnPlay();
                break;
            case GameState.Lose:
                OnLose();
                break;
        }
    }

    #region STATE ACTION

    private void OnHome()
    {
        GameManager.Instance.SetPaused(true);
        HomeUI.Instance.ToggleHomeUI(true);
    }

    private void OnPlay()
    {
        GameManager.Instance.SetPaused(false);
        HomeUI.Instance.ToggleHomeUI(false);
        PlayerController.Instance.ResetPlayer();
        ScoreManager.Instance.ResetScore();
        ObstacleManager.Instance.ResetObstacle();
        ObstacleManager.Instance.SpwanObstacle();
    }
    
    private void OnLose()
    {
        GameManager.Instance.SetPaused(true);
        HomeUI.Instance.ToggleHomeUI(true);
    }

    #endregion

}
