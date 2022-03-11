using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject UIgameObject;
    private UI ui;

    void Start()
    {
        Time.timeScale = 0;
        ui = UIgameObject.GetComponent<UI>();
    }

    public void OnPlayerDie()
    {
        Time.timeScale = 0;
        ui.panelLose.SetActive(true);
    }

    public void OnPlayerWin()
    {
        Time.timeScale = 0;
        ui.panelWin.SetActive(true);
    }
}
