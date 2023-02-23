using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Generador : MonoBehaviour
{
    public int cantidadTotal;
    public int cantidadIncremento;
    public int vidaMaxima;
    public int incrementoVidaMaxima;
    int cantidadActual;
    int cantidadAsesinados;
    public GameObject bicho;
    int ronda = 1;
    public Contador contador;
    public int dificultad;
    bool detenerse;
    public GameObject menuPuntuacion;
    public Text puntuacionActual, MejorPuntuacion;
    public int multiplicadorPuntos = 1;



    private void Start()
    {
        Eventos.finTiempo += Detenerse;
        Generar();
    }

    private void Update()
    {
        
            
    }

    void Generar()
    {
        cantidadActual = cantidadTotal;

        
        for (int i = 0; i < cantidadTotal; i++)
        {
            Bicho bichoAux = Instantiate(bicho).GetComponent<Bicho>();
            bichoAux.EstablecerTamaño(dificultad);
            bichoAux.spriteCuerpo.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
            bichoAux.spriteCola.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
            bichoAux.EstablecerVidaTotal(vidaMaxima);
        }
    }

    public void ActualizarCantidad()
    {
        cantidadActual--;
        if(cantidadActual <= 0 && !detenerse)
        {
            TerminoRonda();
        }
    }

    void TerminoRonda()
    {
        ronda++;
        cantidadTotal += cantidadIncremento;
        vidaMaxima += incrementoVidaMaxima;
        contador.ActualizarRonda(ronda);
        Generar();
    }  
    
    void Detenerse()
    {
         detenerse = true;
        Eventos.finTiempo -= Detenerse;
        Invoke("ActualizarMenuPuntuacion", 0.8f);
    }

    void ActualizarMenuPuntuacion()
    {
        int puntuacion = cantidadAsesinados * multiplicadorPuntos;
        puntuacionActual.text = puntuacion.ToString();
        menuPuntuacion.SetActive(true);        
    }

    public void ActualizarBichoAsesinado()
    {
        cantidadAsesinados++;
    }
}
