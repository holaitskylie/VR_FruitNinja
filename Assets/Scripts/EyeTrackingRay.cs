using System.Collections.Generic;
using UnityEngine;

//VR 환경에서 사용자의 눈동자의 시선을 시각화한다
//시선이 상호작용 가능한 오브젝트와 상호작용하도록 돕는다
//구성 요소 : 라인렌더러를 사용하여 시선을 시각화하고 레이캐스트 결과를 표시한다
[RequireComponent(typeof(LineRenderer))]
public class EyeTrackingRay : MonoBehaviour
{
    [SerializeField] private float rayDistance = 1.0f; //ray의 길이
    [SerializeField] private float rayWidth = 0.01f; //ray 너비
    [SerializeField] private LayerMask layersToUnclude; //레이캐스트 시 어떤 레이어를 검사할지 결정
    [SerializeField] private Color rayColorDefaultState = Color.yellow; //레이의 디폴트 색상
    [SerializeField] private Color rayColorHoverState = Color.red; //물체에 닿았을 때 레이의 색상

    private LineRenderer lineRenderer; //라인렌더러 컴포넌트에 대한 참조
    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();    
    //레이캐스트 결과에 의해 선택된 상호작용 가능한 오브젝트 추적
    //VR 환경에서는 시선이 여러 오브젝트에 닿을 수 있으므로 모든 선택 항목 추적
    //기본적으로 두 개의 개체를 선택한 다음 어떤 개체가 선택되지 않았는지 추적
    //상호작용 가능한 오브젝트는 EyeInterable 컴포넌트를 사용하여 구현되어야 한다
       
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();
       
    }

    //시각화를 위한 ray 생성, 초기화
    void SetupRay()
    {
        //라인 렌더러가 월드 공간을 사용하지 않는다
        lineRenderer.useWorldSpace = false;
        //라인렌더러의 점 개수를 2개로 설정, 두 개의 끝점을 가진 라인 생성
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;

        //시선은 현재 위치에서 rayDistance만큼 앞으로 나아가는 라인으로 시각화        
        lineRenderer.SetPosition(0, transform.position); 
        lineRenderer.SetPosition(1, new Vector3(transform.position.x,transform.position.y, transform.position.z + rayDistance));
    }

    //레이캐스트를 실행하고 시선이 어떤 물체와 충돌하는지 확인
    private void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 rayCastDirection = transform.TransformDirection(Vector3.forward) * rayDistance;

        //실제 충돌하고 있는지 검사
        //충돌한 물체의 정보를 가져온다
        if(Physics.Raycast(transform.position, rayCastDirection, out hit, Mathf.Infinity, layersToUnclude))
        {
            UnSelect();
            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;

            //어떤 오브젝트와 충돌한다면 해당 오브젝트를 eyeInteractables 리스트에 추가
            var eyeInteractable = hit.transform.GetComponent<EyeInteractable>(); //레이캐스트와 충돌한 오브젝트
            eyeInteractables.Add(eyeInteractable); //리스트추가
            eyeInteractable.IsHovered = true; //상호작용 가능 여부 true 설정
        }
        else
        {
            //어떤 물체와 충돌하지 않는다면
            //Unselect()를 호출하여 이전에 선택된 상호작용 가능한 오브젝트를 선택 해제한다
            lineRenderer.startColor = rayColorDefaultState;
            lineRenderer.endColor = rayColorDefaultState;
            UnSelect(true);
        }

        
    }

    void UnSelect(bool clear = false)
    {
        //상호작용 가능 항목이 있는지 확인
        //eyeInteractables 리스트에 있는 모든 상호작용 가능한 오브젝트의 IsHovered 상태를 false로 설정
        //시선에서 떠나거나 선택이 해제된 오브젝트 처리 작용
        foreach(var interactable in eyeInteractables)
        {
            interactable.IsHovered = false;
        }

        if(clear)
        {
            //리스트를 비운다
            eyeInteractables.Clear();           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
