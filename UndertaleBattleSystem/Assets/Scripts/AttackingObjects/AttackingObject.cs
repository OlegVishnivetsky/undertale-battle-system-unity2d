using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class AttackingObject : MonoBehaviour
{
    [SerializeField] protected int damage;

    public virtual void OnTriggerEnter2D(Collider2D other) { }

    public virtual void OnTriggerStay2D(Collider2D other) { }
}