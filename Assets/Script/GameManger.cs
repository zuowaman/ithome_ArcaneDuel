using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
///// <summary>
/// 為了控制玩家和AI的數據結構（如生命值、法力值、法術選項），我們可以使用GameManager來管理這些核心數據。以下是Unity中一個簡單的GameManager範例，這個腳本負責初始化玩家和AI的生命值、法力值，並提供簡單的UI界面來顯示這些數值。
/// </summary>
public class GameManager : MonoBehaviour
{
    // 玩家和AI的數據
    public float playerHealth = 100;
    public float playerMana = 50;
    public float aiHealth = 100;
    public float aiMana = 50;

    // 連接到UI元件的引用
    public Slider playerHealthSlider;
    public Slider playerManaSlider;
    public Slider aiHealthSlider;
    public Slider aiManaSlider;

    // 初始化玩家和AI的生命值與法力值
    void Start()
    {
        UpdateUI(); // 初始化UI
    }
    private void Update()
    {
        UpdateUI();
    }
    // 更新UI顯示玩家和AI的生命值、法力值

    void UpdateUI()
    {
        playerHealthSlider.value=playerHealth/100;
        aiHealthSlider.value = aiHealth/100;
    }

    // 玩家和AI受到傷害時調用這個函數
    public void PlayerTakesDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth < 0) playerHealth = 0;
        UpdateUI();
    }

    public void AITakesDamage(int damage)
    {
        aiHealth -= damage;
        if (aiHealth < 0) aiHealth = 0;
        UpdateUI();
    }

    // 使用法術時減少法力值
    public void PlayerUsesMana(int manaCost)
    {
        playerMana -= manaCost;
        if (playerMana < 0) playerMana = 0;
        UpdateUI();
    }

    public void AIUsesMana(int manaCost)
    {
        aiMana -= manaCost;
        if (aiMana < 0) aiMana = 0;
        UpdateUI();
    }

    // 恢復玩家和AI的法力或生命值
    public void PlayerHeal(int healAmount)
    {
        playerHealth += healAmount;
        if (playerHealth > 100) playerHealth = 100;
        UpdateUI();
    }

    public void AIHeal(int healAmount)
    {
        aiHealth += healAmount;
        if (aiHealth > 100) aiHealth = 100;
        UpdateUI();
    }
}
