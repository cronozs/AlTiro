using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MovePlayer : MonoBehaviour
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

        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 moveChar = new Vector3(0, 0, -horizontal);
        characterController.Move(moveChar * speed * Time.deltaTime);

        //transform.position = new Vector3(currentposition, 2, deb += -horizontal * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            deb += -horizontal * speed * Time.deltaTime;
            Debug.Log(deb);
        }

    }
}
