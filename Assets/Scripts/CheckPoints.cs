using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // ����� �������� ������� �� ����� ����������, ��� ���������� �� ��������� �����
    {
        if (other.TryGetComponent(out Patrolling patrool))
        {
            patrool.UpdateCheckPoint();
        }
    }
}
