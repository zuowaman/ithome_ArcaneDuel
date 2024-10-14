using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    // 玩家和AI的角色實例
    //public Skill.Character player;
    //public Skill.Character ai;

    // 連接到UI元件的引用
    public Slider playerHealthSlider;
    public Slider playerManaSlider;
    //public Slider aiHealthSlider;
    //public Slider aiManaSlider;

    // 初始化玩家和AI的生命值與法力值
    void Start()
    {
        //// 初始化玩家和AI角色
        //player = new Skill.Character("Player", 100, 50);
        //ai = new Skill.Character("AI", 100, 50);

        UpdateUI(); // 初始化UI
    }

    void Update()
    {
        UpdateUI(); // 實時更新UI

        //if(Input.GetKeyUp(KeyCode.Space)) 
        //{
        //    Debug.Log("玩家生命"+player.Health);
        //    Debug.Log("玩家魔力" + player.Mana);
        //}
    }

    // 更新UI顯示玩家和AI的生命值、法力值
    void UpdateUI()
    {
        playerHealthSlider.value = PlayerController.Instance.player.Health / 100;
        playerManaSlider.value = PlayerController.Instance.player.Mana / 100;
        //aiHealthSlider.value = ai.Health / 100;
        //aiManaSlider.value = ai.Mana / 100;
    }


}
