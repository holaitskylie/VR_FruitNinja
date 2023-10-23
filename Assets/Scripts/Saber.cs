using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer; //레이어마스크를 이용해 충돌 처리
    Vector3 prevPos; //검의 이전 위치를 저장(이전 위치 - 현재 위치 = 검의 방향)

    public Vector3 direct;
    Vector3 lastDirection; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        //시작 위치, 검이 향하는 방향, 검이 부딪힌 오브젝트의 정보, 길이 1, 레이어 마스트(같은 레이어 마스크만 충돌 처리함)
        if(Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {

            //Destroy(hit.transform.gameObject);
            //Debug.Log("Slice Fruits!");

            //각도가 같은지 체크한다
            //Vector3.Angle() 두 벡터 사이의 앵글값(각도)를 구해준다
            //현재 검의 위치(transform.position) - 이전 검의 위치(prevPos)
            /*
            if (Vector3.Angle(transform.position - prevPos, hit.transform.up) > 10)
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Slice Fruits!");
            }*/

        }

        prevPos = transform.position;
        /*
        RaycastHit hit;
        direct = transform.position - lastDirection;
        lastDirection = transform.position;
        direct = direct.normalized;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, layer))
        {
            if (Vector3.Angle(direct, transform.forward) <= 60)
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Slice Fruits!");

            }

        }*/

       

    }
}
