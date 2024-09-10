using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0,100));
        }    
    }
}
