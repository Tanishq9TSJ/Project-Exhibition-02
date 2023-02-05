using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform Player;
    public float fov = 120f;
    public float viewDistance = 10f;
    private bool isAware = false;
    private NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
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
}
