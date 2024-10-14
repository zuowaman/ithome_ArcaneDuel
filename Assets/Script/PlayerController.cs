using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class PlayerController : MonoBehaviour
{
    // ���
    public static PlayerController Instance { get; private set; }

    // �w�q�@�Ө���A�o�̥i�H�O���a����
    public Character player;

    // �w�q�ޯ�
    private ISkill flameImpact;
    private ISkill healingLight;

    void Awake()
    {
        // �ˬd�O�_�w����Ҧs�b�A�Y���A�h�P�����ƪ����
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // �C�����������ɫO����Ҧs�b
        }

        // ��l�ƪ��a
        player = new Character("Player", 100, 50); ;
    }

    void Start()
    {


        // ��l�Ƨޯ�A�o�̤ޥΤ��e���ޯ��{
        flameImpact = new FlameImpact();
        healingLight = new HealingLight();
    }

    void Update()
    {
    }

    public void PlayerUseHealingLight()
    {
        healingLight.UseSkill(player);
        Debug.Log("���a�]�O: " + player.Mana);
    }

    public void PlayerUseFlameImpact()
    {
        flameImpact.UseSkill(player);
    }
}
