using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GraveYardTreeSpawner : MonoBehaviour
{
    private List<GameObject> treeSpawners;
    public GameObject batGO;
    private GameObject bat;
    public GameObject blueDiamondGO;
    private GameObject blueDiamond;
    public GameObject redDiamondGO;
    private GameObject redDiamond;
    public GameObject yellowDiamondGO;
    private GameObject yellowDiamond;
    public GameObject orangeDiamondGO;
    private GameObject orangeDiamond;
    public GameObject violetDiamondGO;
    private GameObject violetDiamond;
    public GameObject coinBagGO;
    private GameObject coinBag;
    private int spawnNum;
    private GameObject tempSpawn;

    // Start is called before the first frame update
    private void Start ( )
    {
        treeSpawners = new List<GameObject> ( );
        treeSpawners.Add ( batGO );
        treeSpawners.Add ( blueDiamondGO );
        treeSpawners.Add ( redDiamondGO );
        treeSpawners.Add ( yellowDiamondGO );
        treeSpawners.Add ( orangeDiamondGO );
        treeSpawners.Add ( violetDiamondGO );
        treeSpawners.Add ( coinBagGO );
        spawnNum = Mathf.RoundToInt ( Random.Range ( 0 , treeSpawners.Count - 1 ) );

    }

    private void OnTriggerEnter ( Collider other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            SpawnSurprize ( treeSpawners , spawnNum );
        }
    }

    private void OnTriggerExit ( Collider other )
    {
        if ( other.CompareTag ( "Player" ) )
        {
            if ( tempSpawn != null && !tempSpawn.CompareTag ( "Bat" ) )
            {
                tempSpawn.transform.position = tempSpawn.transform.position + new Vector3 ( 0 , 0 , 6f );
                tempSpawn.transform.localScale = new Vector3 ( 1f , 1f , 1f );
                tempSpawn.transform.parent = null;

            }
            else
            {
                GameObject bat = tempSpawn.gameObject;
                NavMeshAgent batAgent = bat.GetComponent<NavMeshAgent>();
                batAgent.destination = other.transform.position;
            }

        }
    }

    private void SpawnSurprize ( List<GameObject> treeSpawners , int spawnNum )
    {
        for ( int i = 0 ; i < treeSpawners.Count ; i++ )
        {
            if ( i == spawnNum )
            {
                tempSpawn = Instantiate ( treeSpawners [ i ] ) as GameObject;
                tempSpawn.transform.parent = transform;
                tempSpawn.transform.position = transform.position;
            }

        }
    }
}