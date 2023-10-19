using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. ������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�
//�ʿ� �Ӽ� : ������Ʈ Ǯ, ������Ʈ Ǯ�� ũ��
public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitFactory;
    public int fruitPoolSize = 20; //������Ʈ Ǯ�� ũ��
    public static List<GameObject> fruitPool = new List<GameObject>(); //������Ʈ Ǯ

    
    void Start()
    {
        //������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�
        for(int i = 0; i < fruitPoolSize; i++)
        {
            //1. ���� ���忡�� ���� �����ϱ�
            GameObject fruit = Instantiate(fruitFactory);
            //2. ���� ��Ȱ��ȭ �ϱ�
            fruit.SetActive(false);
            //3. ������ ������Ʈ Ǯ�� ��� �ʹ�
            fruitPool.Add(fruit);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�
        //1. ����ڰ� ���콺�� Ŭ���ߴٸ�
        if (Input.GetButtonDown("Fire1"))
        {
            //2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(ray, out hitInfo))
            {
                //3. ���� ���忡�� ������ ������ �Ѵ�
                GameObject fruit = Instantiate(fruitFactory);
                //4. ������ ��ġ�ϰ� �ʹ�
                fruit.transform.position = hitInfo.point;
            }            

        }        

    }
}
