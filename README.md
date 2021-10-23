# 플래피 버드 만들기

## 참고 사이트
- https://www.youtube.com/watch?v=vbQH9T-F5ac&t=1292s
- https://animalface.site/flappy

## 설치 방법
- 우선 unityhub부터 설치 - 설정에서 라이센스 부여받기 - 뒤로 가서 설치해서 3.20lts(long time support) 선택 후 설치 - 설치 시 옵션은 에디터는 생략하고 android build support 선택 - 프로젝트 생성 - 2d 선택, 폴더 지정

## 그림 쪼개기
- 오른쪽 inspector - sprite mode multiple - sprite editor에서 slice slice클릭 - 나눠진거 확인

## 카메라 비율 맞추기
- 배경 그림을 드래그한다. -> position을 0,0,0으로 설정
- game 창에서 화면 비율 9:16 설정

## 새 애니메이션 만들기
- 새 이미지 추가->order를 통해 순서 지정가능
- window-animation창을 추가함
- create->birdfly생성
- 타임라인에 asset의 이미지들을 드래그한다. 
- asset의 간격 조절, 파닥거리는 것을 자연스럽게 만들어줘야한다. 


# 땅 추가하기
draw mode->titled해서 확장시키기
animation생성, 이미지 드래그(아마)
0초,시작 위치에서 녹화 시작완료-> 끝초,끝 위치에서 녹화시작완료 ->속도 스무스하게 하기 위해 우클릭 both tangents를 리니어로 설정

# 새의 중력 추가하기
새 오브젝트 -> rigidbody 2d -> capsul collider 어쩌구 추가한다음 horizontal, vertical 설정
땅 오브젝트-> box collider 추가, auto tiling

# VSCode 익스텐션 설치하기 
C#
debugger for unity
unity tools
unity code snippets

## Script 개론

### 변수선언
- public->ui에 나타나서 설정가능해진다.
- static: 다른 script에서도 자유롭게 변경 가능해진다. (예시. Score.cs에 있는 score변수의 경우, Score.score로 접근 가능해진다.)
- `public GameObject pipe`; //prefab을 선언한다. ui에서 지정하면 생성된다. 
- `float timer`
- `public float speed` 등...

### 메인함수
1. ``Start()`` 함수
첨 시작할때 1회 실행  

2. `Update()` 함수
매 프레임마다 실행  

3.  `private void OnTriggerEnter2D(Collider2D other)`
해당 물체가 통과 당했을 때, on trigger 설정의 box collider2d 오브젝트에 통과하면 실행  

 
4. `private void OnCollisionEnter2D(Collision2D other)`
해당 오브젝트와 충돌했을 때 실행

5. 커스텀함수
OnClick()등을 통해 실행시킬 수 있음

### 물체의 위치
1. 해당 오브젝트의 위치 지정: `transform.position` = `Vector3.left`
2. 1단위를 나타내는 벡터: `Vector3.left,Vector3.right,Vector3.up,Vector3.down`
3. 특정 오브젝트의 위치 지정: `newobject.transform.position = Vector3.left`

### 물체의 조작 -> 물체의 속도 변경
1. 마우스 입력 상태: `Input.GetMouseButtonDown(0)`이 True이다.
2. 물체 조작시 활용하는 오브젝트: `Rigidbody2D rb=GetComponent<Rigidbody2D>();` script가 존재하는 component를 불러온다.
3. 속도를 조작하는 코드: `rb.velocity = Vector2.up*3` 

### 물체의 시간
1. `Time.deltaTime`: 매 프레임당 소요되는 시간을 의미함. 
2. `transform.position+=Time.deltaTime * Vector.left` : 이렇게하면 1초당 1단위씩 포지션이 바뀌게 된다. 

### 물체의 생성, 파괴
1. `GameObject objectname = Instantiate(prefabname);`
2. `Destroy(objectname,5.0f)`

### 컴포넌트의 속성 불러오기, 변경하기
1. `GetComponent<componentname>()` : 오브젝트의 component를 가져올 수 있다. 
2. `GetComponent<componentname>().valuename`: 오브젝트의 component내 변수를 접근할 수 있다.
3. 예시 `GetComponent<Text>().text = "Hello World"`: 오브젝트의 Text라는 component 안의 Text라는 변수를 "Hello World"로 변경

### 씬 전환하기
```
using UnityEngine.SceneManager;
OnCollisionEnter2D(Collision2D other){
  SceneManager.LoadScene("GameOverScene");
}
```


