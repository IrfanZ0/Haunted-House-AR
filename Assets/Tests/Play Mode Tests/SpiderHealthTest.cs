using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

using UnityEngine.TestTools;

namespace Tests
{
    public class SpiderHealthTest
    {
        private GameObject spider;
        private Spider_Health_Test sHealthTest;

        // A Test behaves as an ordinary method
        [Test]
        public void SpiderHealthTestSimplePasses ( )
        {
            spider = GameObject.Instantiate ( Resources.Load ( "spider Test" ) ) as GameObject;

            Assert.IsNotNull ( spider );

        }

        [UnityTest]
        public IEnumerator SpiderDeath ( )
        {
            spider = GameObject.Instantiate ( Resources.Load ( "spider Test" ) ) as GameObject;
            sHealthTest = spider.AddComponent<Spider_Health_Test> ( );
            float beforeDamageHealth = sHealthTest.GetCurrentHealth();
            yield return new WaitForSeconds ( 5f );
            sHealthTest.Damage ( 50f );
            float afterDamageHealth = sHealthTest.GetCurrentHealth();
            Assert.AreEqual ( 0 , afterDamageHealth );

        }

    }
}