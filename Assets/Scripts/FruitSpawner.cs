using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitFactory;
    public int fruitPoolSize = 20; 
    public static List<GameObject> fruitPool = new List<GameObject>(); //오브젝트 풀

    public float createTime = 0.1f; //생성 시간
    float currentTime = 0; //경과 시간


    
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
        //일정 시간마다 복셀을 만들고 싶다
        //1. 경과 시간이 흐른다
        currentTime += Time.deltaTime;

        //2. 경과 시간이 생성 시간을 초과했다면
        if(currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                //복셀 오브젝트 풀 이용하기
                //1. 만약 오브젝트 풀에 복셀이 있다면
                if (fruitPool.Count > 0)
                {
                    //복셀을 생성했을 때만 경과 시간 초기화
                    currentTime = 0;
                    //2. 오브젝트 풀에서 복셀을 하나 가져온다
                    GameObject fruit = fruitPool[0];
                    //3. 복셀을 활성화한다
                    fruit.SetActive(true);
                    //4. 복셀을 배치하고 싶다
                    fruit.transform.position = hitInfo.point;
                    //5. 오브젝트 풀에서 복셀을 제거한다
                    fruitPool.RemoveAt(0);
                }

            }

        }   
        
    }
}