## Prefab 반복 생성하기 (파이프)
1. UI상에서 파이프를 생성한 뒤 폴더에 드래그하면 prefab으로 생성할 수 있다.
2. Generator 오브젝트를 새로 만들어야 한다. empty를 생성하고 new script를 만든다.  
3. 코드상에서 파이프를 반복 생성할 수 있다. `GameObject newpipe = Instantiate(prefabname);`
4. 파이프의 위치 초기화 `newpipe.transform.position = new Vector3(0, Random.Range(-3f, 2f), 0);`
5. 파이프의 위치 움직이기(이건 pipe prefab 내부의 script로 별개로 만든다.) `transform.position += Vector3.left *speed* Time.deltaTime;`
6. 파이프 파괴하기 `Destroy(변수명,5.0f)` 5초 후에 오브젝트를 없애서 메모리 관리를 한다. 

## 점수표 추가하기 
1. Canvas를 생성한다.
2. Canvas 밑에 Text를 생성한다. 
3. Text에서 Anchor를 조절하여 점수표의 위치를 지정할 수 있다. Anchor는 최초에는 정 중앙에 고정이다. Max, Min이 모두 0.5로 설정되어 있다. 
4. Anchor Min x, Min y는 좌측 최하단을 설정, Anchor Max x, Max y는 우측 최상단을 설정.
5. Transform에서 Anchor 내부의 위치를 재설정한다. Anchor가 제대로 설정되어있다면 Transform은 0으로 세팅하면 된다.
6. 글자 크기를 조정할 필요가 있다. 
7. Text 내부에 Score.cs 스크립트를 추가한다. 
```
    public static int score = 0; //static: 
    public static int bestscore = 0; 

    // 점수는 신이 시작할 때마다 0으로 리셋된다. 
    void Start()
    {
        score=0;
    }

    // 텍스트 컴포넌트를 가져와서 그 내용을 설정할 수 있다. 
    void Update()
    {
        GetComponent<Text>().text=score.ToString();
    }
```

## 물체를 통과했을 때 점수를 올리는 법
1. pipe 아래에 빈 거를 추가(Scoreup)
2. add component에서 Box collider 2d를 추가한다음
3. Is Trigger 체크하면 통과할 수 있게 된다. 
4. ScoreUp Script를 만들어서
```
private void OnTriggerEnter2D(Collider2D other)
    {
        Score.score+=1;   
    }
```
5. Score라는 script가 이미 존재하고 그 안의 score 변수는 static으로 선언되어있기 때문에 접근해서 변동시키는 것이 가능하다. 

## 게임 오버 구현하기
1. 새로운 Scene을 만든다.
2. Canvas를 생성한다.
3. Canvas 아래에 Panel을 생성한다. 
4. Panel아래에 Image, Text, Button을 만든다. 
5. Panel의 Anchor는 전체를 설정 min 0,0 max 1,1
6. Image, Text, Button은 적절한 위치에 Anchor를 설정한다. 
7. Image의 경우, Source Image에 이미지를 드래그 해온다. Preserve Aspect하면 비율이 유지된다.
8. Button 역시 Source Image에 이미지를 드래그 해온다. 
9. 원래의 Scene으로 돌아가서 새 script에 함수를 추가해야한다. 
```
using UnityEngine.SceneManager;
OnCollisionEnter2D(Collision2D other){
  SceneManager.LoadScene("GameOverScene");
}
```
10. `SceneManager.LoadScene(scenename)`을 통해 다른 신을 로드할 수 있다.
11. build settings에 여러 scene을 추가해둔다. 

## 버튼 구현하기
1. 게임 오버 신으로 가서 empty object "Replay"를 만든다음 script를 추가한다.
2. Script 안에 순수한 커스텀 함수를 추가할 수 있다. 
```
public void ReplayGame(){

    SceneManager.LoadScene("PlayScene");
}
```
3. 버튼 내의 component 중 button에 OnClick()이 있는데 이곳에 Replay오브젝트를 끌어온다.

## 스코어 표시하기
1. 현재 플레이 신의 ScoreCanvas/Text에 Score.cs가 있으며, 여기서 Score.score를 선언하고, 지속적으로 리셋하며, 플레이신에서 표시하는 텍스트를 GetComponent를 통해 설정하고 있다. 
2. 그리고 Box collider로 설정된 pipe/ScoreUp에 있는 ScoreUp.cs에서 OnTriggerEnter2D를 통해 Score.score 수치를 올려주고 있다.  
3. 게임오버 신의 스코어에 CurrentScore.cs 스크립트를 추가해서 오버 신에서 스코어를 표시하게 한다. 
```
void Start()
    {
        GetComponent<Text>().text="Score: "+Score.score.ToString();
    }
```

## 효과음
1. 참고 사이트: soundeffect-lab.info
2. 확장자 변경 .m4a: m4a to wav 검색하면됨. 
3. Bird에서 Audio Source라는 컴포넌트를 추가. 
4. Play On Awake해제 후 
5. 음성파일을을 오디오 소스에 드래그
6. GetComponent<AudioSource>().Play();를 하면 됨.(재생)

## 텍스트 크기 설정
1. Canvas에서 Canvas Scaler > Scale With Screen Size > 1440,3040
2. Text에서 Best Fit > 50,170






