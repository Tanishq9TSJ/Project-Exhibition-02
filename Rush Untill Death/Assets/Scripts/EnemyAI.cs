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
    public float loseThreshold = 5f; // Time in sec until we lose the player after we stop detecting
    private bool isDetecting = false;

    public float wanderSpeed = 1f;
    public float chaseSpeed = 2f;
    private bool isAware = false;
  
    private Vector3 wanderPoint;
    private NavMeshAgent agent;
    public Animator anim;
    private float loseTimer = 0f;

    public  AudioSource aud , aud2;
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        wanderPoint = RandomWanderPoint();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(isAware)
        {
            aud.enabled = true;
            aud2.enabled = false;
            agent.SetDestination(Player.transform.position);
            anim.SetBool("Aware", true);
            agent.speed = chaseSpeed;
        
            if (!isDetecting)
            {
                loseTimer += Time.deltaTime;
                if(loseTimer >= loseThreshold)
                {
                    isAware = false;
                    loseTimer = 0f;
                   
                }
            }
       
        }
        else
        {
            aud.enabled = false;
            aud2.enabled = true;
            Wander();
            anim.SetBool("Aware", false);
            aud.Pause();
            agent.speed = wanderSpeed;
            
        }
        SearchForPlayer();
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
                    else
                    {
                        isDetecting = false;
                 
                    }
                   
                }
                else
                {
                    isDetecting = false;
            
                }
            
            }
            else
            {
                isDetecting = false;
    
            }
        }
        else
        {
            isDetecting = false;

        }
    }

    public void OnAware()
    {
        isAware = true;
        isDetecting = true;
        loseTimer = 0f;
 
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
