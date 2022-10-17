using UnityEngine;

public class BattleAreaSettings : MonoBehaviour
{
    [SerializeField] private RectTransform battleAreaRectTransform;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Vector2 playerStartingPosition;

    [SerializeField] private float offset;

    private Rect battleAreaRect;

    private void OnEnable()
    {
        BattleHandler.OnPlayerTurn += SetUpPlayerTurn;
        BattleHandler.OnEnemyTurn += SetUpEnemyTurn;
    }

    private void OnDisable()
    {
        BattleHandler.OnPlayerTurn -= SetUpPlayerTurn;
        BattleHandler.OnEnemyTurn -= SetUpEnemyTurn;
    }

    private void Start()
    {
        battleAreaRect = HelperUtility.GetWorldRect(battleAreaRectTransform);
    }

    private void Update()
    { 
        if (player.IsCanMove)
            ClampPlayaerPosition();
    }

    private void ClampPlayaerPosition()
    {
        player.transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, battleAreaRect.xMin + offset, battleAreaRect.xMax - offset),
            Mathf.Clamp(player.transform.position.y, battleAreaRect.yMin + offset, battleAreaRect.yMax - offset), 0);
    }
    
    private void SetUpPlayerTurn()
    {
        player.DisablePlayerMovement();
    }

    private void SetUpEnemyTurn()
    {
        SetPlayerStartingPostition();
        player.EnablePlayerMovement();
    }

    public void SetPlayerStartingPostition()
    {
        player.SetPlayerPosition(playerStartingPosition);
    }
}