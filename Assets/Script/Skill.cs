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

}
