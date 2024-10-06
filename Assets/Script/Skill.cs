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
        public int Health { get; set; }
        public int Mana { get; set; }

        public Character(string name, int health, int mana)
        {
            Name = name;
            Health = health;
            Mana = mana;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Debug.Log($"{Name} takes {damage} damage. Health is now {Health}.");
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;  // 假設最大血量為 100
            Debug.Log($"{Name} heals {amount}. Health is now {Health}.");
        }

        public void UseMana(int amount)
        {
            Mana -= amount;
            if (Mana < 0) Mana = 0;
            Debug.Log($"{Name} uses {amount} mana. Mana is now {Mana}.");
        }
    }

    public class FlameImpact : ISkill
    {
        public string SkillName => "Flame Impact";
        public int ManaCost => 12;
        public int Cooldown => 3;
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
        public int Cooldown => 4;
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
                // 假設有其他敵人可以被擊中
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

}

