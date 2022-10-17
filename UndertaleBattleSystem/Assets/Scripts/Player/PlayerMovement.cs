using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;

    public bool IsCanMove { get; private set; }

    private Vector2 input;

    private void Update()
    {
        CalculatePlayerInput();
    }

    private void FixedUpdate()
    {
        if (IsCanMove)
            MovePlayer();
    }

    public Vector2 GetPlayerVelocity()
    {
        return rigidbody2D.velocity;
    }

    public void SetPlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void EnablePlayerMovement()
    {
        IsCanMove = true;
    }

    public void DisablePlayerMovement()
    {
        rigidbody2D.velocity = Vector2.zero;
        IsCanMove = false;
    }

    private void MovePlayer()
    {
        rigidbody2D.velocity = input * speed * Time.fixedDeltaTime;
    }

    private void CalculatePlayerInput()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}