using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUI : MonoBehaviour
{
    [Header("Player Health UI")]
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TMP_Text healthTMP;
    [SerializeField] private Slider playerHealthSlider;
    [Header("Enemy Health UI")]
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Slider enemyHealthSlider;
    [SerializeField] private float sliderShownTime;
    [Header("Components")]
    [SerializeField] private PlayerMovement player;
    [SerializeField] private Enemy enemy;
    [Header("Battle UI")]
    [SerializeField] private GameObject battleAreaPanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private TabGroup tabGroup;
    [SerializeField] private TMP_Text enemyNameTMP;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdatePlayerHealthUI;
        enemyHealth.OnHealthChanged += UpdateEnemyHealthUI;

        BattleHandler.OnPlayerTurn += SetUpPlayerTurn;
        BattleHandler.OnEnemyTurn += SetUpEnemyTurn;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdatePlayerHealthUI;
        enemyHealth.OnHealthChanged -= UpdateEnemyHealthUI;

        BattleHandler.OnPlayerTurn -= SetUpPlayerTurn;
        BattleHandler.OnEnemyTurn -= SetUpEnemyTurn;
    }

    private void Start()
    {
        enemyNameTMP.text = enemy.GetName();
        enemyHealthSlider.enabled = false;
    }

    private void UpdatePlayerHealthUI(int currentHealth, int maxHealth)
    {
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = currentHealth;
        healthTMP.text = $"{currentHealth}/{maxHealth}";
    }

    private void UpdateEnemyHealthUI(int currentHealth, int maxHealth)
    {
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = currentHealth;
    }

    private void SetUpPlayerTurn()
    {
        menuPanel.SetActive(true);
        battleAreaPanel.SetActive(false);

        tabGroup.EnableButtonsInteraction();
    }

    private void SetUpEnemyTurn()
    {
        menuPanel.SetActive(false);
        battleAreaPanel.SetActive(true);

        tabGroup.DisableButtonsInteraction();
    }
}