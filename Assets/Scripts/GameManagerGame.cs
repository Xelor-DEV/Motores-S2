using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerGame : MonoBehaviour
{
    [Header("Elementos UI")]
    [SerializeField] private TMP_Text cronometro;
    [SerializeField] private Slider barra_de_Vida;
    [SerializeField] private GameObject pantalla_de_Pausa;
    [SerializeField] private TMP_Text puntaje;
    [SerializeField] private int puntos;
    [Header("Elementos de la Pantalla de Resultados")]
    [SerializeField] private GameObject pantalla_de_Ganar;
    [SerializeField] private TMP_Text resultado;
    [SerializeField] private TMP_Text tiempo_de_juego;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject reintentar;
    [SerializeField] private GameObject siguiente_nivel;
    [SerializeField] private string escena;
    private float tiempo = 0;
    private double time_entero = 0;
    public Slider Barra_de_Vida
    {
        get
        {
            return barra_de_Vida;
        }
    }
    void Start()
    {
        puntos = 0;
    }
    void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        time_entero = Mathf.Floor(tiempo);
        cronometro.text = time_entero.ToString();
    }
    public void Pausar()
    {
        pantalla_de_Pausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continuar()
    {
        pantalla_de_Pausa.SetActive(false);
        Time.timeScale = 1;

    }
    public void TerminarNivel() 
    {
        if (escena == "Nivel1")
        {
            resultado.text = "Terminaste el nivel";
            pantalla_de_Ganar.SetActive(true);
            tiempo_de_juego.text = time_entero.ToString() + " Segundos";
            menu.SetActive(true);
            reintentar.SetActive(true);
            siguiente_nivel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (escena == "Nivel2")
        {
            resultado.text = "Terminaste el juego";
            pantalla_de_Ganar.SetActive(true);
            tiempo_de_juego.text = time_entero.ToString() + " Segundos";
            menu.SetActive(true);
            reintentar.SetActive(true);
            siguiente_nivel.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void Morir()
    {
        resultado.text = "Perdiste";
        pantalla_de_Ganar.SetActive(true);
        tiempo_de_juego.text = time_entero.ToString() + " Segundos";
        menu.SetActive(true);
        reintentar.SetActive(true);
        siguiente_nivel.SetActive(false);
        Time.timeScale = 0;
    }
    public void CargarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
        Time.timeScale = 1;
    }
    public void AumentarPuntaje(int puntos)
    {
        this.puntos = this.puntos + puntos;
        puntaje.text = "Puntaje: " + this.puntos.ToString();
    }
}
