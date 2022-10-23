using System;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    Victory,
    Defeat
}

public class BattleHandler : MonoBehaviour
{
    private BattleState currentBattleState;

    public static event Action OnBattleStateChanged;
    public static event Action OnPlayerTurn;
    public static event Action OnEnemyTurn;

    private void Start()
    {
        SwitchBattleState(BattleState.Start);
    }

    private void Update()
    {
        Debug.Log(currentBattleState);
    }

    public void SwitchToEnemyTurn()
    {
        SwitchBattleState(BattleState.EnemyTurn);
    }

    public void SwitchBattleState(BattleState battleState)
    {
        currentBattleState = battleState;
        OnBattleStateChanged?.Invoke();

        switch (currentBattleState)
        {
            case BattleState.Start:
                SwitchBattleState(BattleState.PlayerTurn);
                break;
            case BattleState.PlayerTurn:
                OnPlayerTurn?.Invoke();
                break;
            case BattleState.EnemyTurn:
                OnEnemyTurn?.Invoke();
                break;
            case BattleState.Victory:
                break;
            case BattleState.Defeat:
                break;
        }
    }
}