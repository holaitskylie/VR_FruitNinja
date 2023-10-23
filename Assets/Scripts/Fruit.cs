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
            //Voxel�� ��Ȱ��ȭ ��Ų��
            gameObject.SetActive(false);
            //������Ʈ Ǯ�� �ٽ� �־��ش�
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
