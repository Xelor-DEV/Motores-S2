using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVerticalController : MotherClassEnemy
{
    private Rigidbody2D _compRigidbody2D;
    [SerializeField] private float direccion;
    [SerializeField] private int velocidad;
    [SerializeField] private Collider2D a;
    [SerializeField] private float direccionA;
    [SerializeField] private Collider2D b;
    [SerializeField] private float direccionB;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        da�o = 2;
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x,direccion * velocidad);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if (collision == a)
            {
                direccion = direccionA;
            }
            else if (collision == b)
            {
                direccion = direccionB;
            }
        }
        else if (collision.tag == "Player")
        {
            Attack(collision.GetComponent<PlayerController>(),da�o);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if (collision.collider == a)
            {
                direccion = direccionA;
            }
            else if (collision.collider == b)
            {
                direccion = direccionB;
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject.GetComponent<PlayerController>(), da�o);
        }
    }
}
