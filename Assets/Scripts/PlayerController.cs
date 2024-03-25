using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    private float direccionHorizontal;
    private float direccionVertical;
    [SerializeField] private int velocidad;
    [SerializeField] private string axisHorizontal;
    [SerializeField] private string axisVertical;
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direccionHorizontal = Input.GetAxisRaw(axisHorizontal);
        direccionVertical = Input.GetAxisRaw(axisVertical);
    }
    void FixedUpdate()
    {
        //Movimiento
        Vector2 direccion = new Vector2(direccionHorizontal, direccionVertical);
        _compRigidbody2D.velocity = direccion * velocidad;
    }
}
