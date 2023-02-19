# Layer & Tag

## 태그와 레이어의 차이

**레이어**는 엔진의 기능적인 부분에 쓰이고 **태그**는 스크립트에서만 쓰인다는 점을 차이점을 가진다. 

**레이어**는 불필요한 체크, 계산 등을 피할 수 있기 때문에 게임에 필요한 최소한의 연산만 해서 원하는 결과를 얻을 수 있음( 성능적인 개선에 있어 필수적 )

- 그룹 관리
- 넓은 범위
- 등록할 수 있는 Layer개수가 한정적임

**태그**는 필수는 아니지만 게임을 만들 때 유용하고 다양하게 사용됨.

- 오브젝트들을 식별하는 데 사용
- 단일 게임오브젝트
- 좁은 범위
- 수많은 Tag를 등록할 수 있음

⇒ 레이 캐스팅에서 LayerMask를 사용해 게임오브젝트들을 판단하고, 이후에 Tag로 게임오브젝트를 판별하여, 대상을 확인

## 태그

**스크립팅 목적으로 게임 오브젝트를 식별할 때 도움을 즘**

**태그(Tag)**는 한 개 이상의 **게임 오브젝트**에 할당할 수 있는 레퍼런스 단어이다 .Tag는 Layer와 달리 많은 수의 Tag를 등록하여, 오브젝트를 구별할 수 있다.

**예를 들어)**
플레이어가 조작하는 캐릭터에 “Player”를, 플레이어가 조작하지 않는 캐릭터에 “Enemy” 태그를 붙일 수 있다. 씬에서 플레이어가 모을 수 있는 아이템에 “Collectable” 태그를 붙일 수도 있다.

**태그(Tag)**는 게임 오브젝트를 더 쉽게 식별할 수 있도록 해줍니다. 예를 들어, **"Player" 태그를 가진 게임 오브젝트를 찾아서 그 오브젝트의 상태를 변경하는 스크립트를 작성**할 수 있습니다. 태그는 오브젝트가 가지는 여러 속성 중 하나이며, 레이어와는 달리 렌더링 순서나 충돌 검사에는 사용되지 않는다.
****게임 오브젝트를 수동으로 스크립트의 노출 프로퍼티에 드래그 앤 드롭으로 추구할 필요가 없게 해주므로 여러 게임 오브젝트에 같은 스크립트 코드를 사용할 때 시간이 절약됨.

[GameObject.FindWithTag()](https://docs.unity3d.com/kr/2019.4/ScriptReference/GameObject.FindWithTag.html) 함수를 사용해서 원하는 태그를 포함한 게임 오브젝트를 찾을 수 있다. 
다음 예제는 “Respawn” 태그가 붙은 게임 오브젝트에서 GameObject.FindWithTag(). It instantiates `respawnPrefab`을 사용한 것

C# 스크립트에서 레이어나 태그를 사용할 때는 LayerMask나 CompareTag 등의 함수를 사용하여 참조할 수 있다.

```csharp
using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
    public GameObject respawnPrefab;
    public GameObject respawn;
    void Start() {
        if (respawn == null)
            respawn = GameObject.FindWithTag("Respawn");
        
        Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
    }
}
```

## **레이어**

Unity 에디터에서 **특정 특성을** 공유하는 오브젝트 그룹을 생성할 때 레이어를 사용합니다. 자세한 내용은 [레이어](https://docs.unity3d.com/kr/2019.4/Manual/Layers.html) 문서를 참조하십시오. 사용자 레이어는 주로 레이캐스팅 또는 렌더링과 같은 작업을 제한하며, 관련된 오브젝트 그룹에만 적용됩니다.

- **레이어(Layers)**는 **카메라**가 씬의 일부만 렌더링하고 **광원**이 씬의 일부만 비추기 위해 가장 많이 사용됨
- 그 외에도 콜라이더를 선별적으로 무시하거나 [충돌](https://docs.unity3d.com/kr/2019.4/Manual/LayerBasedCollision.html)을 생성하기 위해 레이캐스팅에서도 사용됨
- ⇒ 게임 오브젝트의 렌더링 순서를 제어하고 충돌 감지, 레이캐스팅 등에서도 사용

 예를 들어, "Player" 레이어와 "Enemy" 레이어가 있을 경우, "**Player" 레이어의 캐릭터와 "Enemy" 레이어의 적이 충돌했을 때 다른 동작을 하도록** 구현할 수 있다. 또한, 레이어별로 렌더링 순서를 지정하여 적이 플레이어 뒤를 지나가지 않도록 하거나, 특정 레이어의 오브젝트를 카메라로부터 숨길 수도 있다.→ Camera>CullingMask 상

### 레이어 사용법

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/c04b9770-a62a-45d5-b283-33a699fee7df/Untitled.png)

  **Builtin Layer** 는기본적으로 Unity가 사용하며, 편집이 불가능하다. 하지만 **User Layer** 는 커스터마이즈할 수 있다. ( **Builtin Layer와 User Layer의** 갯수는 유니티 버전마다 다른거 같다.)

**User Layer** 를  **커스터마이즈하려면 사용할 레이어의 텍스트 필드에 원하는 이**름을 입력한다. 레이어의 수를 추가할 수는 없지만 태그와 달리 레이어는 이름을 바꿀 수 있다.

## 카메라의 컬링 마스크로 씬의 일부만 그리기

카메라의 컬링 마스크를 사용하여 특정 레이어 하나에 있는 오브젝트를 선별적으로 렌더링할 수 있다.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/4929b2df-01f1-4bdd-b464-8eca90328e8d/Untitled.png)

Culliung Mask > Everyting은 Layer와 상관없이 모든 Layer들을 gamescene에서 보여준다. 

예를들어

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/3223cd88-b113-4f41-90cf-43c992b82fb4/Untitled.png)

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/58f52fa4-6171-4e59-9aa4-3d94e17953ae/Untitled.png)

