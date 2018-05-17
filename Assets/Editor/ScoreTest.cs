using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScoreTest {

	[Test]
	public void ScoreIncreaseTestSimplePasses() {

		for (int i = 0; i < 17; i++)
			ScoreCalculation.Adauga ();

		Assert.AreEqual (17, ScoreCalculation.getNr ());
		ScoreCalculation.number = 0;
	}

	// Prin acest test se verifica faptul ca scorul este uploadat corect
}
