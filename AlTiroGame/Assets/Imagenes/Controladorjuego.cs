using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Importar para manejar escenas

public class ControladorJuego : MonoBehaviour
{
    [SerializeField] private float tiempoMaximo;
    [SerializeField] private Slider slider;

    private float tiempoActual;
    private bool tiempoActivado = false;

    private void Start()
    {
        ActivarTemporizador();
    }

    private void Update()
    {
        if (tiempoActivado)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if (tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }

        if (tiempoActual <= 0)
        {
            CambiarTemporizador(false);
            CargarEscenaFinal(); // Llamar a la función para cambiar de escena
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivado = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void OnDestroy()
    {
        CambiarTemporizador(false);
    }

    private void CargarEscenaFinal()
    {
        Debug.Log("Derrota: cargando escena Final");
        SceneManager.LoadScene("Menu_Final"); // Cargar la escena llamada "Final"
    }
}

