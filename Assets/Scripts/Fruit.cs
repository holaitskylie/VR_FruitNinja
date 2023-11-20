using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fruit : MonoBehaviour
{
    public float speed = 5; 
    public float destoryTime = 3.0f; 
    float currentTime;

    private bool isHit = false;

    void OnEnable()
    {
        currentTime = 0;
        //Vector3 direction = Random.insideUnitSphere;
        //Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = direction * speed;
        
    }

    void Update()
    {        
        currentTime += Time.deltaTime;
        
        if(currentTime > destoryTime)
        {
            //Voxel을 비활성화 시킨다
            gameObject.SetActive(false);
            //오브젝트 풀에 다시 넣어준다
            FruitSpawner.fruitPool.Add(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" && !isHit)
        {
            isHit = true;
            Destroy(gameObject);

            Debug.Log("Fruit Sliced!");
            
        }
    }
}
