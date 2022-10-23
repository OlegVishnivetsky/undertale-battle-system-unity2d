using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private int damage;

    [Header("Components")]
    [SerializeField] private BattleHandler battleHandler;
    [SerializeField] private EnemyHealth enemy;

    public void DamageEnemyAndEndTurn()
    {
        enemy.TakeDamage(damage);
        battleHandler.SwitchBattleState(BattleState.EnemyTurn);
    }
}