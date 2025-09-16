using UnityEngine;

public class Ground : MonoBehaviour
{
    PlayerController player;

    void Start()
    {
        player = gameObject.transform.parent.gameObject.GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.layer == 8)
        {
            player.isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor)
    {
        if (collisor.gameObject.layer == 8)
        {
            player.isJumping = true;
        }
    }
}
