using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    private SpriteRenderer _compSpriteRenderer;
    private bool deteccion_raycast;
    private float direccionHorizontal;
    private Vector2 direccion_raycast = new Vector2(0, -1);
    [SerializeField] private int esta_sobre_suelo;
    [SerializeField] private int estado_doble_salto;
    [SerializeField] private bool se_puede_cambiar_color;
    [SerializeField] private string color;
    [SerializeField] private int velocidad;
    [SerializeField] private int vida;
    [SerializeField] private int fuerza_de_Salto;
    [SerializeField] private LayerMask capas_Interactuables;
    [SerializeField] private GameManagerGame gameManager;
    public Action<int> CuandoSeActualiceVida;
    public GameManagerGame GameManager
    {
        get
        {
            return gameManager;
        }
    }
    public bool Se_puede_cambiar_color
    {
        set
        {
            se_puede_cambiar_color = value;
        }
    }
    public int Vida
    {
        get
        {
            return vida;
        }
        set
        {
            vida = value;
            CuandoSeActualiceVida?.Invoke(vida);
        }
    }
    public string Color_
    {
        get
        {
            return color;
        }
    }
    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
        _compSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        gameManager.ActualizaBarraDeVida(Vida);
        CuandoSeActualiceVida += gameManager.ActualizaBarraDeVida;
    }
    void Update()
    {
        deteccion_raycast = Physics2D.Raycast(transform.position, direccion_raycast, 1, capas_Interactuables);
        if (deteccion_raycast == true)
        {
            esta_sobre_suelo = 1;
            estado_doble_salto = 1;
        }
        else
        {
            esta_sobre_suelo = 0;
        }
    }
    public void Input(InputAction.CallbackContext context)
    {
        direccionHorizontal = context.ReadValue<float>();
    }
    public void Saltar(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if (esta_sobre_suelo == 1 || estado_doble_salto == 1)
            {
                if (esta_sobre_suelo == 0)
                {
                    estado_doble_salto = 0;
                }
                _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, fuerza_de_Salto);
            }
        }
    }
    void FixedUpdate()
    {
        //Movimiento
        _compRigidbody2D.velocity = new Vector2(direccionHorizontal * velocidad, _compRigidbody2D.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Salida")
        {
            gameManager.CuandoElJugadorGana?.Invoke();
        }
        else if (collision.gameObject.tag == "Eliminator")
        {
            collision.gameObject.GetComponent<OutOfBoundsEliminator>().Eliminar(this.GetComponent<PlayerController>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Moneda")
        {
            gameManager.AumentarPuntaje(UnityEngine.Random.Range(10, 30));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Corazon")
        {
            if (Vida < 10)
            {
                AumentarVida(1);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.isTrigger = false;
        se_puede_cambiar_color = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Corazon")
        {
            collision.isTrigger = false;
            se_puede_cambiar_color = true;
        }
    }

    public void CambiarColor(string Tag)
    {
        if (se_puede_cambiar_color == true)
        {
            if (Tag == "Magenta")
            {
                _compSpriteRenderer.color = Color.magenta;
                color = "Magenta";
            }
            else if (Tag == "Blue")
            {
                _compSpriteRenderer.color = Color.blue;
                color = "Blue";
            }
            else if (Tag == "Green")
            {
                _compSpriteRenderer.color = Color.green;
                color = "Green";
            }
        }
    }
    public void AumentarVida(int aumento)
    {
        Vida = Vida + aumento;     
    }
}
