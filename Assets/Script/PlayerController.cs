using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class PlayerController : MonoBehaviour
{
    // 單例
    public static PlayerController Instance { get; private set; }

    // 定義一個角色，這裡可以是玩家角色
    public Character player;

    // 定義技能
    private ISkill flameImpact;
    private ISkill healingLight;

    void Awake()
    {
        // 檢查是否已有實例存在，若有，則銷毀重複的實例
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // 遊戲場景切換時保持單例存在
        }

        // 初始化玩家
        player = new Character("Player", 100, 50); ;
    }

    void Start()
    {


        // 初始化技能，這裡引用之前的技能實現
        flameImpact = new FlameImpact();
        healingLight = new HealingLight();
    }

    void Update()
    {
    }

    public void PlayerUseHealingLight()
    {
        healingLight.UseSkill(player);
        Debug.Log("玩家魔力: " + player.Mana);
    }

    public void PlayerUseFlameImpact()
    {
        flameImpact.UseSkill(player);
    }
}
