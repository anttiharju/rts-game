﻿using NUnit.Framework;
using RtsGame.GameSystems;
using RtsGame.GameSystems.Command;
using RtsGame.Units;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace RtsGame.Tests.Editor
{
    public class CommandManagerTests
    {
        [Test]
        public static void EnemyUnitsCanNotBeCommanded()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var friendlyFaction = ScriptableObject.CreateInstance<Faction>();
            var enemyFaction = ScriptableObject.CreateInstance<Faction>();

            var commandExecutorStub = new CommandExecutorStub();
            var rtsInputStub = new RtsInputStub();
            var selectionSystem = new SelectionSystem(rtsInputStub, friendlyFaction);
            new CommandManager(friendlyFaction, rtsInputStub, commandExecutorStub, selectionSystem);

            var friendlyUnit = new GameObject().AddComponent<Unit>();
            var enemyUnit = new GameObject().AddComponent<Unit>();
            friendlyUnit.Faction = friendlyFaction;
            enemyUnit.Faction = enemyFaction;

            rtsInputStub.TriggerSelectOnUnit(enemyUnit);
            rtsInputStub.TriggerActionOnUnit(friendlyUnit);

            Assert.IsEmpty(commandExecutorStub.commands);
        }

        [Test]
        public static void OwnUnitsCanBeCommanded()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var friendlyFaction = ScriptableObject.CreateInstance<Faction>();
            var enemyFaction = ScriptableObject.CreateInstance<Faction>();

            var commandExecutorStub = new CommandExecutorStub();
            var rtsInputStub = new RtsInputStub();
            var selectionSystem = new SelectionSystem(rtsInputStub, friendlyFaction);
            new CommandManager(friendlyFaction, rtsInputStub, commandExecutorStub, selectionSystem);

            var friendlyUnit = new GameObject().AddComponent<Unit>();
            var enemyUnit = new GameObject().AddComponent<Unit>();
            friendlyUnit.Faction = friendlyFaction;
            enemyUnit.Faction = enemyFaction;

            rtsInputStub.TriggerSelectOnUnit(friendlyUnit);
            rtsInputStub.TriggerActionOnUnit(enemyUnit);

            Assert.AreEqual(1, commandExecutorStub.commands.Count);
            Assert.IsInstanceOf<AttackCommand>(commandExecutorStub.commands[0]);
        }

    }
}
