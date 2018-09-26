using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveDestination : MonoBehaviour {
    public Transform goal;

    void Start()
    {
        StartCoroutine(Move(goal.position));
    }

    IEnumerator Move (Vector3 position)
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        
        while (gameObject.activeInHierarchy)
        {
            agent.destination = position;
            yield return new WaitForFixedUpdate();
        }
    }
}


// TODO:
// onCollisionEnter, agent.stop or similar method.