using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    public float speed = 5f;
    private string horizontalAxis;

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
        float moveX = Input.GetAxis(horizontalAxis) * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0, 0));
    }
}
