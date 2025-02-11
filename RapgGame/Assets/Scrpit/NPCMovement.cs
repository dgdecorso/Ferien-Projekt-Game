using System.Collections;
using UnityEngine;
using UnityEngine.AI; // ✅ Needed for NPC movement

public class NPCMovement : MonoBehaviour
{
    public bool randomPatrol = true; // ✅ Set to false for fixed waypoints
    public Transform[] waypoints; // ✅ If not using random, assign waypoints here
    public float walkRadius = 10f; // ✅ Area NPC will randomly walk
    public float waitTime = 2f; // ✅ Time NPC waits before moving again

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (randomPatrol)
            StartCoroutine(RandomPatrol()); // ✅ Start random movement
        else
            MoveToWaypoint(); // ✅ Start following waypoints
    }

    IEnumerator RandomPatrol()
    {
        while (true)
        {
            Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
            randomDirection += transform.position; // ✅ Move from NPC's position

            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, walkRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position); // ✅ Move to random spot
            }

            yield return new WaitForSeconds(waitTime); // ✅ Wait before moving again
        }
    }

    void MoveToWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    void Update()
    {
        if (!randomPatrol && agent.remainingDistance < 0.5f) // ✅ If close to waypoint, go to next
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            MoveToWaypoint();
        }
    }
}
