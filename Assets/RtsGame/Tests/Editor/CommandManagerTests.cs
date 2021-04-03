using NUnit.Framework;
using RtsGame.Command;
using RtsGame.Units;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace RtsGame.Tests.Editor
{
    public class CommandManagerTests
    {
        [Test]
        public static void TestThatOnlyUnitsOfOwnFactionCanBeCommanded()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var friendlyFaction = ScriptableObject.CreateInstance<Faction>();
            var enemyFaction = ScriptableObject.CreateInstance<Faction>();

            var commandExecutorStub = new CommandExecutorStub();
            var rtsInputStub = new RtsInputStub();
            var commandManager = new CommandManager(friendlyFaction, rtsInputStub, commandExecutorStub);

            var friendlyUnit = new GameObject().AddComponent<Unit>();
            var enemyUnit = new GameObject().AddComponent<Unit>();
            friendlyUnit.Faction = friendlyFaction;
            enemyUnit.Faction = enemyFaction;

            rtsInputStub.TriggerSelectOnUnit(enemyUnit);
            rtsInputStub.TriggerActionOnUnit(friendlyUnit);

            Assert.IsEmpty(commandExecutorStub.commands);
        }

    }
}