using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    public float speed = 5.0f;
    float currentposition;
    float deb;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        currentposition = GetComponent<Transform>().position.x;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalk = Input.GetAxisRaw("HorizontalKey");

        Vector3 moveChar = new Vector3(0, 0, -horizontalk);
        characterController.Move(moveChar * speed * Time.deltaTime);

        //transform.position = new Vector3(currentposition, 2, deb += -horizontalk * speed * Time.deltaTime);
    }
}
