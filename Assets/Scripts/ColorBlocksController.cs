using UnityEngine;

public class ColorBlocksController : MotherClassEnemy
{
    void Start()
    {
        da�o = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Attack(collision.GetComponent<PlayerController>(),da�o);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject.GetComponent<PlayerController>(), da�o);
        }
    }
}
