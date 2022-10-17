using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        StopDamagedAnimation();
    }

    public void PlayDamagedAnimation()
    {
        animator.enabled = true;
    }

    public void StopDamagedAnimation()
    {
        animator.enabled = false;
    }
}
