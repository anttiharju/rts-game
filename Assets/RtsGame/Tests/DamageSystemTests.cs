using NUnit.Framework;
using RtsGame.Combat;
using UnityEngine;

namespace RtsGame.Tests
{
    [TestFixture]
    public class DamageSystemTests
    {
        [Test, Description("Test that damageable loses health amount equal to damager's attack damage")]
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

        [Test, Description("Test that damageable fires an event when health drops to 0")]
        public static void TestDying()
        {
            var damageableGo = new GameObject();
            var damageable = damageableGo.AddComponent<Damageable>();
            bool wasCalled = false;
            damageable.Death += () => wasCalled = true;
            damageable.Health = 100;
            damageable.Health = 0;
            Assert.IsTrue(wasCalled);
        }
    }
}