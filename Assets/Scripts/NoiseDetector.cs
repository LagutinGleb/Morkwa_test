using UnityEngine;
using UnityEngine.UI;

public class NoiseDetector : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies = new GameObject[2];
    private EnemyVision[] enemyVisions = new EnemyVision[2];
    private Renderer[] renderers = new Renderer[2];
    public Slider slider;
    private Controls controls;
    private float maxValue = 10;
    private float speedUP = 3f; //�������� ���������� �������� �� 1 timeUP
    private float timeUP = 1f;
    private float speedDoun = 1f;//�������� �������� �������� �������� �� 1 timeDown
    private float timeDown = 0.5f;
    private bool alert = false;

    private void Start()
    {
        controls = player.GetComponent<Controls>();
        slider.value = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyVisions[i] = enemies[i].GetComponent<EnemyVision>();
            renderers[i] = enemies[i].GetComponent<Renderer>();
        }
    }

    private void FixedUpdate()
    {
        FillSlider();

        if (slider.value >= maxValue)
            Alert();
    }

    private void FillSlider() // ��� �������� ������ ������� �����������, ��� �������� �������� �����������, ��� ���������� ���������� ������������ ������ ���������� �������
    {
        if (controls.isMooving)
        {
            slider.value += speedUP * timeUP * Time.deltaTime;
        }
        else
        {
            if (alert)
            {
                return;
            }
            else
            {
                slider.value -= speedDoun / timeDown * Time.deltaTime;
            }
        }
    }

    private void Alert() //���������� ���������� �� ������� � ������ �� ����
    {
        alert = true;
        Debug.Log(slider.value);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemyVisions[i].MoveToTarget();
            renderers[i].material.color = new Color (0,0,0);
        }
    }
}
