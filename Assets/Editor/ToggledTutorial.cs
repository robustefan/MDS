using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ToggledTutorial {

	[Test]
	public void ToggledTutorialSimplePasses() {
		int x;
		x = PlayerPrefs.GetInt ("Hide", 0);

		Assert.AreEqual (1, x);
	}


	// Prin acest test se verifica faptul ca la inceputul jocului, optiunea de "ascunde tutorialul" este dezactivata
}
