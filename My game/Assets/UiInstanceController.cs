using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInstanceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject instanceIcon;
    private Stack<GameObject> instanceStack;
    private float offset;
    [SerializeField]
    [Range(0, 99)]
    private int instanceMaxCount;
    private float instanceCount;

    void Start()
    {
        offset = 40;
        instanceMaxCount = 4;
        instanceStack = new Stack<GameObject>();
        UpdateInstanceCount();
        CreateInstance(instanceMaxCount);  
    }

    // Update is called once per frame
    public void CreateInstance(){
        if(instanceCount< instanceMaxCount){
            Vector2 newPosition =
            new Vector2(this.transform.position.x +(instanceCount * offset), transform.position.y);
            GameObject newInstance =Instantiate(instanceIcon, transform.position,Quaternion.identity);
            newInstance.transform.parent = transform;
            newInstance.transform.position = newPosition;
            instanceStack.Push(newInstance);
            UpdateInstanceCount();
        }
    }

    public void CreateInstance(int _number){
        for(int i=0; i<_number; i++)
        {
            CreateInstance();
        }
    }

    public void DestroyInstance(){
        if(instanceStack.Count>0){
            Destroy(instanceStack.Pop().gameObject);
            UpdateInstanceCount();
        }
    }

    private void UpdateInstanceCount(){
        instanceCount = instanceStack.Count;
    }
}
