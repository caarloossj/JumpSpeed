using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public TMP_Text textoContador;
    private float tiempoTranscurrido;
    private bool contadorActivo = false;

    public void Start()
    {
        IniciarContador();
    }

    void Update()
    {
        if (contadorActivo)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTextoContador();
        }
    }

    public void IniciarContador()
    {
        contadorActivo = true;
    }

    public void PararContador()
    {
        contadorActivo = false;
    }

    public void ResetearContador()
    {
        tiempoTranscurrido = 0f;
        ActualizarTextoContador();
    }

    private void ActualizarTextoContador()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60F);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido - minutos * 60);
        string formatoTiempo = string.Format("{0:0}:{1:00}", minutos, segundos);
        textoContador.text = formatoTiempo;
    }
}
