using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    private bool isGrounded;
    [SerializeField]
    private float jumpPower;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        isGrounded=false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded)
                rigidbody.AddForce(new Vector2(0,100));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpPower));
                SpecialEffects.specialEffects.CreateSmoke(transform);
            }
        }   
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded=true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded=false;
        }
    }
}
