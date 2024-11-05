using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPos : MonoBehaviour
{
    [Tooltip("en esta variable se guardan los tamaños de camara que va a ocupar la camara cuando solo es un jugador marcado por (ancho)")]
    [SerializeField] private float onePlayerPos;
    [Tooltip("en esta variable se guardan los tamaños de camara que va a ocupar la camara cuando hay dos jugadores marcado por (ancho player 1, ancho player 2)")]
    [SerializeField] private float[] twoPlayersPos;
    [Tooltip("esta variable nos indica si se juega un solo jugador o dos jugadores")]
    [SerializeField] private bool isTwoPlayers;

    [Tooltip("esta variable es para manipular la camara del primer jugador/main camara")]
    [SerializeField] private Camera player1;
    [Tooltip("esta variable es para manipular la camara del segundo jugador")]
    [SerializeField] private Camera player2;

    // Start is called before the first frame update
    void Start()
    {
        if(isTwoPlayers)
        {
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
            player1.rect = new Rect(twoPlayersPos[0],0,1,1);
            player2.rect = new Rect(twoPlayersPos[1],0,1,1);
        }
        else
        {
            player2.gameObject.SetActive(false);
            player1.rect = new Rect(onePlayerPos, 0, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
