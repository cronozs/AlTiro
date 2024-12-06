using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarcaTimer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MarcaPantalla());
    }

    IEnumerator MarcaPantalla()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu_Inicial");
    }
}
