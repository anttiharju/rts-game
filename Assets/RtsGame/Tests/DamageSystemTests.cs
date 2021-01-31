using NUnit.Framework;
using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Tests
{
    [TestFixture]
    public class DamageSystemTests
    {
        [Test]
        public static void TestTakingDamage()
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
    }
}