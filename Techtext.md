# 프로젝트: People in the Hole
**레퍼런스**: [Hole People 게임 영상](https://www.youtube.com/watch?v=c2J2OtiSWsU&list=PLEOnLO5L7cCcNY089THSghdJIr59HKc44)  
**개발 환경**: Unity 6

## 프로젝트 개요

색상별 캐릭터를 같은 색의 구멍으로 유도하는 퍼즐게임이다.  
캐릭터간의 충돌여부와 경로를 구축하여 모든 캐릭터를 구멍에 넣어 클리어되는 방식이다.

## 핵심설계

**GameManager** : 싱글톤 패턴 적용, 필드의 캐릭터 카운트 체크 및 게임 클리어 UI 관리  
**RaycastManager** : 플레이어 클릭을 감지하여 특정 Hole의 위치 정보 전달  
**HoleManager** : 캐릭터 Hole 진입 시 색상 일치 여부 판정 및 카운트 감소 호출  
**CharaterManager** : `NavMeshAgent` 기반 이동 로직 및 `Raycast`를 통한 전방 장애물 체크

## 주요 기술적 도전 및 해결
1. 캐릭터 이동 시스템  
`NavMesh` 기반의 움직임으로 캐릭터들이 목표지점까지 최단거리로 향하는 로직을 만들었고 캐릭터에게 `NavMeshAgent`와 `NavMeshObstacle` 컴포넌트를 추가하여 움직임 명령에 따라 각 컴포넌트가 On, Off 되게 구현함

2. Hole 진입 판정과 필드 정보 업데이트  
'HoleManager' 에서 Hole에 진입한 캐릭터를 감지하여 캐릭터가 Hole에 들어가면  
싱글톤 패턴으로 만든 `GameManager`의 캐릭터 수를 줄이는 메서드를 호출하고,  
해당 캐릭터 오브젝트를 'Destroy' 처리로 데이터를 관리한다.

3. Raycast 활용  
`RaycastManager`는 홀을 클릭하면 Ray를 발사하여 `HoleManager`의 메서드를 호출하여 `NavMeshAgent`의 이름에 맞는 색상 `string` 를 포함하고 있는지 확인하여 일치하면  
`CharaterManager`의 캐릭터가 레이를 발사하여 경로상 장애물이 없는지 판단하는 메서드를 호출한다.

## 회고
- 게임 영상에서처럼 단체로 움직여 홀에 들어가는게 처음 목표였으나  
어떤 방식으로 구현할지 생각이 나지 않아 캐릭터가 자신의 레이로 판단하여  
맨 앞 캐릭터만 이동하게 되었다.

- 캐릭터 배치와 캐릭터 수를 스크립트로 구현할 방법을 구현하지 못하여서  
캐릭터 오브젝트와 컴포넌트 연결을 직접하게 되었다.