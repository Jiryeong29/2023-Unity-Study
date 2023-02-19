# 제약(Constraint)

# [제약(Constraint)](https://docs.unity3d.com/kr/2019.4/Manual/Constraints.html)

## Constraint컴포넌트 종류

Constraint컴포넌트는 -게임 오브젝트의 위치, 회전, 크기 등을 제한하여 움직임을 제어하는 구성 요소

게임오브젝트의 포지션, 회전 또는 확대/축소를 다른 게임오브젝트에 연결한다.

Unity에서 지원하는 제약 컴포넌트 타입은 다음과 같습니다.

- **Position Constraint**: 선택한 게임 오브젝트를 다른 게임 오브젝트나 고정된 위치에 고정합니다.
- **Rotation Constraint**: 선택한 게임 오브젝트를 다른 게임 오브젝트나 고정된 방향으로 고정합니다.
- **Scale Constraint**: 선택한 게임 오브젝트의 크기를 다른 게임 오브젝트나 고정된 크기로 고정합니다.
- **Aim Constraint**: 선택한 게임 오브젝트가 다른 게임 오브젝트를 바라보도록 합니다.
- **LookAt Constraint**: 선택한 게임 오브젝트가 다른 게임 오브젝트를 바라보도록 하며, 거리와 회전도 제어할 수 있습니다.
- **Parent Constraint**: 선택한 게임 오브젝트를 다른 게임 오브젝트에 자식으로 연결합니다.
- [조준(Aim)](https://docs.unity3d.com/kr/2019.4/Manual/class-AimConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트 방향으로 회전시킵니다.
- [LookAt](https://docs.unity3d.com/kr/2019.4/Manual/class-LookAtConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트 방향으로 회전시킵니다(간소화된 조준 제약).
- [부모(Parent)](https://docs.unity3d.com/kr/2019.4/Manual/class-ParentConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트와 함께 이동 및 회전시킵니다.
- [포지션(Position)](https://docs.unity3d.com/kr/2019.4/Manual/class-PositionConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트처럼 이동시킵니다.
- [회전(Rotation)](https://docs.unity3d.com/kr/2019.4/Manual/class-RotationConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트처럼 회전시킵니다.
- [스케일(Scale)](https://docs.unity3d.com/kr/2019.4/Manual/class-ScaleConstraint.html): 제약된 게임 오브젝트를 연결된 게임 오브젝트처럼 확대/축소합니다.

```csharp
일련의 게임 오브젝트를 제약할 수 있습니다. 예를 들어 아기 오리들이 엄마 오리를 일렬로 따라가게 하려면 포지션 제약(Position Constraint) 컴포넌트를 Duckling1 게임 오브젝트에 추가합니다. 소스(Sources) 리스트에서 MotherDuck 에 연결합니다. 그런 다음, 포지션 제약 을 Duckling1 에 연결되는 Duckling2 에 추가합니다. MotherDuck 게임 오브젝트가 씬에서 이동하면 Duckling1 이 MotherDuck 을 따라가고 Duckling2 가 Duckling1 을 따라갑니다.
```

## Position Constraint

Position Constraint 컴포넌트는 소스 게임 오브젝트를 따라가도록 게임 오브젝트를 움직인다.![image](https://user-images.githubusercontent.com/52111476/219954901-713ffffb-fc0b-411b-a69f-40feae931257.png)

gameobject가 Player를 따라가도록 제약을 걸어줌

### PositionConstraint의 사용방법

1. 카메라를 선택한 후, Add Component 메뉴에서 "Constraints > Position Constraint"를 선택한다.
2. "Source"를 클릭하여 따라가고 싶은 게임 오브젝트를 선택한다.
3. "Weight" 값을 1로 설정합니다.
4. "Offset" 값을 사용하여 카메라와 따라가고 싶은 게임 오브젝트 간의 거리를 조절한다. 예를 들어, 게임 오브젝트가 캐릭터라면 Offset 값을 적절히 설정하여 캐릭터 주위를 돌면서 따라다니는 카메라를 만들 수 있다.
5. "Maintain Offset" 옵션을 활성화하여 카메라와 따라가고 싶은 게임 오브젝트 간의 거리를 일정하게 유지할 수 있다.

## Positon Constraint 프로퍼티

| Position Offset | 대상 객체와의 상대적인 위치를 결정하는 오프셋 값입니다. 이 값은 대상 객체의 위치에 더해져서 움직임의 범위를 제한하게 됩니다. |
| --- | --- |
| Weight | 제약 조건이 적용되는 정도를 나타내는 값입니다. 이 값이 1이면 제약 조건이 완전히 적용되고, 0이면 제약 조건이 적용되지 않습니다. 값이 0과 1 사이의 값으로 설정될 수 있으며, 이를 이용하여 부드러운 움직임을 만들어낼 수 있습니다. |
| Target Object | 제약 조건을 적용할 대상 객체를 선택합니다. 이 대상 객체는 보통 다른 객체와의 상대적인 위치를 기준으로 움직이게 됩니다. |
| Maintain Offset | 대상 객체와의 상대적인 위치를 유지할지 여부를 결정합니다. 이 값이 "On"으로 설정된 경우, 대상 객체와의 초기 상대적인 위치를 유지하면서 객체를 움직이게 됩니다. "Off"로 설정된 경우, 대상 객체와의 상대적인 위치를 무시하고 객체를 자유롭게 움직일 수 있습니다. |

### 주의) isActive를 반드시 활성화 시켜줘야 동작한다.
![image](https://user-images.githubusercontent.com/52111476/219954943-61a08200-7174-45d5-9c11-dc749d5af49d.png)
### ConstraintSettings>Lock을 풀고 의 **오프셋(Offset)**프로퍼티를 사용하여 게임 오브젝트를 제약하는 경우에 사용할 X, Y, Z 값을 지정하여 세밀한 위치 조정이 가능하다.
![image](https://user-images.githubusercontent.com/52111476/219954956-37e29e3e-8476-4a7f-b2d4-8faf9ace73c0.png)

# [Look At Constraint](https://docs.unity3d.com/kr/2019.4/Manual/class-LookAtConstraint.html)

Look At Constraint- 게임 오브젝트가 소스 게임 오브젝트를 향하도록 회전하게 한다.

이 컴포넌트를 사용하면, 예를 들어 카메라를 항상 캐릭터나 물체를 바라보도록 만들 수 있다.

보통 Look At Constraint는 하나 이상의 게임 오브젝트를 따라가도록 [카메라](https://docs.unity3d.com/kr/2019.4/Manual/class-Camera.html)에 적용한다.

LookAtConstraint를 사용하면 회전값을 쉽게 조정할 수 있으며, 애니메이션을 더 자연스럽게 만들어줄 수도 있다. 이를 통해 게임이나 애니메이션을 더 현실적으로 만들 수 있다.

### 사용방법

1. LookAtConstraint 컴포넌트를 선택할 오브젝트에 추가합니다.
2. LookAtConstraint 컴포넌트의 속성을 설정합니다.
    - LookAt Object: LookAtConstraint를 따라 회전할 대상 오브젝트나 위치를 설정합니다.
    - Up Vector: LookAtConstraint를 따라 회전할 때 위쪽 방향을 설정합니다.
    - World Up Type: Up Vector의 방향을 설정합니다. (Object Up, Scene Up, Vector)
    - World Up Vector: World Up Type이 Vector인 경우에 사용됩니다.
3. 이제 선택한 오브젝트는 LookAt Object나 위치를 향해 회전합니다.

<aside>
📢 LookAtConstraint는 또한 Weight를 사용하여 여러 대상을 동시에 회전시킬 수 있습니다. 이 경우, 각 대상의 Weight 값을 조정하여 LookAtConstraint를 얼마나 따르게 할지 조절할 수 있습니다.
PositionConstraint와 함께 사용하면, LookAtConstraint를 사용하여 회전하면서 동시에 이동할 수도 있습니다. 예를 들어, 카메라가 특정 오브젝트를 항상 바라보면서 그 오브젝트를 따라 이동하도록 만들 수 있습니다.
이러한 방식으로 LookAtConstraint를 사용하면 게임 또는 애니메이션에서 오브젝트 간 상호작용을 더 자연스럽게 만들 수 있습니다.

</aside>

### 프로퍼티

| LookAtPosition | 오브젝트가 바라볼 위치를 지정합니다. 이 위치를 지정하면 대상 오브젝트를 직접 지정하는 대신 위치를 기반으로 오브젝트를 회전시킬 수 있습니다. |
| --- | --- |
| WorldUpObject | 대상을 바라볼 때 오브젝트가 사용할 "위" 벡터를 결정합니다. 이 벡터는 주로 오브젝트의 Y축을 사용합니다. 대상을 바라보는 동안 오브젝트의 회전이 완전히 제어되는 것이 아니기 때문에 이 프로퍼티를 사용하여 오브젝트가 "위"로 바라보도록 유지할 수 있습니다. |
| Attraction | 대상과 오브젝트 사이의 거리에 영향을 미치는 값을 나타냅니다. 이 값이 높을수록 오브젝트가 대상에 가까이 있으려고 하고, 이 값이 낮을수록 오브젝트가 더 멀리 있으려고 합니다. |
| Rotation Offset | 대상과 일치하지 않는 방향으로 오브젝트를 회전시키는 데 사용되는 오프셋 값을 나타냅니다. |
| Freeze Axes | 선택한 축을 고정하여, 해당 축을 따라 오브젝트가 회전하지 않도록 합니다. |

<aside>
📢 **유니티에서 카메라가 플레이어를 따라가도록 할때,스크립트를 이용해서 구현하는게 나은가요? 아니면 LookAtConstraint 컴포넌트랑 PositionConstraint컴포넌트를 이용해서 구현하는게 나은가요?**

LookAtConstraint과 PositionConstraint을 사용하여 카메라를 따라다니도록 설정할 수 있습니다. 이를 위해서는 각각의 컴포넌트를 카메라 오브젝트에 추가하고, 대상 오브젝트와 옵션을 설정해주어야 합니다. 이 방법은 비교적 직관적이고, 간단한 기능을 구현할 때 유용합니다.
그러나 더 많은 제어와 유연성이 필요한 경우, 코드를 사용하여 카메라를 따라다니는 것이 더 나을 수 있습니다. 스크립트를 사용하면 플레이어와 카메라 사이의 거리, 회전, 이동 방식 등을 보다 정교하게 제어할 수 있습니다. 또한 스크립트를 사용하면 게임 로직에 따라 카메라를 동적으로 이동시킬 수 있기 때문에, 게임플레이가 더욱 동적으로 변할 수 있습니다.
따라서 어떤 방법이 좋은지는 구현하려는 게임의 성격과 구현 방식에 따라 다릅니다. 간단한 게임의 경우 LookAtConstraint과 PositionConstraint를 사용하는 것이 좋을 수 있지만, 복잡한 게임이나 세부적인 제어가 필요한 경우는 코드를 사용하는 것이 더 나을 수 있습니다.

</aside>

<aside>
📢 **LookAtConstraint 컴포넌트랑 PositionConstraint컴포넌트는 언제 많이 사용되나요?**

LookAtConstraint 컴포넌트와 PositionConstraint 컴포넌트는 Unity에서 일반적으로 게임 오브젝트 간의 상호작용을 구현할 때 사용됩니다. 그러나 사용되는 시나리오는 상황에 따라 다르므로 다음과 같은 경우에 많이 사용됩니다.

**LookAtConstraint 컴포넌트는 주로 다음과 같은 경우에 사용됩니다.**

- 카메라가 특정 대상을 바라보도록 제어하는 경우
- 캐릭터가 상대를 바라보도록 제어하는 경우
- NPC가 플레이어를 바라보도록 제어하는 경우

**PositionConstraint 컴포넌트는 다음과 같은 경우에 사용됩니다.**

- 대상 위치에 도달하기 위해 특정 루트 모션을 따라 이동해야 하는 경우
- 프로젝트에서 설정한 위치로 이동해야 하는 경우
- 레벨 디자인 시스템에서 오브젝트를 쉽게 배치하고 조정해야 하는 경우

이러한 컴포넌트들은 게임에서 유용한 기능들을 제공하며, 게임 오브젝트 간의 상호작용을 구현하는 데 도움을 줍니다. 그러나 그들은 게임 개발자가 자신의 게임에 적절하게 적용할 수 있는 도구일 뿐이므로, 사용 여부는 게임 개발자의 판단에 달려 있습니다.

**AimConstraint는 주로 다음과 같은 경우에 사용됩니다.**

- 총알이나 화살이 목표물을 정확히 쏘기 위해 사용됩니다.
- 미사일이나 로켓이 목표물을 추적하기 위해 사용됩니다.
- 캐릭터가 상대방을 바라보도록 제어하는 경우 사용됩니다.
</aside>

# Rotation Constraint

Rotation Constraint 컴포넌트는 일반적으로 다양한 유형의 게임 오브젝트에서 사용됩니다. 여기에는 캐릭터, 카메라, 차량 등이 포함됩니다. 아래는 각 오브젝트 유형에 대한 구체적인 예시입니다.

1. 캐릭터
캐릭터의 경우, Rotation Constraint 컴포넌트를 사용하여 캐릭터의 헤드 또는 상체를 제한할 수 있습니다. 예를 들어, 캐릭터의 머리가 특정 방향으로 회전하지 않도록 할 수 있습니다. 이를 통해 게임이 보다 자연스러워지고, 현실감 있는 캐릭터 모델링이 가능합니다.
2. 카메라
카메라의 경우, Rotation Constraint 컴포넌트를 사용하여 카메라의 회전 속도와 방향을 제한할 수 있습니다. 예를 들어, 카메라가 너무 빨리 움직여 더 이상 추적할 수 없는 객체를 추적하는 경우, Rotation Constraint 컴포넌트를 사용하여 카메라가 지정된 각도 이상 회전하지 않도록 할 수 있습니다.
3. 차량
차량의 경우, Rotation Constraint 컴포넌트를 사용하여 차량의 바퀴나 핸들의 회전을 제한할 수 있습니다. 예를 들어, 차량의 바퀴가 90도 이상 회전하지 않도록 하여 게임이 보다 현실적으로 보이도록 할 수 있습니다.

이와 같이, Rotation Constraint 컴포넌트는 다양한 게임 오브젝트에서 사용될 수 있습니다. 이를 통해 게임이 보다 자연스러워지고, 플레이어는 예상 가능한 방식으로 오브젝트를 조작할 수 있습니다.

## Parent Constraint

Parent Constraint 컴포넌트는 일반적으로 다양한 유형의 게임 오브젝트에서 사용됩니다. 여기에는 캐릭터, 무기, 동물 등이 포함됩니다. 아래는 각 오브젝트 유형에 대한 구체적인 예시입니다.

1. 캐릭터
캐릭터의 경우, Parent Constraint 컴포넌트를 사용하여 캐릭터의 상체, 하체, 머리, 팔, 다리 등을 서로 다른 오브젝트에 부착할 수 있습니다. 예를 들어, 캐릭터의 팔을 다른 오브젝트에 부착하여 총기 조작 또는 손상 시 현실적인 애니메이션을 만들 수 있습니다.
2. 무기
무기의 경우, Parent Constraint 컴포넌트를 사용하여 무기를 플레이어의 손에 고정시킬 수 있습니다. 예를 들어, 총기를 플레이어의 손에 부착하여 총기 조작을 가능하게 할 수 있습니다.
3. 동물
동물의 경우, Parent Constraint 컴포넌트를 사용하여 동물의 머리, 꼬리 등을 다른 오브젝트에 부착할 수 있습니다. 예를 들어, 말의 꼬리를 부드럽게 움직이기 위해 꼬리를 다른 오브젝트에 부착할 수 있습니다.

이와 같이, Parent Constraint 컴포넌트는 다양한 게임 오브젝트에서 사용될 수 있습니다. 이를 통해 게임이 보다 현실감 있게, 효과적으로 디자인되어 보다 매끄러운 애니메이션을 만들 수 있습니다.

# Scale Constraint

Scale Constraint 컴포넌트는 일반적으로 특정 조건에서 객체의 크기를 자동으로 조절하는 데 사용됩니다.

예를 들어, 만약 게임에서 플레이어 캐릭터가 더 이상 아이템을 더 이상 소지할 수 없는 경우, 인벤토리 UI를 사용하여 아이템 목록을 표시할 수 있습니다. 이 UI는 일반적으로 스크롤링 목록으로 구성되며, 항목이 추가될 때마다 UI 요소의 크기가 자동으로 조정되어 항목이 모두 표시됩니다.

이 경우 Scale Constraint를 사용하여 UI 요소의 크기를 자동으로 조정할 수 있습니다. 예를 들어, 게임 오브젝트의 부모에 Scale Constraint 컴포넌트를 추가하고, Scale Constraint 컴포넌트에서 스케일 속성을 UI 요소의 크기와 연결하면, 항목이 추가될 때마다 UI 요소의 크기가 자동으로 조정됩니다.

또 다른 예로는, 충돌체를 가진 물체를 다룰 때 Scale Constraint를 사용할 수 있습니다. 만약 게임에서 물체를 조정하는 동안 충돌체가 포함된 경우, Scale Constraint를 사용하여 물체의 크기를 조정할 수 있습니다. 이를 통해 충돌체가 제대로 크기에 맞게 조정되어 충돌 감지가 올바르게 작동합니다.

이와 같이 Scale Constraint는 게임 오브젝트의 크기가 자주 변경되는 경우 또는 크기가 자동으로 조정되어야 하는 경우에 유용하게 사용될 수 있습니다.
