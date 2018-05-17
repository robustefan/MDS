using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StartingIndex {

	[Test]
	public void StartingIndexSimplePasses() 
	{
		Assert.AreEqual (0.025f, NeluSanduLeft.index);
		Assert.AreEqual (0.025f, NeluSanduRight.index);
	}


}
