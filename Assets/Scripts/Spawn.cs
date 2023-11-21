using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] pos; //spawn positions
    public GameObject[] prefab; //fruits

    AudioSource audio;

    float minWaitTime = 2.0f;
    float maxWaitTime = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            if (GameManager.Instance.isGameover)
            {
                yield break; // Coroutine 종료
            }

            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            for(int i = 0; i <pos.Length; i++)
            {
                int iPrefab = Random.Range(0, prefab.Length);
                int iPos = Random.Range(0, pos.Length);

                GameObject obj = Instantiate(prefab[iPrefab], pos[iPos].position, Quaternion.identity);

                Destroy(obj, 3f);

                Rigidbody rb = obj.GetComponent<Rigidbody>();
                //ForceMode.VelocityChange : 현재 속도를 무시하고 주어진 힘의 크기와 방향으로 속도 설정
                rb.AddForce(Vector3.up * Random.Range(4.0f, 10.0f), ForceMode.VelocityChange);
                //rb.AddForce(Vector3.up * Random.Range(4.0f, 10.0f));
            }

            audio.Play();
            
        }
    }

    public void DecreaseInterval()
    {
        minWaitTime = Mathf.Max(minWaitTime - 0.5f, 1.0f);
        maxWaitTime = Mathf.Max(maxWaitTime - 0.5f, 2.0f);

        if(maxWaitTime <= 0.1f)
        {
            maxWaitTime = 0.1f;
        }

        if(minWaitTime <= 0.1f)
        {
            minWaitTime = 0.1f;
        }

    }
    
        
}
