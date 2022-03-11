using UnityEngine;
using UnityEngine.AI;

public class EnemyVision : MonoBehaviour
{
    [Range(0, 360)] public float ViewAngle = 90f;
    private float ViewDistance = 2f;
    public Transform Target;
    private Patrolling patrolling;
    private NavMeshAgent agent;
    private bool isPatrooling = true;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolling = GetComponent<Patrolling>();
    }

    private void FixedUpdate() // если игрок в зоне видимости охранника - идем за игроком, если игрок пропадает из зоны видимости, идем патрулировать
    {
        if (IsInView())
        {
                isPatrooling = false;
                MoveToTarget();
        }
        else
        {
            if (!isPatrooling)
            {
                patrolling.UpdateCheckPoint();
                isPatrooling = true;
            }
        }

        DrawViewState();
    }

    private bool IsInView() // true если цель видна. 
    {
        float realAngle = Vector3.Angle(transform.forward, Target.position - transform.position); 

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, ViewDistance))
        {
            if (realAngle < ViewAngle / 2f && Vector3.Distance(transform.position, Target.position) <= ViewDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
    }
    
    public void MoveToTarget() // устанвливает точку движения к цели
    {
        agent.SetDestination(Target.position);
    }

    private void DrawViewState() // границы угла и дальности обзора
    {
        Vector3 left = transform.position + Quaternion.Euler(new Vector3(0, ViewAngle / 2f, 0)) * (transform.forward * ViewDistance);
        Vector3 right = transform.position + Quaternion.Euler(-new Vector3(0, ViewAngle / 2f, 0)) * (transform.forward * ViewDistance);
        Debug.DrawLine(transform.position, left, Color.yellow);
        Debug.DrawLine(transform.position, right, Color.yellow);
    }
}