using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class OreHpTest {

	[Test]
	public void OreHpTestSimplePasses() 
	{

		Assert.AreEqual(3,NeluSanduRight.default_hp);
		Assert.AreEqual (3, NeluSanduLeft.default_hp);
	}

	// Prin acest test se verifica faptul ca HP-ul default al minereurilor este mereu 3 la inceput de joc.
}
