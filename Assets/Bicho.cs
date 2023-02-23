using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicho : MonoBehaviour
{
    [SerializeField]
    int vidas;
    [SerializeField]
    float magnitudVelocidad = 0,tiempoInicio = 0, tiempoCambio = 1;
    public Rigidbody2D rb;
    Vector2 velocidad = new Vector2();
    public GameObject particulasMuerte, particulasDaño;
    public float varianteTamaño = 2.5f;
    bool detenerse;
    [SerializeField]AudioSource audioSource;
    bool movimientoForzado;

    public SpriteRenderer spriteCuerpo, spriteCola;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Aplastar").GetComponent<AudioSource>();
        Eventos.finTiempo += Detenerse;
        InvokeRepeating("Moverse", tiempoInicio, tiempoCambio);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        RecibirDaño();
    }

    public void EstablecerTamaño(int dificultad)
    {
        float valor = dificultad * varianteTamaño;
        if (valor <= 0)
            valor = 1f;
        transform.localScale = new Vector3(valor, valor, 1);
    }

    public void EstablecerVidaTotal(int vidas)
    {
        this.vidas = vidas;
    }

    void RotarMirada()
    {
        float angle = Mathf.Atan2(velocidad.y, velocidad.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void CalcularVelocidad()
    {
        //Forzado hace q vuelva al centro
        if (!movimientoForzado)
            velocidad = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        else
            velocidad = Vector2.zero - (Vector2)transform.position;
        while (velocidad.magnitude == 0)
        {
            velocidad = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        velocidad.Normalize();
        velocidad *= magnitudVelocidad;
    }

    void Moverse()
    {
        CalcularVelocidad();
        RotarMirada();
        rb.velocity = velocidad;
    }

    void RecibirDaño()
    {
        vidas--;
        Instantiate(particulasDaño, transform.position, transform.rotation);
        if (vidas <= 0)
        {
            GameObject.Find("Controlador").GetComponent<Generador>().ActualizarBichoAsesinado();
            Morir();
        }
    }

    void Morir()
    {
        if(this != null)
        {
            audioSource.Play();
            Instantiate(particulasMuerte, transform.position, transform.rotation);
            GameObject.Find("Controlador").GetComponent<Generador>().ActualizarCantidad();
            Destroy(gameObject);
        }            
    }

    void Detenerse()
    {
        Eventos.finTiempo -= Detenerse;
        //Actualiza la cantidad de bichos, como si los hubera matado el jugador, si llegas a usar ese dato para algo en el futuro, tene cuidado
        Morir();        
    }

    //Esto es para evitar q los bichos salgan de las paredes, pero dejandolos ser trigger asi no chocan entre ellos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pared")
        {
            movimientoForzado = true;
            Moverse();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pared")
            movimientoForzado = false;
    }

    private void OnDisable()
    {
        transform.position = new Vector3(0, 0, 1);
    }

}
