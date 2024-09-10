using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private UiInstanceController uiInstanceController;
    private bool isVarnuable;

    void Start()
    {
        isVarnuable = true;
        uiInstanceController = GameObject.Find("HeartContainer").GetComponent<UiInstanceController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.tag == "Enemy" && isVarnuable){
            uiInstanceController.DestroyInstance();
            StartCoroutine(Invarnuability());
        }
    }

    private IEnumerator Invarnuability(){
        isVarnuable = false;
        yield return new WaitForSeconds(3);
        isVarnuable = true;
    }
}
