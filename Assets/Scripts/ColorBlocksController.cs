using UnityEngine;

public class ColorBlocksController : MotherClassEnemy
{
    void Start()
    {
        daño = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attack(collision.GetComponent<PlayerController>(),daño);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject.GetComponent<PlayerController>(), daño);
        }
    }
}
