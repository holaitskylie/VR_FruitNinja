using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 오브젝트 풀에 비활성화된 복셀을 담고 싶다
//필요 속성 : 오브젝트 풀, 오브젝트 풀의 크기
public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitFactory;
    public int fruitPoolSize = 20; //오브젝트 풀의 크기
    public static List<GameObject> fruitPool = new List<GameObject>(); //오브젝트 풀

    
    void Start()
    {
        //오브젝트 풀에 비활성화된 복셀을 담고 싶다
        for(int i = 0; i < fruitPoolSize; i++)
        {
            //1. 복셀 공장에서 복셀 생성하기
            GameObject fruit = Instantiate(fruitFactory);
            //2. 복셀 비활성화 하기
            fruit.SetActive(false);
            //3. 복셀을 오브젝트 풀에 담고 싶다
            fruitPool.Add(fruit);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다
        //1. 사용자가 마우스를 클릭했다면
        if (Input.GetButtonDown("Fire1"))
        {
            //2. 마우스의 위치가 바닥 위에 위치해 있다면
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(ray, out hitInfo))
            {
                //3. 복셀 공장에서 복셀을 만들어야 한다
                GameObject fruit = Instantiate(fruitFactory);
                //4. 복셀을 배치하고 싶다
                fruit.transform.position = hitInfo.point;
            }            

        }        

    }
}
