using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject[] checkPoints;
    private string checkPointsTag = "CheckPoint";
    private int rnd;
    private int lastRnd = -1;
    private string enemyTag = "Enemy";

    void Start()
    {
        checkPoints = GameObject.FindGameObjectsWithTag(checkPointsTag);
        agent = GetComponent<NavMeshAgent>();
        UpdateCheckPoint();
    }

    public void UpdateCheckPoint() //���������� �������� ����������
    {
        do
        {
            rnd = Random.Range(0, checkPoints.Length);
        }   while (lastRnd == rnd);
        
        lastRnd = rnd;

        agent.SetDestination(checkPoints[rnd].transform.position);
    }

    private void OnCollisionEnter(Collision collision) //����� ��������� �� ������, ����� ����������� � ����� ��������
    {
        if (collision.collider.tag == enemyTag)
        {
            UpdateCheckPoint();
        }
    }
}
