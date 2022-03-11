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
    private float speedUP = 3f; //скорость заполнения слайдера за 1 timeUP
    private float timeUP = 1f;
    private float speedDoun = 1f;//скорость снижения значений слайдера за 1 timeDown
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

    private void FillSlider() // при движении игрока слайдер заполняется, без движения значение уменьшается, при достижении достижении критического уровня включается тревога
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

    private void Alert() //отправляет охранников за игроком и меняет их цвет
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
