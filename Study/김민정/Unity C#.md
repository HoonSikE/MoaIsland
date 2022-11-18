# Unity C#

> https://www.youtube.com/watch?v=j6XLEqgq-dE&list=PLO-mt5Iu5TeYI4dbYwWP8JqZMC9iuUIW2&index=5

<br>

## 1. 변수

* 변수: 데이터를 메모리에 저장하는 장소
  * int / float / string("" 붙이기) / bool
  * 선언 > 초기화 > 호출(사용)



<br>

## 2. 그룹형 변수

* 배열: 가장 기본적인 고정형 그룹형 변수

* 방법1

  ```c#
  string[] fruits = {"apple", "banana", "pineapple"};
  Debug.Log(fruits[0])	// apple
  ```

* 방법2

  ```c#
  int[] monsterLevel = new int[3];    // 배열의 크기 적어주기
  monsterLevel[0] = 1;
  monsterLevel[1] = 6;
  monsterLevel[2] = 20;
  ```

* 방법3

  * list는 데이터를 넣을 수도 있고 삭제할 수도 있다.
  * 크기를 벗어난 탐색은 오류 발생 (IndexError)

  ```c#
  List<string> items = new List<string>();
  items.Add("생명물약30");
  items.Add("마나물약30");
  
  items.RemoveAt(0);	// 데이터 삭제
  ```



<br>

## 3. 연산자

* level: integer type이므로 1810 / 300 = 6
* strength: float type이므로 6 * 3.1 = 18.6
* %: 몫이 아닌 나머지를 출력

```c#
int exp = 1500;

exp = 1500 + 320;
exp = exp - 10;
level = exp / 300;
strength = level * 3.1f;

Debug.Log("용사의 총 경험치는?");
Debug.Log(exp);         // 1810
Debug.Log("용사의 레벨은?");
Debug.Log(level);       // 6
Debug.Log("용사의 힘은?");
Debug.Log(strength);    // 18.6
```

* &&: and

* ||: or

* [? A : B] : true일 때 A, false일 때 B 출력

  ```c#
  string condition = isBadCondition ? "나쁨" : "좋음";
  ```



<br>

## 4. 키워드

> 프로그래밍 언어를 구성하는 특별한 단어

Ex) List, float, ... 

변수 이름으로 사용할 수 없고, 값으로도 사용할 수 없다.



<br>

## 5. 조건문

* if: 조건이  true일 때 로직 실행

  * 참고: `else if () {}`

  ```c#
  if (condition == "나쁨") {
      Debug.Log("플레이어 상태가 나쁘니 아이템을 사용하세요.");
  }
  else {
      Debug.Log("플레이어 상태가 좋습니다.");
  }
  ```

* switch, case: 변수의 값에 따라 로직 실행

  * defalt: 모든 case를 통과한 후(하나의 케이스도 만족하지 못할 때) 실행

  ```c#
  switch (변수) {
      case 값1:
          break;
      case 값2:
          break;
      case 값3:
          break;
      default:
          break;
  }
  ```

  ```c#
  // case를 같이 쓰면 결과도 동일하게 재사용 가능
  switch () {
      case 값1:
      case 값2:
          break;
      case 값3:
          break;
      default:
          break;
  }
  ```



<br>

## 6. 반복문

> 조건에 만족하면 로직을 반복하는 제어문

* while

  ```c#
  while (조건) {
      실행할 로직
  }
  
  while (health > 0) {
      health--;
      if (health > 0)
          Debug.Log("독 데미지를 입었습니다. " + health);
      else
          Debug.Log("해독제를 사용합니다.");
      if (health == 10) {
          Debug.Log("해독제를 사용합니다.");
          break;
      }
  }
  ```

* for

  ```c#
  for (연산될 변수 ; 조건 ; 연산) {
      로직
  }
  
  for (int count=0; count < 10 ; count++) {
      Debug.Log("붕대로 치료 중... " + health);
  }
  
  for (int index = 0; index < monsters.Length; index++) {
      Debug.Log("이 지역에 있는 몬스터: " + monsters[index]);
  }
  ```

* foreach: for의 그룹형변수 탐색 특화

  ```c#
  foreach (string monster in monsters) {
      Debug.Log("이 지역에 있는 몬스터: " + monster);
  }
  ```



<br>

## 7. 함수 (메소드)

> 기능을 편리하게 사용하도록 구성된 영역

* return: 함수가 값을 반환할 때 사용
* 함수 앞에 반환하는 자료형이 있다면 무조건 return 써야 한다.
* void: 반환 데이터가 없는 함수 타입
* 지역변수: 함수 안에서 선언된 변수 (다른 함수에서는 사용할 수 없다.)
* 전역변수: 함수 바깥에 선언된 변수

```c#
(함수가 반환하는 자료형) 함수형 (함수에게 넣는 변수의 자료형) {
    함수 내용
}
```

```c#
int Heal(int health){
    health += 10;
    Debug.Log("힐을 받았습니다. " + health);
    return health;
}
```

```c#
void Heal() {
    health += 10;
    Debug.Log("힐을 받았습니다. " + health);
}
```



<br>

## 8. 클래스 (Class)

> 하나의 사물(오브젝트)와 대응하는 로직

* script 최상단 위에 있음.

* class: 클래스 선언에 사용

* private: 외부 클래스에 비공개로 설정하는 접근자 (항상 설정되어 있음. 비공개)

* public: 외부 클래스에 공개로 설정하는 접근자

* ```c#
  // Actor.cs 수정
  public class Actor : MonoBehaviour {
      private int id;
      public string name;
      string title;
      
      public string Talk() {
          return "대화를 걸었습니다.";
      }
  }
  ```

* Actor 클래스 만들고, 다른 스크립트(클래스)에서 해당 클래스를 불러올 수 있다.

* 인스턴스: 정의된 클래스를 변수 초기화로 실체화

* ```c#
  // NewBehaviour.cs 생성
  public class NewBehaviour : MonoBehaviour {
      Actor player = new Actor();
      player.name = 'apple';
      player.Talk();
  }
  ```



### 상속

* 자식 클래스

  * Actor 클래스 안에 있던 변수, 함수를 Player 클래스가 그대로 물려받아 사용할 수 있다. (상속)
  * Actor 클래스: 부모 클래스
  * Player 클래스: 자식 클래스

  ```c#
  // NewBehaviour.cs 수정
  public class NewBehaviour : MonoBehaviour {
      Player player = new Player();
      player.name = 'apple';
      player.Talk();
  }
  ```

  ```c#
  // Player.cs 생성
  public class Player : Actor {
      public string move() {
          return "플레이어는 움직입니다.";
      }
  }
  ```

* MonoBehaviour: 유니티 게임 오브젝트 클래스
