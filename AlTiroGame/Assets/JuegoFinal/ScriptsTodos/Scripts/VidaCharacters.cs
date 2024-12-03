using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCharacters : MonoBehaviour
{
    public int MaxVida;           // Vida m�xima del jugador.
    private int VidaActual;       // Vida actual del jugador.
    private Image BarraVida;      // Referencia a la barra de vida.

    void Start()
    {
        VidaActual = MaxVida;
        UpdateHealthBar();
    }

    // M�todo para asignar din�micamente la barra de vida desde otro script.
    public void SetHealthBar(Image healthBar)
    {
        BarraVida = healthBar;
        UpdateHealthBar(); // Aseg�rate de inicializar el valor en la barra.
    }

    void OnTriggerEnter(Collider other)
    {
        Damage damage = other.gameObject.GetComponent<Damage>();
        if (damage != null)
        {
            VidaActual -= damage.damage;
            VidaActual = Mathf.Clamp(VidaActual, 0, MaxVida); // Asegura que no baje de 0.
            UpdateHealthBar();

            Debug.Log($"Vida actual: {VidaActual}");
            if (VidaActual <= 0)
            {
                Debug.Log("El personaje ha muerto");
                Die();
            }
        }
    }

    private void UpdateHealthBar()
    {
        if (BarraVida != null)
        {
            // Actualiza el relleno de la barra basado en el porcentaje de vida restante.
            BarraVida.fillAmount = (float)VidaActual / MaxVida;
        }
    }

    private void Die()
    {
        // L�gica para manejar la muerte del jugador.
        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject); // Destruye el personaje (opcional, seg�n tu juego).
    }
}
