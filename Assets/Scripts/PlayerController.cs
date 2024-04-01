using UnityEngine;

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
    [SerializeField] private string axisHorizontal;
    [SerializeField] private int fuerza_de_Salto;
    [SerializeField] private LayerMask capas_Interactuables;
    [SerializeField] private GameManagerGame gameManager;
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
        gameManager.Barra_de_Vida.value = vida;
    }
    void Update()
    {
        direccionHorizontal = Input.GetAxisRaw(axisHorizontal);
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

        if (Input.GetKeyDown(KeyCode.Space) && (esta_sobre_suelo == 1 || estado_doble_salto == 1))
        {
            if (esta_sobre_suelo == 0)
            {
                estado_doble_salto = 0;
            }
            _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, fuerza_de_Salto);
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
            gameManager.TerminarNivel();
        }
        else if(collision.gameObject.tag == "Eliminator")
        {
            collision.gameObject.GetComponent<OutOfBoundsEliminator>().Eliminar(this.GetComponent<PlayerController>());
        }
        else if (collision.gameObject.tag == "Moneda")
        {
            gameManager.AumentarPuntaje(Random.Range(10, 30));
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.isTrigger = false;
        se_puede_cambiar_color = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.isTrigger = false;
        se_puede_cambiar_color = true;
    }
    public void ActualizaBarraDeVida()
    {
        gameManager.Barra_de_Vida.value = vida;
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
}
