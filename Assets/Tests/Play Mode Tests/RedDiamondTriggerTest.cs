using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{

    public class RedDiamondTriggerTest
    {
        private GameObject rightAltar;
        private GameObject redDiamond;
        private MainHallRightDiamondControllerTest mhRightControllerTest;
        private GameObject star;
        private Light rightRedDiamondLight;
        private GameObject mainHall;

        [SetUp]
        public void Setup ( )
        {

            foreach ( var GO in Transform.FindObjectsOfType<GameObject> ( ) )
            {
                if ( GO.name == "Main Hall" )
                {
                    mainHall = GO;
                }
            }

        }

        [UnityTest]
        public IEnumerator MenuHallExists ( )
        {
            mainHall = GameObject.Instantiate ( Resources.Load ( "Main Hall Test" ) ) as GameObject;
            yield return new WaitForSeconds ( 2f );
            Assert.IsNotNull ( mainHall );
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses ( )
        {

            rightAltar = mainHall.transform.Find ( "Right Altar" ).gameObject;
            rightRedDiamondLight = mainHall.transform.Find ( "red diamond door" ).transform.Find ( "right door" ).transform.Find ( "red diamond" ).GetComponent<Light> ( );
            star = rightAltar.transform.Find ( "magic_ball" ).transform.Find ( "star" ).gameObject;
            mhRightControllerTest = star.AddComponent<MainHallRightDiamondControllerTest> ( );
            redDiamond = GameObject.Instantiate ( new GameObject ( ) );
            SpriteRenderer redDiamondRenderer = redDiamond.AddComponent<SpriteRenderer> ( );
            redDiamondRenderer.sprite = Resources.Load<Sprite> ( "Red Texture Test" );
            redDiamond.AddComponent<Rigidbody> ( );
            redDiamond.AddComponent<DiamondMove> ( );
            redDiamond.transform.position = Vector3.forward;
            mhRightControllerTest.RedDiamondTriggering ( redDiamond );

            yield return new WaitForSeconds ( 15f );
            Assert.AreEqual ( rightRedDiamondLight.intensity , 3f );
        }
    }
}