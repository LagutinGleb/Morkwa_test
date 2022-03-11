using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject gameGameObject;
    private Game game;
    private string playerTag = "Player";

    private void Start()
    {
        game = gameGameObject.GetComponent<Game>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            game.OnPlayerWin();
        }
    }
}
