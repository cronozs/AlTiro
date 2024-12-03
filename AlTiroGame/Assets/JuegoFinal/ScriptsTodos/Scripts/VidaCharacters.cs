using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaCharacters : MonoBehaviour
{
    public int MaxVida;           // Vida máxima del jugador.
    private int VidaActual;       // Vida actual del jugador.
    private Image BarraVida;      // Referencia a la barra de vida.

    // Delegado y evento para notificar la muerte del jugador
    public delegate void OnPlayerDeath();
    public event OnPlayerDeath PlayerDied;

    void Start()
    {
        VidaActual = MaxVida;
        UpdateHealthBar();
    }

    // Método para asignar dinámicamente la barra de vida desde otro script.
    public void SetHealthBar(Image healthBar)
    {
        BarraVida = healthBar;
        UpdateHealthBar(); // Asegúrate de inicializar el valor en la barra.
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
        // Lógica para manejar la muerte del jugador.
        Debug.Log($"{gameObject.name} ha muerto.");
        // Dispara el evento de muerte
        if (PlayerDied != null)
        {
            PlayerDied.Invoke(); // Notifica a los suscriptores (GameSceneManager) que el jugador ha muerto.
        }

        // Puedes destruir el personaje o detener su movimiento, dependiendo de lo que necesites.
        // En este caso, simplemente desactivaremos el GameObject.
        gameObject.SetActive(false);  // Desactiva el jugador en lugar de destruirlo.

        // Si prefieres destruir el GameObject (puedes hacerlo si lo deseas):
        // Destroy(gameObject);
    }
}
