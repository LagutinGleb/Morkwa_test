using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject panelStart;
    public GameObject panelLose;
    public GameObject panelWin;

    void Start()
    {
        panelStart.SetActive(true);
        panelLose.SetActive(false);
        panelWin.SetActive(false);
    }

    public void ButtonStart()
    {
        panelStart.SetActive(false);
        Time.timeScale = 1;
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
