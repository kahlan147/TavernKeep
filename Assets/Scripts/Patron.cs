using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patron : MonoBehaviour {

    private Transform destination;
    private NavMeshAgent agent;

    [SerializeField] private List<MeshRenderer> bodyObjects;
    [SerializeField] private List<MeshRenderer> skinObjects;
    [SerializeField] private List<MeshRenderer> legsObjects;

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }
    
	
	void Update () {
        AI();
	}

    private void AI()
    {
        if (destination != null)
        {
            if (DistanceToDestination() < 1)
            {
                this.transform.SetPositionAndRotation(destination.position, destination.rotation);
            }
            else
            {
                WalkToDestination();
            }
        }
    }

    private float DistanceToDestination()
    {
        return Vector3.Distance(this.transform.position, destination.position);
    }

    private void WalkToDestination()
    {
        agent.SetDestination(destination.position);
    }

    public void SetDestination(Transform destination)
    {
        this.destination = destination;
    }

    public void SetLook(Material skinColour, Material bodyColour, Material legsColour)
    {
        foreach (MeshRenderer obj in skinObjects)
        {
            obj.material = skinColour;
        }
        foreach (MeshRenderer obj in bodyObjects)
        {
            obj.material = bodyColour;
        }
        foreach (MeshRenderer obj in legsObjects)
        {
            obj.material = legsColour;
        }
    }
    

}
