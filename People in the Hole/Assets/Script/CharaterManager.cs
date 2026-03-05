using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CharaterManager : MonoBehaviour
{
    private NavMeshAgent _agent;
    private NavMeshObstacle _obstacle;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _obstacle = GetComponent<NavMeshObstacle>();

        SetMode(false);
    }

    public void MoveToHole(Vector3 target)
    {
        RaycastHit hit;
        Vector3 dir = (target - (transform.position + Vector3.up * 0.5f)).normalized;
            Vector3 origin = transform.position + Vector3.up * 0.5f + dir * 0.6f;

        if (Physics.Raycast(origin, dir, out hit, 10f))
        {
            if (!hit.collider.name.Contains("Hole"))
            {
                return;
            }
        }

        SetMode(true);
        _agent.SetDestination(target);
    }

    private void SetMode(bool isMoving)
    {
        if (isMoving)
        {
            _obstacle.enabled = false;
            _agent.enabled = true;
        }

        else
        {
            _obstacle.enabled = true;
            _agent.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * 0.5f, transform.forward * 1f);
    }
}
