using Unity.Cinemachine.Samples;
using UnityEngine;
using UnityEngine.AI;

public class EnemySimpleController : MonoBehaviour
{
    public int lifeEnemy = 100;
    public Transform Target;
    private NavMeshAgent agentEnemy;
    public int count = 0;

    void Start()
    {
        agentEnemy = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Humanoid").transform;
        if (Target != null && agentEnemy.isOnNavMesh)
        {
            agentEnemy.SetDestination(Target.position);

            agentEnemy.speed = Random.Range(8f, 12f);
            agentEnemy.acceleration = Random.Range(6f, 10f);
            agentEnemy.stoppingDistance = Random.Range(1f, 3f);
            agentEnemy.avoidancePriority = Random.Range(0, 99);
            agentEnemy.angularSpeed = Random.Range(0, 120);
        }

    }

    void Update()
    {
        

        Destination();
        OnDead();
    }
        
    public void HasPath()
    {
        print(agentEnemy.hasPath);
    }
    public void Destination()
    {
        if (Target != null)
        {
            agentEnemy.SetDestination(Target.position);

        }
    }
    public void OnDead()
    {
        if (lifeEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (agentEnemy == null || agentEnemy.path == null) return;

        Vector3[] corners = agentEnemy.path.corners;


        for (int i = 0; i < corners.Length - 1; i++)
        {
            Gizmos.DrawLine(corners[i], corners[i + 1]);
            Gizmos.DrawSphere(corners[i], 0.2f);
        }

    }
}
