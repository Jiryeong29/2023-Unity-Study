# GameObject

## 목차

1. [활성상태](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1. [GamObject.SetActive](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
2. [태그](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1. [GameObject.tag](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    2. [GameObject.layer](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    3. [CompareTag](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    4. [FindWithTag](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
3. [컴포넌트 추가 및 제거](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1. [AddComponent<Type>](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    2. [Object.Destory](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
4. [컴포턴트 액세스](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1.  [GetComponent](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    2. [유니티에서 GetComponent랑 AddComponent 차이](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
5. [다른 게임오브젝트의 컴포넌트 액세스](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1. [public 변수로 게임오브젝트 선언](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
6. [자식 게임오브젝트 찾기](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
    1. [Find메서드 이용](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)
7. [이름이나 태그로 게임 오브젝트 찾기](https://www.notion.so/GameObject-f81bcb3e2f5c4bfea2962db9088e8196)

## GameObject

[[참고한 링크 바로가기]](https://docs.unity3d.com/kr/2023.1/Manual/class-GameObject.html)

게임 오브젝트는 Unity의 씬을 위한 빌딩 블록이며, 게임 오브젝트의 모양과 게임 오브젝트의 기능을 결정하는 기능적 컴포넌트의 컨테이너 역할을 합니다.

## 활성상태

![image](https://user-images.githubusercontent.com/52111476/219996395-ef9a6257-95f5-4736-b627-c19eec3628d8.png)


기본적으로 게임오브젝트는 활성상태이지만, 비활성화하여 게임 오브젝트에 연결된 모든 컴포넌트를 해제할 수 있다.

게임 오브젝트의 **활성** 상태는 게임 오브젝트 이름 왼쪽의 체크박스로 표시되며, ****[GameObject](https://docs.unity3d.com/kr/2023.1/ScriptReference/GameObject.html).SetActive**
를 사용하여 제어할 수 있다.

### **GamObject.SetActive**

```csharp
using UnityEngine;

public class Example : MonoBehaviour
{
    // GameObject 배열을 선언합니다.
    // 10개의 GameObject를 저장하기 위해 크기가 10인 배열을 생성합니다.
    private GameObject[] cubes = new GameObject[10];

    // timer와 interval 변수를 선언하고, interval은 2.0으로 초기화합니다.
    public float timer, interval = 2f;

    void Start()
    {
        // Vector3 변수 pos를 (-5, 0, 0)으로 초기화합니다.
				// 첫번째 cube의 위치를 (-5,0,0)으로 초기화합니다.
        Vector3 pos = new Vector3(-5, 0, 0);

        // 10개의 큐브를 생성하고, 위치를 변경하고, 이름을 설정합니다.
        for (int i = 0; i < 10; i++)
        {
            // CreatePrimitive 함수를 사용하여 큐브를 생성합니다.
            // 이 함수는 인자로 받은 PrimitiveType의 종류에 따라 해당하는 기본 도형을 생성합니다.
            // 이 예제에서는 Cube를 생성합니다.
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);

            // 큐브의 위치를 pos로 설정합니다.
            cubes[i].transform.position = pos;

            // 큐브의 이름을 "Cube_i"로 설정합니다.
            cubes[i].name = "Cube_" + i;

            // pos의 x값을 1 증가시켜 다음 큐브의 위치를 결정합니다.
            pos.x++;
        }
    }

    void Update()
    {
        // 타이머를 증가시킵니다.
        timer += Time.deltaTime;

        // 일정 주기마다 모든 큐브의 active 상태를 무작위로 변경합니다.
        if (timer >= interval)
        {
            for (int i = 0; i < 10; i++)
            {
                // 0과 1 중 랜덤으로 값을 선택합니다.
                int randomValue = Random.Range(0, 2);

                // 랜덤 값이 0인 경우 큐브를 비활성화합니다.
                if (randomValue == 0)
                {
                    cubes[i].SetActive(false);
                }
                // 랜덤 값이 1인 경우 큐브를 활성화합니다.
                else
                {
                    cubes[i].SetActive(true);
                }
            }

            // 타이머를 0으로 초기화합니다.
            timer = 0;
        }
    }
}
```

## 태그

### GameObject.tag

```csharp
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        // 스크립트가 시작될 때 게임 오브젝트의 태그를 "Player"로 설정합니다.
        gameObject.tag = "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        // 충돌 이벤트를 일으킨 콜라이더가 "Enemy" 태그를 가지고 있는지 확인합니다.
        if (other.tag == "Enemy")
        {
            // 만약 태그가 "Enemy"이면 콘솔에 메시지를 출력합니다.
            Debug.Log("Triggered by Enemy");        
				}
    }
}
```

### GameObject.layer

```csharp
using UnityEngine;

// 이 스크립트는 에디터 모드에서도 실행되도록 하는 ExecuteInEditMode 속성을 가집니다.
[ExecuteInEditMode]
public class ExampleClass : MonoBehaviour
{
    void Awake()
    {
        // "Ignore Raycast" 레이어의 인덱스를 가져와서 게임 오브젝트의 레이어를 설정합니다.
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        gameObject.layer = LayerIgnoreRaycast;
        // 현재 레이어를 디버그 로그에 출력합니다.
        Debug.Log("Current layer: " + gameObject.layer);
    }
}
```

### CompareTag

```csharp
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    // 트리거 영역 안에 다른 게임 오브젝트가 들어갔을 때 호출되는 함수입니다.
    void OnTriggerEnter(Collider other)
    {
        // 들어온 게임 오브젝트가 "Player" 태그를 가지고 있다면
        if (other.gameObject.CompareTag("Player"))
        {
            // 그 게임 오브젝트를 파괴합니다.
            Destroy(other.gameObject);
        }
    }
}
```

### FindWithTag

```csharp
using UnityEngine;
using System.Collections;

public class Example : MonoBehaviour {
    // 리스폰 프리팹과 리스폰 오브젝트를 저장할 public 변수를 선언합니다.
    public GameObject respawnPrefab;
    public GameObject respawn;

    void Start() {
        // 리스폰 오브젝트가 null인 경우, "Respawn" 태그를 가진 게임 오브젝트를 찾아서 저장합니다.
        if (respawn == null)
            respawn = GameObject.FindWithTag("Respawn");

        // Instantiate 함수를 사용하여 리스폰 프리팹을 생성합니다.
        // 첫 번째 인자: 생성할 게임 오브젝트의 프리팹
        // 두 번째 인자: 생성할 게임 오브젝트의 위치
        // 세 번째 인자: 생성할 게임 오브젝트의 회전 값
        // 네 번째 인자: 생성된 게임 오브젝트를 저장할 변수의 타입 (여기서는 GameObject)
        GameObject clone = Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation) as GameObject;
    }
}

```

## 컴포넌트 추가 및 제거

**런타임 시점에** 컴포넌트를 추가하는 가장 좋은 방법은 `[AddComponent<Type>](https://docs.unity3d.com/kr/2023.1/ScriptReference/GameObject.AddComponent.html)`를 사용하여 여기에 보이는 것처럼 컴포넌트 타입을 꺾쇠 괄호 안에 지정하는 것입니다. 

### **AddComponent<Type>**

```csharp
using UnityEngine;
using System.Collections;

public class AddComponentExample : MonoBehaviour
{
    // 이 스크립트는 Unity에서 game object에 SphereCollider component를 추가하는 방법을 보여줍니다.
    void Start()
    {
        // SphereCollider를 생성하고 현재 game object에 추가합니다.
        // 추가된 SphereCollider는 SphereCollider 타입의 변수인 sc에 저장됩니다.
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
    }
}
```

컴포넌트를 제거하려면 컴포넌트 자체에 대해 `[Object.Destroy](https://docs.unity3d.com/kr/2023.1/ScriptReference/Object.Destroy.html)`
 메서드를 사용해야 합니다.

### **Object.Destory**

```csharp
void DestroyScriptInstance()
{
    // 이 스크립트 인스턴스를 게임 오브젝트에서 제거합니다.
    Destroy(this);
}

void DestroyComponent()
{
    // 게임 오브젝트에서 Rigidbody 컴포넌트를 제거합니다.
    Destroy(GetComponent<Rigidbody>());
}

void DestroyObjectDelayed()
{
    // 게임 오브젝트를 로드한 후 5초 후에 제거합니다.
    Destroy(gameObject, 5);
}

// 사용자가 Ctrl을 누르면 게임 오브젝트에서
// BoxCollider 컴포넌트를 제거합니다.
void Update()
{
    if (Input.GetButton("Fire1") && GetComponent<BoxCollider>())
    {
        Destroy(GetComponent<BoxCollider>());
    }
}
```

## 컴포넌트 액세스

### **GetComponent**

가장 간단한 예로는 게임 오브젝트의 스크립트가 동일한 게임 오브젝트에 연결된 다른 컴포넌트에 액세스해야 하는 경우를 들 수 있습니다(게임 오브젝트에 연결된 다른 스크립트도 컴포넌트 자체라는 점에 유의해야 함). 이렇게 하려면 사용하려는 컴포넌트 인스턴스에 대한 레퍼런스를 먼저 가져와야 합니다. 이때 [GetComponent](https://docs.unity3d.com/kr/2023.1/ScriptReference/Component.GetComponent.html)
 메서드가 사용됩니다. 일반적으로 컴포넌트 오브젝트를 변수에 할당해야 하며, 이는 다음 코드를 통해 수행할 수 있습니다. 다음 예제에서 스크립트는 동일한 게임 오브젝트의 리지드바디 컴포넌트에 대한 레퍼런스를 가져옵니다.

```csharp
void Start ()
{
    Rigidbody rb = GetComponent<Rigidbody>();
}
```

컴포넌트 인스턴스에 대한 레퍼런스가 있으면 인스펙터에서와 마찬가지로 프로퍼티 값을 설정할 수 있습니다.

```csharp
void Start ()
{
    Rigidbody rb = GetComponent<Rigidbody>();

    rb.mass = 10f;
}

```

다음과 같이 컴포넌트 레퍼런스에 대한 메서드를 호출할 수도 있습니다.

```csharp
void Start ()
{
    Rigidbody rb = GetComponent<Rigidbody>();

    rb.AddForce(Vector3.up * 10f);
}

```

> **유니티에서 GetComponent랑 AddComponent 차이**
> 
> 
> `GetComponent`와 `AddComponent`는 둘 다 Unity에서 GameObject의 Component를 가져오거나 추가하는 데 사용된다.
> 
> `GetComponent`는 이미 GameObject에 부착된 Component를 가져오는 데 사용된다. 예를 들어, 스크립트에서 `Transform` 컴포넌트를 가져와 위치, 회전 또는 크기를 변경할 수 있습니다. 또는 `Rigidbody`를 가져와 물리 시뮬레이션을 적용할 수 있다.
> 
> 반면에 `AddComponent`는 GameObject에 새로운 Component를 추가하는 데 사용된다. 예를 들어, 스크립트에서 `SphereCollider`를 추가하여 충돌 감지를 구현할 수 있다.
> 
> 따라서 `GetComponent`와 `AddComponent`는 서로 보완적인 기능을 제공하며 다른 용도로 사용된다. `GetComponent`는 이미 존재하는 Component를 가져오는 데 사용되고, `AddComponent`는 새로운 Component를 추가하는 데 사용된다.
> 

## ****다른 게임 오브젝트의 컴포넌트 액세스****

관련된 게임 오브젝트를 찾는 가장 간단한 방법은 public GameObject 변수를 스크립트에 추가하는 것입니다.

```csharp
public class Chef : MonoBehaviour
{
    public GameObject stove;

    // Other variables and functions...
}

```

이 변수는 인스펙터에서 **GameObject 필드**로 표시됩니다.

씬 또는 계층 구조 패널에서 오브젝트를 이 변수로 드래그하여 할당할 수 있습니다.
![image](https://user-images.githubusercontent.com/52111476/219996465-bab00fd7-201a-41aa-b2d2-752f30ac6d6e.png)


GetComponent 함수와 컴포넌트 액세스 변수는 다른 요소와 마찬가지

GetComponent 함수와 컴포넌트 액세스 변수는 다른 요소와 마찬가지로 이 오브젝트에 이용할 수 있습니다. 따라서 다음과 같은 코드를 사용할 수 있습니다.

```csharp
public class Chef : MonoBehaviour {

    public GameObject stove;

    void Start() {
        transform.position = stove.transform.position + Vector3.forward * 2f;
    }
}

```

또한 스크립트에서 컴포넌트 타입의 public 변수를 선언하면 해당 컴포넌트가 연결된 게임 오브젝트를 드래그할 수 있습니다. 이렇게 하면 게임 오브젝트 자체가 아닌 컴포넌트에 직접 액세스합니다.

```csharp
public Transform playerTransform;
```

## 자식 게임 오브젝트 찾기

```csharp
using UnityEngine;

public class WaypointManager : MonoBehaviour {
    // WaypointManager가 관리하는 웨이포인트들
    public Transform[] waypoints;

    void Start()
    {
        // Manager Transform의 자식 Transform 수를 가져와 배열을 초기화합니다.
        waypoints = new Transform[transform.childCount];
        int i = 0;

        // Manager Transform의 모든 자식 Transform을 반복하면서
        foreach (Transform t in transform)
        {
            // 각각의 자식 Transform을 배열에 추가합니다.
            waypoints[i++] = t;
        }
    }
}

```

또한 [Transform.Find](https://docs.unity3d.com/kr/2023.1/ScriptReference/Transform.Find.html) 메서드를 사용하여 이름별로 특정 자식 오브젝트를 찾을 수 있습니다. `transform.Find("Frying Pan");`

게임플레이 중에 자식 게임 오브젝트가 추가되거나 제거되는 게임 오브젝트가 있을 때 유용합니다. 게임 플레이 중에 집어 들었다가 내려 놓을 수 있는 기구를 예로 들 수 있습니다.

## 이름이나 태그르 게임 오브젝트 찾기

### **이름으로 찾기**

```csharp
GameObject player;

void Start()
{
    player = GameObject.Find("MainHeroCharacter");
}
```

### **태그로 찾기**

오브젝트 또는 오브젝트 컬렉션은 [GameObject.FindWithTag](https://docs.unity3d.com/kr/2023.1/ScriptReference/GameObject.FindWithTag.html) 및 [GameObject.FindGameObjectsWithTag](https://docs.unity3d.com/kr/2023.1/ScriptReference/GameObject.FindGameObjectsWithTag.html) 메서드를 사용하여 태그로도 찾을 수 있습니다.

다음은 한 명의 요리사 캐릭터가 등장하는 요리 게임에서 주방에 여러 개의 스토브(각각 “Stove” 태그 지정)가 있는 경우입니다.

```csharp
GameObject chef;
GameObject[] stoves;

void Start()
{
    chef = GameObject.FindWithTag("Chef");
    stoves = GameObject.FindGameObjectsWithTag("Stove");
}
```

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-activeInHierarchy.html | GameObject가 Scene에서 활성인지 여부를 정의합니다. |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-activeSelf.html | 이 GameObject의 로컬 활성 상태입니다. (읽기 전용) |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-isStatic.html | GameObject의 StaticEditorFlags를 가져오고 설정합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-layer.html | 게임 오브젝트가 있는 레이어. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-scene.html | GameObject가 속한 장면. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-sceneCullingMask.html | 씬 컬링 마스크 Unity는 게임 오브젝트를 렌더링할 씬을 결정하는 데 사용합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-tag.html | 이 게임 오브젝트의 태그입니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-transform.html | 이 GameObject에 연결된 Transform입니다. |

### **생성자**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject-ctor.html | 이름이 지정된 새 게임 개체를 만듭니다. |
| --- | --- |

### **공개 방법**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.AddComponent.html | 게임 개체에 className이라는 구성 요소 클래스를 추가합니다. |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.BroadcastMessage.html | 이 게임 개체 또는 그 자식의 모든 MonoBehaviour에서 methodName이라는 메서드를 호출합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.CompareTag.html | 이 게임 개체에 태그가 붙어 있습니까? |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponent.html | 게임 개체에 하나가 첨부되어 있으면 Type 유형의 구성 요소를 반환하고, 그렇지 않으면 null을 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponentInChildren.html | 깊이 우선 검색을 사용하여 GameObject 또는 그 자식에 있는 Type 유형의 구성 요소를 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponentInParent.html | GameObject 또는 그 부모 중 하나에서 Type 유형의 구성 요소를 검색합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponents.html | GameObject에서 Type 유형의 모든 구성 요소를 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponentsInChildren.html | 깊이 우선 검색을 사용하여 GameObject 또는 그 자식 자식에 있는 Type 유형의 모든 구성 요소를 반환합니다. 재귀적으로 작동합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.GetComponentsInParent.html | GameObject 또는 그 부모 중 하나에서 Type 유형의 모든 구성 요소를 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.SendMessage.html | 이 게임 개체의 모든 MonoBehaviour에서 methodName이라는 메서드를 호출합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.SendMessageUpwards.html | 이 게임 개체의 모든 MonoBehaviour와 동작의 모든 조상에 대해 methodName이라는 메서드를 호출합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.SetActive.html | 주어진 참 또는 거짓 값에 따라 GameObject를 활성화/비활성화합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.TryGetComponent.html | 존재하는 경우 지정된 유형의 구성 요소를 가져옵니다. |

### **정적 메서드**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.CreatePrimitive.html | 프리미티브 메시 렌더러와 적절한 콜라이더를 사용하여 게임 개체를 생성합니다. |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.Find.html | GameObject를 이름으로 찾아 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.FindGameObjectsWithTag.html | 활성 GameObjects 태그 태그의 배열을 반환합니다. GameObject가 발견되지 않으면 빈 배열을 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/GameObject.FindWithTag.html | 하나의 활성 GameObject 태그 태그를 반환합니다. GameObject가 발견되지 않으면 null을 반환합니다. |

### **상속된 구성원**

### **속성**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object-hideFlags.html | 개체를 숨겨야 합니까, 장면과 함께 저장해야 합니까, 아니면 사용자가 수정할 수 있어야 합니까? |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object-name.html | 개체의 이름입니다. |

### **공개 방법**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.GetInstanceID.html | 개체의 인스턴스 ID를 반환합니다. |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.ToString.html | 객체의 이름을 반환합니다. |

### **정적 메서드**

| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.Destroy.html | GameObject, 구성 요소 또는 자산을 제거합니다. |
| --- | --- |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.DestroyImmediate.html | 개체 obj를 즉시 파괴합니다. 대신 Destroy를 사용하는 것이 좋습니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.DontDestroyOnLoad.html | 새 장면을 로드할 때 대상 개체를 파괴하지 마십시오. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.FindObjectOfType.html | Type 유형의 첫 번째 활성 로드된 개체를 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.FindObjectsOfType.html | 유형 유형의 모든 활성 로드된 개체 목록을 반환합니다. |
| https://docs.unity3d.com/2019.4/Documentation/ScriptReference/Object.Instantiate.htmlvvv | 개체 원본을 복제하고 복제본을 반환합니다. |

### **연산자**
