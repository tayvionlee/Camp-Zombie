using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public enum GameState
{
    SelectColor,
    PlayerTurn,
    EnemyTrun,
    Decide,
    Victory,
    Lose
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

    private void Start()
    {
        UpdateGameState(GameState.SelectColor);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.SelectColor:
                HandleSelectedColour();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTrun:
                HandleEnemyTurn();
                break;
            case GameState.Decide:
                HandleDecide();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
        // notify other components of state change
        OnGameStateChanged?.Invoke(newState);
    }

    #region HandleGameStates
    private void HandleSelectedColour()
    {
    }

    private void HandlePlayerTurn()
    {
    }

    private async void HandleEnemyTurn()
    {
        await Task.Delay(1000);
        // enemy attack
        UnitManager.Instance.Attack();
    }

    private void HandleDecide()
    {
        var units = FindAnyObjectByType<Unit>();
        // if(!units.Any)
    }

    private void HandleVictory()
    {
    }

    private void HandleLose()
    {
    }
    #endregion
}