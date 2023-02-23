using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Generador generador;

    void elegirDificultad()
    {
        gameObject.SetActive(false);
        generador.gameObject.GetComponent<Contador>().enabled = true;
        generador.enabled = true;
    }

    public void dificultadFacil()
    {
        generador.dificultad = 4;
        elegirDificultad();
    }

    public void dificultadNormal()
    {
        generador.dificultad = 3;
        elegirDificultad();
    }

    public void dificultadDificil()
    {
        generador.dificultad = 2;
        elegirDificultad();
    }

    public void dificultadExtrema()
    {
        generador.dificultad = 1;
        elegirDificultad();
    }

}
