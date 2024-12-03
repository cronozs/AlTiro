using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    public float speed;
    private string horizontalAxis;
    private CharacterController CC;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    public void SetControls(string player)
    {
        if (player == "Player1")
        {
            horizontalAxis = "Horizontal";
        }
        else if (player == "Player2")
        {
            horizontalAxis = "HorizontalKey";
        }
    }

    void Update()
    {
        Vector3 move = new Vector3(0f, 0f, Input.GetAxis(horizontalAxis));
        CC.Move(move * speed * Time.deltaTime);
    }
}
