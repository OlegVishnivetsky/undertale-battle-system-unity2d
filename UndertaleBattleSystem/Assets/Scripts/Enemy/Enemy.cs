using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private string enemyName;

    [SerializeField] private Animator animator;
    [SerializeField] private BattleHandler battleHandler;

    [SerializeField] private List<AnimationClip> attackAnimations = new List<AnimationClip>();
    private List<string> attckAnimationNames = new List<string>();

    private const string DefaultAnimationClipName = "Default State";

    private void OnEnable()
    {
        BattleHandler.OnEnemyTurn += PlayRandomAttackAnimation;
    }

    private void OnDisable()
    {
        BattleHandler.OnEnemyTurn -= PlayRandomAttackAnimation;
    }

    private void Start()
    {
        foreach (var animation in attackAnimations)
        {
            attckAnimationNames.Add(animation.name);
        }
    }

    public string GetName()
    {
        return enemyName;
    }

    public void PlayRandomAttackAnimation()
    {
        Debug.Log("Play random attack animation method is working");
        animator.Play(attckAnimationNames[Random.Range(0, attackAnimations.Count - 1)]);
    }

    public void EndTurn()
    {
        battleHandler.SwitchBattleState(BattleState.PlayerTurn);
        animator.Play(DefaultAnimationClipName);
    }
}