using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderRadius = 7f;

    private bool isAware = false;
    private Vector3 wanderPoint;
    private NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPoint();
    }
    public void Update()
    {
        if(isAware)
        {
            agent.SetDestination(Player.transform.position);
        }
        else
        {
            SearchForPlayer();
            Wander();
        }
    }
    public void SearchForPlayer()
    {
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(Player.transform.position)) < fov/2f)
        {
            if(Vector3.Distance(Player.transform.position, transform.position) < viewDistance)
            {
                RaycastHit hit;
                if(Physics.Linecast(transform.position, Player.transform.position,out hit, -1))
                {
                    if(hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                   
                }
            
            }
        }
    }

    public void OnAware()
    {
        isAware = true;
    }

    public void Wander()
    {
        if(Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            agent.SetDestination(wanderPoint);
        }
    }
    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint =(Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}
