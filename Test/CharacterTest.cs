using NUnit.Framework;
using KataRPG.Domain;
using System;

namespace Tests
{
    [TestFixture]   
    public class CharacterTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NivelEguals()
        {
            var c1 = new Character(Nivel: 1);
            var c2 = new Character(Nivel: 1);
            c1.Damage(c2, 2);
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX-5, "Damage not work");
        }
        
        [Test]
        public void c1GreaterThanC2()
        {
            var c1 = new Character(Nivel: 6);
            var c2 = new Character(Nivel: 1);
            c1.Damage(c2, 2);
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX - (Character.HEALTH_SETP - (Character.HEALTH_SETP * Character.HEALTH_MODIFY_SETP)));
        }
        
        [Test]
        public void c2GreaterThanC1()
        {
            var c1 = new Character(Nivel: 1);
            var c2 = new Character(Nivel: 6);
            c1.Damage(c2, 2);
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX - (Character.HEALTH_SETP + (Character.HEALTH_SETP * Character.HEALTH_MODIFY_SETP)));
        }
        
        [Test]
        public void MeleeOutOfReach()
        {
            var c1 = new Character(Nivel: 1, Type: FighterType.Melee);
            var c2 = new Character(Nivel: 1, Type: FighterType.Melee);
            c1.Damage(c2, 4);
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX);
        }
        
        [Test]
        public void RangedOutOfReach()
        {
            var c1 = new Character(Nivel: 1, Type: FighterType.Ranged);
            var c2 = new Character(Nivel: 1, Type: FighterType.Melee);
            c1.Damage(c2, 44);
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX);
        }
        
        [Test]
        public void Dead()
        {
            var c1 = new Character(Nivel: 1);
            var c2 = new Character(Nivel: 1);
            for(var i=0; i<200; i++)
                c1.Damage(c2, 2);
            Assert.False(c2.Alive);
        }
        
        [Test]
        public void MaxHealth()
        {
            var c1 = new Character(Nivel: 1);
            var c2 = new Character(Nivel: 1);
            
            c1.Damage(c2, 2);
            for(var i=0; i<20; i++)
                c2.Heal(c2);

            Assert.AreEqual(Character.HEALTH_MAX, c2.Health);
        }
        
        [Test]
        public void HealthDead()
        {
            var c1 = new Character(Nivel: 1);
            var c2 = new Character(Nivel: 1);
            
            for(var i=0; i<201; i++)
                c1.Damage(c2, 2);
            c2.Heal(c2);

            Assert.False(c2.Alive);
        }
        
        [Test]
        public void AlliesDamage()
        {
            var c1 = new Character(Nivel: 1, Type: FighterType.Melee);
            var c2 = new Character(Nivel: 1, Type: FighterType.Melee);
            
            var faction = new Faction(Name: "Farc", Id: Guid.NewGuid());
            c1.JoinFaction(faction);
            c2.JoinFaction(faction);

            c1.Damage(c2, 1);
            
            Assert.AreEqual(c2.Health, Character.HEALTH_MAX);
        }
        
        [Test]
        public void AlliesHeal()
        {
            var c1 = new Character(Nivel: 1, Type: FighterType.Melee);
            var c2 = new Character(Nivel: 1, Type: FighterType.Melee);
            c1.Damage(c2, 1);
            
            var faction = new Faction(Name: "Farc", Id: Guid.NewGuid());
            c1.JoinFaction(faction);
            c2.JoinFaction(faction);

            c1.Heal(c2);

            Assert.AreEqual(c2.Health, Character.HEALTH_MAX);
        }
    }
}