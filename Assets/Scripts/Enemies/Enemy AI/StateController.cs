using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public Animator animator;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public List<Transform> wayPointList2;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public LancerAttack lancerAttack;

    private bool aiActive;

    private void Awake ( )
    {
        lancerAttack = GetComponent<LancerAttack> ( );
        navMeshAgent = GetComponent<NavMeshAgent> ( );
        animator = GetComponent<Animator> ( );
    }

    public void SetupAI ( bool aiActivationFromEnemyManager , List<Transform> wayPointsFromEnemyManager )
    {
        wayPointList = wayPointsFromEnemyManager;
        wayPointList2 = wayPointsFromEnemyManager;

        aiActive = aiActivationFromEnemyManager;
        if ( aiActive )
        {
            navMeshAgent.enabled = true;
        }
        else
        {
            navMeshAgent.enabled = false;
        }
    }

    private void Update ( )
    {
        if ( !aiActive )
            return;

        currentState.UpdateState ( this );
    }

    private void OnDrawGizmos ( )
    {
        if ( currentState != null && eyes != null )
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere ( eyes.position , enemyStats.lookSphereCastRadius );
        }
    }

    public void TransitionToState ( State nextState )
    {
        if ( nextState != remainState )
        {
            currentState = nextState;
            OnExitState ( );
        }
    }

    public bool CheckIfCountDownElapsed ( float duration )
    {
        stateTimeElapsed += Time.deltaTime;
        return ( stateTimeElapsed >= duration );
    }

    private void OnExitState ( )
    {
        stateTimeElapsed = 0;
    }
}