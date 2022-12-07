using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walker : MonoBehaviour
{
    private NavMeshAgent nav_mesh_agent = null;

    // Start is called before the first frame update
    void Start()
    {
        nav_mesh_agent = this.GetComponent<NavMeshAgent>();

        set_destination();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Check if we've reached the destination
        if (!nav_mesh_agent.pathPending)
        {
            if (nav_mesh_agent.remainingDistance <= nav_mesh_agent.stoppingDistance)
            {
                if (!nav_mesh_agent.hasPath || nav_mesh_agent.velocity.sqrMagnitude == 0f)
                {
                    // Done
                    this.set_destination();
                }
            }
        }
            
    }

    public void set_destination()
    {
        Vector3 new_destination = AgentsManager.GetRandomNavMeshPosition();
        nav_mesh_agent.SetDestination(new_destination);
    }
}
