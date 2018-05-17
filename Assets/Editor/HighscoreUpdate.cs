using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class HighscoreUpdate {

	[Test]
	public void HighscoreUpdateSimplePasses() {

		ScoreCalculation.number = int.MaxValue - 1;

		ScoreCalculation.cs ();

		int last_highscore = PlayerPrefs.GetInt ("Highscore", 0);

		Assert.AreEqual (ScoreCalculation.number, PlayerPrefs.GetInt ("Highscore", 0));

		ScoreCalculation.number = 0;
		PlayerPrefs.SetInt ("Highscore", 0);


	}

	// Acest test ne asigura ca, atunci cand obtinem un nou HighScore, acesta va fi actualizat

}
