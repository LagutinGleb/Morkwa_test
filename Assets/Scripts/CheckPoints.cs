using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // когда охранник доходит до точки назначени€, его отправл€ют на следующую точку
    {
        if (other.TryGetComponent(out Patrolling patrool))
        {
            patrool.UpdateCheckPoint();
        }
    }
}
