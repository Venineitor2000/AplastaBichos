using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEscenario : MonoBehaviour
{
    public GameObject paredModoVertical1, paredModoVertical2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        Vector3 posX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        paredModoVertical1.transform.position = new Vector3(-posX.x, paredModoVertical1.transform.position.y, 1);
        paredModoVertical2.transform.position = new Vector3(posX.x, paredModoVertical1.transform.position.y, 1);       
    }
}
