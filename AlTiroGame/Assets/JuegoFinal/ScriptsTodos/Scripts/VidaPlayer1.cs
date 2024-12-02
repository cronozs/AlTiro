using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer1 : MonoBehaviour
{
    public int MaxVida;
    private int VidaActual;
    public Image BarraVida;

    void Start()
    {
        //BarraVida.maxValue = MaxVida;
        VidaActual = MaxVida;
        //BarraVida.value = VidaActual;
    }

    void OnTriggerEnter(Collider other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();

        VidaActual -= damage.damage;

        BarraVida.fillAmount = (float)VidaActual / MaxVida;

        Debug.Log(VidaActual);    
        if(VidaActual <= 0)
        {
            Debug.Log("El personaje ha muerto");
        }
    }
}
