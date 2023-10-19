using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//구성 요소 : 물리적 레이캐스트를 사용하기에 충돌체가 필요
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EyeInteractable : MonoBehaviour
{
    //마우스 오버 상태
    public bool IsHovered { get; set; }
    [SerializeField] private UnityEvent<GameObject> onObjectHover;
    [SerializeField] private Material OnHoverActiveMaterial;
    [SerializeField] private Material OnHoverInactiveMaterial;
    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()=>meshRenderer=GetComponent<MeshRenderer>();
    
    void Update()
    {
        if (IsHovered)
        {
            meshRenderer.material = OnHoverActiveMaterial;
            onObjectHover?.Invoke(gameObject);
        }
        else
        {
            meshRenderer.material = OnHoverInactiveMaterial;
        }
    }
}
