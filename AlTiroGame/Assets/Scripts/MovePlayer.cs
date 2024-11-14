using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
{
    CharacterController CC;
    public float speed = 50f;
    public string NombreInput;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw(NombreInput);

        Vector3 moveChar = new Vector3(0, 0, -horizontal);
        CC.Move(moveChar * speed * Time.deltaTime);
    }
}
