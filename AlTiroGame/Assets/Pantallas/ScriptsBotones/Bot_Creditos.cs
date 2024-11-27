using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Creditos : MonoBehaviour
{
    public GameObject PanelCreditos;

    public void ShowPanel()
    {
        PanelCreditos.SetActive(true); // Activa el panel
    }

    public void HidePanel()
    {
        PanelCreditos.SetActive(false); // Desactiva el panel
    }
}
