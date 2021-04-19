using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CalculateVelocity
    {

        // A Test behaves as an ordinary method
        [Test]
        public void CalculateVelocitySimplePasses ( )
        {
            LaunchPotionTest lPotionTest = GameObject.FindGameObjectWithTag("Player").transform.Find("AR Camera").transform.Find("Weapon Spot").transform.Find("Blue Snake Potion").GetComponent<LaunchPotionTest>();
            Assert.IsNotNull ( lPotionTest.CalculateVelocity ( ) );
        }

    }
}