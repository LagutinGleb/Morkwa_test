using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gameGameObject;
    private Game game;

    private void Start()
    {
        game = gameGameObject.GetComponent<Game>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            game.OnPlayerDie();
        }
    }
}
