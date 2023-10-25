using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer; //레이어마스크를 이용해 충돌 처리
    Vector3 prevPos; //검의 이전 위치를 저장(이전 위치 - 현재 위치 = 검의 방향)

    [SerializeField] ParticleSystem sliceEffect;


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
            //파티클 이펙트 생성
            ParticleSystem effect = Instantiate(sliceEffect, hit.point, Quaternion.LookRotation(Vector3.forward) * Quaternion.Euler(90, 180, 0));
            if (effect)
            {
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
                Debug.Log("Effect Play");

            }


            Destroy(hit.transform.gameObject);
            Debug.Log("Slice Fruits!");            
                      
        }

        prevPos = transform.position;             

    }
}
