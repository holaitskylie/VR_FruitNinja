using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//화면이 완전히 페이드 되기까지 기다린 후에 씬을 전환한다
public class SceneTransitionManager : MonoBehaviour
{
    public FadeScreen fadeScreen;
    public int sceneIndex = 1;
    

    public LayerMask layer;
    [SerializeField] ParticleSystem sliceEffect;

    private void Update()
    {
        RaycastHit hit;
        //시작 위치, 검이 향하는 방향, 검이 부딪힌 오브젝트의 정보, 길이 2, 레이어 마스트(같은 레이어 마스크만 충돌 처리함)
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2, layer))
        {
            //파티클 이펙트 생성
            ParticleSystem effect = Instantiate(sliceEffect, hit.point, Quaternion.LookRotation(Vector3.forward) * Quaternion.Euler(90, 180, 0));
            if (effect)
            {
                effect.Play();
                Destroy(effect.gameObject, effect.main.duration);
                Debug.Log("Effect Play");
                                
                Destroy(hit.transform.gameObject);

            }

            GoToScene(1);

        }
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //새로운 씬을 연다
        SceneManager.LoadScene(sceneIndex);

    }

    //비동기 씬 관리
    public void GoToSceneAsunc(int sceneIndex)
    {
        StartCoroutine(GoToSceneAsyncRoutine(sceneIndex));
    }
    IEnumerator GoToSceneAsyncRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0f;
        while (timer <= fadeScreen.fadeDuration && !operation.isDone)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;

    }
    
}