Player오브젝트의 Layer를 Player로 바꿔놓고 Camera>CullingMask> Player로 바꾸면
gamescene에서 카메라는 Player만 선별적으로 비춘다.

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/1a7313bc-820b-4329-8dc3-9e7775fabdb2/Untitled.png)

[잘설명해주는 사이트](https://unitybeginner.tistory.com/56)-이런식으로 사용가능하다.

## **선별적 레이캐스팅- 모르겠음**

레이어를 레이캐스팅에 사용하고 특정 레이어의 콜라이더를 무시하는 데 사용할 수 있습니다. 예를 들어 플레이어 레이어에만 레이캐스팅를 적용하고 그 외의 모든 콜라이더는 무시하고 싶을 수 있습니다.

Physics.Raycast 함수는 비트마스크를 사용하고, 각 비트에 따라 레이어 무시 여부가 결정됩니다. 레이어마스크의 모든 비트가 켜져 있으면 모든 콜라이더에 충돌합니다. 레이어마스크가 = 0이면 어떤 것도 레이와 충돌하지 않습니다.

```
int layerMask = 1 << 8;

// Does the ray intersect any objects which are in the player layer.
if (Physics.Raycast(transform.position, Vector3.forward, Mathf.Infinity, layerMask))
{
    Debug.Log("The ray hit the player");
}

```

하지만, 보통은 그 반대로 플레이어 레이어에 있는 콜라이더를 제외한 모든 콜라이더에 레이캐스트를 적용하는 것을 원합니다.

```
void Update ()
{
    // Bit shift the index of the layer (8) to get a bit mask
    int layerMask = 1 << 8;

    // This would cast rays only against colliders in layer 8.
    // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
    layerMask = ~layerMask;

    RaycastHit hit;
    // Does the ray intersect any objects excluding the player layer
    if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, layerMask))
    {
        Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) * hit.distance, Color.yellow);
        Debug.Log("Did Hit");
    }
    else
    {
        Debug.DrawRay(transform.position, transform.TransformDirection (Vector3.forward) *1000, Color.white);
        Debug.Log("Did not Hit");
    }
}

```

레이어마스크를 Raycast 함수에 전달하지 않으면 IgnoreRaycast 레이어를 사용하는 콜라이더만 무시됩니다. 이 방법은 레이캐스팅을 적용할 때 일부 콜라이더를 무시하는 가장 간단한 방법입니다.

**참고**: 레이어 31은 에디터의 미리보기 창 메커니즘에서 내부적으로 사용됩니다. 충돌을 방지하기 위해 이 레이어를 사용하지 마십시오.

## 레이어 기반 충돌감지

![image](https://user-images.githubusercontent.com/52111476/219955122-0074bcfb-89bc-4ae9-b669-44d4e32236f7.png)


**물리가 자세하게 필요한 게임이라면 여기서 설정을 통해 원하는 방식의 게임으로 제작이 가능할 것같다.**

**유니티 도큐에서 보면 질량의무게, 속도 임계값, 선형보간등을 설정이 가능하다.**

**Edit**> **Project Settings>****Physics> LayerCollisionMatrix 에서 설정을 필요에 맞게 변경할 수 있다.**

![image](https://user-images.githubusercontent.com/52111476/219955136-ff545522-cec6-4f98-afc0-d5e0e4469f58.png)


Player/Monster 선택을 해제해주면 Player Layer에 해당하는 오브젝트와 MonsterLayer에 해당하는 오브젝트가 서로 충돌하지 않는다.

[[자세한 설명 참고사이트]](https://funfunhanblog.tistory.com/55)- 예시
