using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Skill : MonoBehaviour
{
    public interface ISkill
    {
        string SkillName { get; }
        int ManaCost { get; }
        int Cooldown { get; }
        int CurrentCooldown { get; set; }

        void UseSkill(Character target);
        bool CanUseSkill(int currentMana);
    }
    public class Character
    {
        public string Name { get; set; }
        public float Health { get; set; }
        public float Mana { get; set; }

        public Character(string name, float health, float mana)
        {
            Name = name;
            Health = health;
            Mana = mana;
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Debug.Log($"{Name} takes {damage} damage. Health is now {Health}.");
        }

        public void Heal(float amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;  // ���]�̤j��q�� 100
            Debug.Log($"{Name} heals {amount}. Health is now {Health}.");
        }

        public void UseMana(float amount)
        {
            Mana -= amount;
            if (Mana < 0) Mana = 0;
            Debug.Log($"{Name} uses {amount} mana. Mana is now {Mana}.");
        }

        public void RestoreMana(float amount)
        {
            Mana += amount;
            if (Mana > 100) Mana = 100;
        }
    }

    public class FlameImpact : ISkill
    {
        public string SkillName => "Flame Impact";
        public int ManaCost => 12;
        public int Cooldown => 0;
        public int CurrentCooldown { get; set; } = 0;

        public void UseSkill(Character target)
        {
            if (CurrentCooldown == 0)
            {
                int damage = 20;
                target.TakeDamage(damage);
                target.UseMana(ManaCost);
                CurrentCooldown = Cooldown;
                Debug.Log($"{SkillName} hits {target.Name} for {damage} fire damage.");
            }
            else
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
            }
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }
    public class HealingLight : ISkill
    {
        public string SkillName => "Healing Light";
        public int ManaCost => 15;
        public int Cooldown => 0;
        public int CurrentCooldown { get; set; } = 0;

        public void UseSkill(Character target)
        {
            if (CurrentCooldown == 0)
            {
                int healingAmount = 25;
                target.Heal(healingAmount);
                target.UseMana(ManaCost);
                CurrentCooldown = Cooldown;
                Debug.Log($"{SkillName} heals {target.Name} for {healingAmount} HP.");
            }
            else
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
            }
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }
    public class ThunderChain : ISkill
    {
        public string SkillName => "Thunder Chain";
        public int ManaCost => 18;
        public int Cooldown => 5;
        public int CurrentCooldown { get; set; } = 0;

        public void UseSkill(Character target)
        {
            if (CurrentCooldown == 0)
            {
                int primaryDamage = 15;
                int secondaryDamage = 10;
                target.TakeDamage(primaryDamage);
                // ���]����L�ĤH�i�H�Q����
                // Implement secondary targets for the chain effect

                target.UseMana(ManaCost);
                CurrentCooldown = Cooldown;
                Debug.Log($"{SkillName} strikes {target.Name} for {primaryDamage} lightning damage, and chains to others.");
            }
            else
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
            }
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }
    public class ShadowCurse : ISkill
    {
        public string SkillName => "Shadow Curse";
        public int ManaCost => 14;
        public int Cooldown => 3;
        public int CurrentCooldown { get; set; } = 0;

        public void UseSkill(Character target)
        {
            if (CurrentCooldown == 0)
            {
                int damage = 15;
                target.TakeDamage(damage);
                target.UseMana(ManaCost);
                CurrentCooldown = Cooldown;
                Debug.Log($"{SkillName} curses {target.Name}, dealing {damage} shadow damage and reducing their attack.");
            }
            else
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
            }
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }


    //�ĤH�ޯ�
    public class FatalStrike : ISkill
    {
        public string SkillName => "Fatal Strike";
        public int ManaCost => 20;
        public int Cooldown => 5;
        public int CurrentCooldown { get; set; }

        public void UseSkill(Character target)
        {
            // �p�G�N�o�ɶ������A����ϥΧޯ�
            if (CurrentCooldown > 0)
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
                return;
            }

            float damage = 40; // ���]�y���T�w�� 40 �I�ˮ`
            target.TakeDamage(damage);

            // �p�G�ؼЪ���q�C�� 20%�A��������
            if (target.Health < target.Health * 0.2f)
            {
                Debug.Log("Fatal Strike: Instant kill activated!");
                target.Health = 0;
            }

            // ���m�N�o�ɶ�
            CurrentCooldown = Cooldown;
            Debug.Log($"{SkillName} is used on {target.Name}. Cooldown is now {Cooldown} turns.");
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }
    public class ShadowCloak : ISkill
    {
        public string SkillName => "Shadow Cloak";
        public int ManaCost => 15;
        public int Cooldown => 6;
        public int CurrentCooldown { get; set; }

        public void UseSkill(Character user)
        {
            if (CurrentCooldown > 0)
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
                return;
            }

            // �t�v�����ĪG�A���ɧ����O�ó]�m����
            Debug.Log($"{user.Name} has become invisible!");
            // ���]���a�i�J�������A���N�X�M�޿�]�p�����O���ɡ^

            // ���m�N�o�ɶ�
            CurrentCooldown = Cooldown;
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }
    public class PoisonedBlade : ISkill
    {
        public string SkillName => "Poisoned Blade";
        public int ManaCost => 10;
        public int Cooldown => 4;
        public int CurrentCooldown { get; set; }

        public void UseSkill(Character target)
        {
            if (CurrentCooldown > 0)
            {
                Debug.Log($"{SkillName} is on cooldown for {CurrentCooldown} more turns.");
                return;
            }

            // ��ؼЬI�[����r�ʶˮ`
            Debug.Log($"{target.Name} is poisoned! Will take poison damage over time.");
            // ���]�ؼФ��r���N�X�]�Ҧp�b�C�^�X�ͮĪ��ˮ`�޿�^

            // ���m�N�o�ɶ�
            CurrentCooldown = Cooldown;
        }

        public bool CanUseSkill(int currentMana)
        {
            return currentMana >= ManaCost && CurrentCooldown == 0;
        }
    }

}

