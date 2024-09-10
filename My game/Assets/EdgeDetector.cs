using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetector : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyBehaviour enemyBehaviour;
    private void Start(){
        enemyBehaviour = gameObject.GetComponentInParent<EnemyBehaviour>();
    }
    private void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "isGrounded")
        {
            enemyBehaviour.FilpMoveDirection();
        }
    }
}

