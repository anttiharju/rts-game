using System.Collections;
using NUnit.Framework;
using RtsGame.Command;
using RtsGame.Units;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

namespace RtsGame.Tests.Editor
{
	public class CommandManagerTests
	{
		[UnityTest]
		public static IEnumerator TestThatOnlyUnitsOfOwnFactionCanBeCommanded()
		{
			EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
			var go = new GameObject("go");
			var commandManager = go.AddComponent<CommandManager>();
			var commandExecutorStub = go.AddComponent<CommandExecutorStub>();
			var rtsInputStub = go.AddComponent<RtsInputStub>();

			var serializedCommandManager = new SerializedObject(commandManager);
			serializedCommandManager.FindProperty("rtsInput")
					.objectReferenceValue = rtsInputStub;
			serializedCommandManager.FindProperty("commandExecutor")
								.objectReferenceValue = commandExecutorStub;

			serializedCommandManager.ApplyModifiedProperties();

			yield return new EnterPlayMode();

			go = GameObject.Find("go");
			rtsInputStub = go.GetComponent<RtsInputStub>();
			commandExecutorStub = go.GetComponent<CommandExecutorStub>();
			var f1 = ScriptableObject.CreateInstance<Faction>();
			var f2 = ScriptableObject.CreateInstance<Faction>();
			var friendlyUnit = new GameObject().AddComponent<Unit>();
			var enemyUnit = new GameObject().AddComponent<Unit>();
			var sfu = new SerializedObject(friendlyUnit);
			sfu.FindProperty("faction").objectReferenceValue = f1;
			var seu = new SerializedObject(enemyUnit);
			seu.FindProperty("faction").objectReferenceValue = f2;

			rtsInputStub.TriggerSelectOnUnit(enemyUnit);
			rtsInputStub.TriggerActionOnUnit(friendlyUnit);

			Assert.IsEmpty(commandExecutorStub.commands);
		}

	}
}