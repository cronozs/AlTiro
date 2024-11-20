using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Datos/Personaje")]
public class Personaje : ScriptableObject
{
    public string nombre;
    public GameObject Modelo;
    public GameObject Bala;
}
