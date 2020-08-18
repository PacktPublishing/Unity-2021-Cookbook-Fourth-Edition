using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewTestScript
{
    [UnityTest]
    public IEnumerator GameObject_WithRigidBody_WillBeAffectedByPhysics()
    {
        var go = new GameObject();
        go.AddComponent<Rigidbody>();
        var originalPosition = go.transform.position.y;

        yield return new WaitForFixedUpdate();

        Assert.AreNotEqual(originalPosition, go.transform.position.y);
    }
}