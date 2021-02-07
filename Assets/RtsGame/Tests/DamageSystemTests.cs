using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;
using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Tests
{
    [TestFixture]
    public class DamageSystemTests
    {
        [Test, Description("Test that damageable loses health amount equal to damager\'s attack damage")]
        public static void TakingDamage()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            damageable.Health = 100;
            
            var damagerGo = new GameObject();
            var damager = damagerGo.AddComponent<Damager>();
            damager.AttackDamage = 10;

            int healthBefore = damageable.Health;
            damager.Attack(damageable);
            int healthAfter = damageable.Health;
         
            Assert.AreEqual(healthBefore - damager.AttackDamage, healthAfter);
        }

        [Test, Description("Test that damageable fires an event when health drops to 0")]
        public static void Dying()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            bool wasCalled = false;
            damageable.Death += () => wasCalled = true;
            damageable.Health = 100;
            damageable.Health = 0;
            Assert.IsTrue(wasCalled);
        }
        
        [Test, Description("Test that damageable doesn't fire Death event when health stays above 0")]
        public static void NotDying()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            bool wasCalled = false;
            damageable.Death += () => wasCalled = true;
            damageable.Health = 100;
            damageable.Health -= 10;
            Assert.IsFalse(wasCalled);
        }
        
        [Test, Description("Test that damageable fires an event when health is reduced")]
        public static void Damaged()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            bool wasCalled = false;
            damageable.Damaged += () => wasCalled = true;
            damageable.Health = 100;
            damageable.Health -= 10;
            Assert.IsTrue(wasCalled);
        }

        [Test, Description("Test that damageable fires both damaged and death events when health is reduced to 0")]
        public static void DamagedWhenDying()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            List<string> events = new List<string>();

            damageable.Damaged += () => events.Add("Damaged");
            damageable.Death += () => events.Add("Death");
            
            damageable.Health = 100;
            damageable.Health = 0;

            List<string> expected = new List<string>() {"Damaged", "Death"};
            CollectionAssert.AreEqual(expected, events);
        }
    }
}