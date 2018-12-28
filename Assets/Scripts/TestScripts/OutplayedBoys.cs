using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEditor;
using UnityEngine;

public class OutplayedBoys : MonoBehaviour {

	public TextMeshPro text;

	private float counter = 0;
	private int times = 0;
	private bool state = false;

	// Update is called once per frame
	void Update() {
		counter += Time.deltaTime;

		if (counter >= 1f && state == true) {
			times++;
			ClearLogConsole();
			text.text = "Ha! Gayyy!";
			Debug.Log("Times Called Gay: " + times);
			counter = 0;
			state = !state;
		}

		if (counter >= 1f && state == false) {
			text.text = "";
			counter = 0;
			state = !state;
		}
	}

	#region Magic
	static MethodInfo _clearConsoleMethod;
	static MethodInfo clearConsoleMethod {
		get {
			if (_clearConsoleMethod == null) {
				Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
				var logEntries = assembly.GetType("UnityEditor.LogEntries");
				_clearConsoleMethod = logEntries.GetMethod("Clear");
			}
			return _clearConsoleMethod;
		}
	}

	public static void ClearLogConsole() {
		clearConsoleMethod.Invoke(new object(), null);
	}
	#endregion
}
