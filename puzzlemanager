using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class puzzleManager : MonoBehaviour
{
    enum MAX
    {
        stage1 = 4,
        stage2 = 4,
        stage3 = 6,
        stage4 = 8
    }

    int[] indexNum = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    int level = 1;
    int score = 0;

    private GameObject[] destinationPiece = new GameObject[10]; //번호받는 조각
    GameObject[] movePiece = new GameObject[10];    //움직이는 조각

    private static puzzleManager instance;
    public static puzzleManager getInstance
    {
        get
        {
            if (instance == null)
                Debug.Log("singleton is null");

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        resetStage(indexNum, (int)MAX.stage1);  //레벨1 초기화
    }

    public void Game()
    {
        switch (level)
        {
            case 1:
                score++;
                if (score == (int)MAX.stage1)
                {
                    panel1.gameObject.SetActive(false);
                    panel2.gameObject.SetActive(true);
                    resetStage(indexNum, (int)MAX.stage2);
                    score = 0;
                    level++;
                }
                break;
            case 2:
                score++;
                if (score == (int)MAX.stage2)
                {
                    panel2.gameObject.SetActive(false);
                    panel3.gameObject.SetActive(true);
                    resetStage(indexNum, (int)MAX.stage3);
                    score = 0;
                    level++;
                }
                break;
            case 3:
                score++;
                if (score == (int)MAX.stage3)
                {
                    panel3.gameObject.SetActive(false);
                    panel4.gameObject.SetActive(true);
                    resetStage(indexNum, (int)MAX.stage4);
                    score = 0;
                    level++;
                }
                break;
            case 4:
                score++;
                break;

        }
    }

    //움직이는 퍼즐선택에 사용 될 번호를 배열로 반환해주는 함수 1~20사이의 수 중 movespritenum의 개수를 반환
    void resetStage(int[] indexNum, int moveSpriteNum)
    {
        List<int> myList = new List<int>(indexNum);
        int num;
        int[] array = new int[moveSpriteNum];

        for (int i = 0; i < moveSpriteNum; i++)
        {
            //랜덤한 인덱스 담아줄 num 처음 0~19까지
            num = Random.Range(0, 20 - i);
            array[i] = myList[num];
            myList.RemoveAt(num);
            //해당 오브젝트 찾아주고 이름을 무브피스와 같게 바꿔줌
            Debug.Log(array[i]);
            destinationPiece[i] = GameObject.Find("Sprite" + array[i]);
            destinationPiece[i].AddComponent<BoxCollider>();
            BoxCollider temp = (BoxCollider)destinationPiece[i].collider;
            temp.size = new Vector3(190, 190, 2);
            destinationPiece[i].name = "SpriteMove" + (i + 1);
            Debug.Log(destinationPiece[i].name);
            //움직이는 조각 찾음 무브피스 찾음
            movePiece[i] = GameObject.Find("SpriteMove" + (i + 1));
            Debug.Log(movePiece[i].name);
            //서로 이미지 바꿔줌
            movePiece[i].GetComponent<UISprite>().spriteName = destinationPiece[i].GetComponent<UISprite>().spriteName;
            destinationPiece[i].GetComponent<UISprite>().spriteName = "puzzle";
        }
    }
}
