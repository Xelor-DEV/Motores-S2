using UnityEngine;
using Cinemachine;
public class CinemachineController : MonoBehaviour
{
    private CinemachineVirtualCamera camaraVirtualDelCinemachine;
    private CinemachineBasicMultiChannelPerlin componenteParaTemblorDeCamara;
    [SerializeField] private float duracion;
    [SerializeField] private float temporizador_de_sacudida;
    void Awake()
    {
        camaraVirtualDelCinemachine = GetComponent<CinemachineVirtualCamera>();
        componenteParaTemblorDeCamara = camaraVirtualDelCinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        if(temporizador_de_sacudida > 0)
        {
            temporizador_de_sacudida = temporizador_de_sacudida - Time.deltaTime;
            if (temporizador_de_sacudida <= 0)
            {
                componenteParaTemblorDeCamara.m_AmplitudeGain = 0f;
            }
        }
    }
    public void SacudirCamara(int dano)
    {
        componenteParaTemblorDeCamara.m_AmplitudeGain = dano;
        temporizador_de_sacudida = duracion;
    }
}
