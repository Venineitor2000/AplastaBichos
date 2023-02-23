using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contador : MonoBehaviour
{
    public float tiempoInicial;
    float time;
    public Text textoTiempo, textoRonda;
    bool detenerse;
    public Image marco;
    public Color32 color1, color2;
    // Start is called before the first frame update
    void Start()
    {
        time = tiempoInicial;
        textoTiempo.text = time.ToString();
        ActualizarRonda(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0.75f)
        {
            time -= Time.deltaTime;
            textoTiempo.text = ((int)time).ToString();
            ActualizarMarco();
        }        
        else if(!detenerse)
        {
            Eventos.finTiempo();
            detenerse = true;
        }
    }

    public void ActualizarRonda(int ronda)
    {
        textoRonda.text = ronda.ToString();
    }

    void ActualizarMarco()
    {
        marco.color = Color32.Lerp(color1, color2, time/tiempoInicial);//Mal, habria q ver como transformar a time en un valor q va de 1 a 0 o 0 a 1
    }
}
