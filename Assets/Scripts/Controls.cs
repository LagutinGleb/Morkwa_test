using UnityEngine;

public class Controls : MonoBehaviour
{
    float speed = 1f;
    float horizontal;
    float vertical;
    Rigidbody playerRB;
    public bool isMooving = false;

    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal > 0)
            playerRB.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        if (horizontal < 0)
            playerRB.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;

        if (vertical > 0)
            playerRB.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;

        if (vertical < 0)
            playerRB.transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;

        isMooving = IsMooving();
    }

    private bool IsMooving()
    {
        if (horizontal != 0f || vertical != 0f)
            return true;
        else
        {return false;}
    }
}
