using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float speed;
    private int moveDirection;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        speed = 50;
        moveDirection = 1;
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        rigidbody.velocity = new Vector2(Time.deltaTime *moveDirection * speed, rigidbody.velocity.y);
    }

    void Update(){
        animator.SetFloat("animSpeed", speed);
    }

    public void FilpMoveDirection(){
        moveDirection *= (-1);
            if (moveDirection < 0){
                gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            else if (moveDirection > 0){
                gameObject.GetComponent<Transform>().rotation= Quaternion.Euler(new Vector3(0, 0, 0));
            }

    }
}
