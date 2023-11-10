using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshNew : MonoBehaviour
{
    public GameObject floor;
    private NavMeshAgent myAgent;
    public GameObject myPlayer;
    public float myAgentSpeed;
    public float walkRadius;

    public Transform centrePoint;

    public bool canSeePlayer;

    public bool myDistance;

    public FieldOfView myFieldOfViewScript;
    private Animator myAnimitor;
    // Start is called before the first frame update
    void Start()
    {
        myAnimitor = gameObject.GetComponent<Animator>();
        myAgent = gameObject.GetComponent<NavMeshAgent>();
        myAgent.speed = myAgentSpeed;
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * walkRadius; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        {
            
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    public void aiNav()
	{
        
        myAgent.speed = myAgentSpeed;
        if (canSeePlayer == true)
        {
            myAgent.destination = myFieldOfViewScript.target.transform.position;
            myDistance = true;
        }
        else
        {
            if (myDistance == true)
            {
                myAgent.destination = myAgent.transform.position;
                myDistance = false;

            }
            if (myAgent.remainingDistance <= myAgent.stoppingDistance)
            {
                myAnimitor.Play("Run");
                Vector3 point;
                if (RandomPoint(myAgent.transform.position, walkRadius, out point))
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                    myAgent.SetDestination(point);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (myFieldOfViewScript.visibleTargets.Count != 0)
		{
            canSeePlayer = true;
           // Debug.Log(myFieldOfViewScript.target.transform.position);
        } else
		{
            canSeePlayer = false;
		}
        //Debug.Log(myFieldOfViewScript.visibleTargets.Count);
       
        aiNav();
    }
}
