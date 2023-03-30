using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{

    float moveSpeed;
    Rigidbody2D rigidBody;
    Vector2 moveDirection;
    PlayerController target;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GetComponent<Enemy>().speed;
        rigidBody = GetComponent<Rigidbody2D>();
        target = PlayerController.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidBody.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
