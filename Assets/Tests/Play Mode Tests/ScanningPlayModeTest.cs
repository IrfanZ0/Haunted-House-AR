using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScanningPlayModeTest
    {
        private GameObject altar;
        private GameObject redDiamond;
        private MainHallRightDiamondControllerTest mhRightControllerTest;
        private GameObject star;

        [UnityTest]
        public IEnumerator ScanningPlayModeTestWithEnumeratorPasses ( )
        {
            altar = GameObject.Instantiate ( Resources.Load<GameObject> ( "altar Test" ) );
            altar.tag = "Altar";
            star = altar.transform.Find ( "magic_ball" ).transform.Find ( "star" ).gameObject;
            mhRightControllerTest = star.AddComponent<MainHallRightDiamondControllerTest> ( );
            redDiamond = GameObject.Instantiate ( new GameObject ( ) );
            SpriteRenderer redDiamondRenderer = redDiamond.AddComponent<SpriteRenderer> ( );
            redDiamondRenderer.sprite = Resources.Load<Sprite> ( "Red Texture Test" );
            redDiamond.AddComponent<Rigidbody> ( );
            redDiamond.AddComponent<DiamondMove> ( );
            altar.transform.position = Vector3.zero;
            redDiamond.transform.position = Vector3.forward;

            yield return new WaitForSeconds ( 15f );
            Assert.AreEqual ( mhRightControllerTest.RedDiamondScanning ( redDiamond ) , true );

        }
    }
}