using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer1 : MonoBehaviour
{
    public int MaxVida;
    private int VidaActual;
    public Slider BarraVida;

    void Start()
    {
        BarraVida.maxValue = MaxVida;
        VidaActual = MaxVida;
        BarraVida.value = VidaActual;
    }

    void OnTriggerEnter(Collider other)
    {
        Botella botella = other.gameObject.GetComponent<Botella>();
        Mancuerna mancuerna = other.gameObject.GetComponent<Mancuerna>();
        Chancla chancla = other.gameObject.GetComponent<Chancla>();
        Cuete cuete = other.gameObject.GetComponent<Cuete>();

        if (botella != null)
        {
            Destroy(botella.gameObject);
            VidaActual -= botella.Daño;
        }
        else if (mancuerna != null)
        {
            Destroy(mancuerna.gameObject);
            VidaActual -= mancuerna.Daño;
        }
        else if (chancla != null)
        {
            Destroy(chancla.gameObject);
            VidaActual -= chancla.Daño;
        }
        else if (cuete != null)
        {
            Destroy(cuete.gameObject);
            VidaActual -= cuete.Daño;
        }

        BarraVida.value = VidaActual;

        if(VidaActual <= 0)
        {
            Debug.Log("El personaje ha muerto");
        }
    }
}
