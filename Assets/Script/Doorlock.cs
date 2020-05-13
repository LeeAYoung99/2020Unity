using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Doorlock : MonoBehaviour
{
    public GameObject []numberPrefabs = new GameObject[10];//숫자 프리팹들 저장
    public int[] password = new int[4];
    int[] currentNumber = new int[4];
    //x, y 좌표값
    float[] coordX = new float[4];
    float[] coordY = new float[3];
    bool isChanging; //버튼을 눌러서 바뀌고 있는 상태인가?
    bool[,] isFull = new bool[4, 3]; //배열에 물체가 차 있는지 알아보는 함수. Instantiate를 여러번 하는 수고를 하지 않기 위해

    public GameObject[] upButtons = new GameObject[4];
    public GameObject[] downButtons = new GameObject[4];

    bool[] upButtonClicked = new bool[4];
    bool[] downButtonClicked = new bool[4];


    // Start is called before the first frame update
    void Start()
    {
        int[] password = { 1, 2, 3, 4 }; //기본 비밀번호: 1234
        int[] currentNumber = { 0, 0, 0, 0 }; //보여지는 숫자 디폴트 값: 0000
        isChanging = false;

        /*
                            545  859  1205   1542
        903
        612
        330
        */

        coordX[0] = 547.0f;
        coordX[1] = 859.0f;
        coordX[2] = 1205.0f;
        coordX[3] = 1542.0f;

        coordY[0] = 903.5f;
        coordY[1] = 612.0f;
        coordY[2] = 328.0f;

        for(int i=0;i<4;i++)
        {
            for(int j=0;j<3;j++)
            {
                isFull[i,j] = false;
            }
            upButtonClicked[i] = false;
            downButtonClicked[i] = false;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
    
        NumberSetting();
    }

    //밑에는 버튼 함수들!!

    public void top1()
    {
        upButtonClicked[0] = true;
        currentNumber[0]++;
    }
    public void top2()
    {
        upButtonClicked[1] = true;
        currentNumber[1]++;
    }
    public void top3()
    {
        upButtonClicked[2] = true;
        currentNumber[2]++;
    }
    public void top4()
    {
        upButtonClicked[3] = true;
        currentNumber[3]++;
    }

    public void down1()
    {
        downButtonClicked[0] = true;
        currentNumber[0]--;
    }
    public void down2()
    {
        downButtonClicked[1] = true;
        currentNumber[1]--;
    }
    public void down3()
    {
        downButtonClicked[2] = true;
        currentNumber[2]--;
    }
    public void down4()
    {
        downButtonClicked[3] = true;
        currentNumber[3]--;
    }

    //버튼 함수들 종료!!


    void NumberSetting()
    {
        /*
         F I R S T : coordX[0]
         */
        if (isFull[0,0] == false)
        {
            var prefab1=Instantiate(numberPrefabs[UpperSide(currentNumber[0])], 
                        new Vector3(coordX[0], coordY[0], 0.0f), 
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[0,0] = true;
        }
        if (isFull[0,1] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[currentNumber[0]],
                        new Vector3(coordX[0], coordY[1], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[0,1] = true;
        }
        if (isFull[0,2] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[DownSide(currentNumber[0])],
                        new Vector3(coordX[0], coordY[2], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[0,2] = true;
        }

        /*
         S E C O N D : coordX[1]
         */
        if (isFull[1, 0] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[UpperSide(currentNumber[1])],
                        new Vector3(coordX[1], coordY[0], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[1, 0] = true;
        }
        if (isFull[1, 1] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[currentNumber[1]],
                        new Vector3(coordX[1], coordY[1], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[1, 1] = true;
        }
        if (isFull[1, 2] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[DownSide(currentNumber[1])],
                        new Vector3(coordX[1], coordY[2], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[1, 2] = true;
        }

        /*
           T H I R D : coordX[2]
         */
        if (isFull[2, 0] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[UpperSide(currentNumber[2])],
                        new Vector3(coordX[2], coordY[0], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[2, 0] = true;
        }
        if (isFull[2, 1] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[currentNumber[2]],
                        new Vector3(coordX[2], coordY[1], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[2, 1] = true;
        }
        if (isFull[2, 2] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[DownSide(currentNumber[2])],
                        new Vector3(coordX[2], coordY[2], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[2, 2] = true;
        }

        /*
         F O U R T H : coordX[3]
         */
        if (isFull[3, 0] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[UpperSide(currentNumber[3])],
                        new Vector3(coordX[3], coordY[0], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[3, 0] = true;
        }
        if (isFull[3, 1] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[currentNumber[3]],
                        new Vector3(coordX[3], coordY[1], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[3, 1] = true;
        }
        if (isFull[3, 2] == false)
        {
            var prefab1 = Instantiate(numberPrefabs[DownSide(currentNumber[3])],
                        new Vector3(coordX[3], coordY[2], 0.0f),
                        Quaternion.identity);
            prefab1.transform.parent = gameObject.transform;
            isFull[3, 2] = true;
        }


    }


    // Upperside, downside 함수는 0 일때 위에 배치할 숫자, 9일때 아래에 배치할 숫자.


    int UpperSide(int number)
    {
        int result;
        if (number == 0)
        {
            result = 9;
        }
        else
        {
            result = number - 1;
        }
        return result;
    }

    int DownSide(int number)
    {
        int result;
        if (number == 9)
        {
            result = 0;
        }
        else
        {
            result = number + 1;
        }
        return result;
    }
}
