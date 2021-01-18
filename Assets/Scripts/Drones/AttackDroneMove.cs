using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AttackDroneMove : MonoBehaviour
{
    NavMeshAgent attackDroneNavAgent;
    GameObject ghost;
    GameObject skeleton;
    GameObject lancer;
    GameObject buba;
    GameObject darkLord;
    GameObject dragons;
    Animator attackDroneAnim;
    private int numEnemies;

    [HideInInspector] public List<GameObject> enemies;




    // Start is called before the first frame update
    void Start()
    {
        attackDroneNavAgent = GetComponent<NavMeshAgent>();
        enemies = new List<GameObject>();
        numEnemies = 0;
        ghost = GameObject.FindGameObjectWithTag("Ghost");
        enemies.Add(ghost);
        skeleton = GameObject.FindGameObjectWithTag("Skeleton");
        enemies.Add(skeleton);
        lancer = GameObject.FindGameObjectWithTag("Lancer");
        enemies.Add(lancer);
        buba = GameObject.FindGameObjectWithTag("Buba");
        enemies.Add(buba);
        darkLord = GameObject.FindGameObjectWithTag("Demon");
        enemies.Add(darkLord);
        dragons = GameObject.FindGameObjectWithTag("Dragon");
        enemies.Add(dragons);
        attackDroneAnim = GetComponent<Animator>();
       
        GoToNextEnemy();

       
    }

    void GoToNextEnemy()
    {

        GameObject[] enemyArray = enemies.ToArray();
        attackDroneNavAgent.velocity = new Vector3(0.1f, 0.3f, 0.1f);
        attackDroneNavAgent.destination = enemyArray[numEnemies].transform.position;
        attackDroneNavAgent.gameObject.transform.LookAt(enemies[numEnemies].transform);
        attackDroneNavAgent.isStopped = false;
            

        numEnemies = (numEnemies + 1) % enemyArray.Length;
        

           

    }

    // Update is called once per frame
    void Update()
    {
       

        if (attackDroneNavAgent.remainingDistance < 0.5f && !attackDroneNavAgent.pathPending)
        {
            GoToNextEnemy();

        }

    }
}
