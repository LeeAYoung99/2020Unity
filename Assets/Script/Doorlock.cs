using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Doorlock : MonoBehaviour
{
    public GameObject[] firstNumberObjects = new GameObject[10];//숫자 프리팹들 저장
    public GameObject[] secondNumberObjects = new GameObject[10];//숫자 프리팹들 저장
    public GameObject[] thirdNumberObjects = new GameObject[10];//숫자 프리팹들 저장
    public GameObject[] fourthNumberObjects = new GameObject[10];//숫자 프리팹들 저장
    int[] password = new int[4];
    int[] beforeNumber = new int[4]; // 변화 감지용.
    int[] currentNumber = new int[4];
    //x, y 좌표값
    float[] coordX = new float[4];
    float[] coordY = new float[3];


    bool[] upButtonClicked = new bool[4];
    bool[] downButtonClicked = new bool[4];

    public float speed = 0.2f;
    bool animating;

    void Awake()
    {
        //비밀번호!
        password[0] = 0;
        password[1] = 5;
        password[2] = 1;
        password[3] = 2;

        //초기화
        int[] currentNumber = { 0, 0, 0, 0 }; //보여지는 숫자 디폴트 값: 0000
        int[] beforeNumber = { 0, 0, 0, 0 }; //위와 동일하게 초기화

        animating = false;


        coordX[0] = -1335.26f;
        coordX[1] = -1335.26f;
        coordX[2] = -1335.26f;
        coordX[3] = -1335.26f;


        coordY[0] = 416.0f;
        coordY[1] = 106.0f;
        coordY[2] = -200.0f;
    }

    // Start is called before the first frame update
    void Start()
    {

        InitNumberLocation();

    }

    // Update is called once per frame
    void Update()
    {
        NumberLocation();

    }

    //밑에는 버튼 함수들!!

    public void top1()
    {
        if(!animating)
        {
            upButtonClicked[0] = true;
            currentNumber[0] = UpperSide(currentNumber[0]);
        }
        
    }
    public void top2()
    {
        if (!animating)
        {
            upButtonClicked[1] = true;
            currentNumber[1] = UpperSide(currentNumber[1]);
        }
            
    }
    public void top3()
    {
        if (!animating)
        {
            upButtonClicked[2] = true;
            currentNumber[2] = UpperSide(currentNumber[2]);
        }

    }
    public void top4()
    {
        if (!animating)
        {
            upButtonClicked[3] = true;
            currentNumber[3] = UpperSide(currentNumber[3]);
        }
            
    }

    public void down1()
    {
        if (!animating)
        {
            downButtonClicked[0] = true;
            currentNumber[0] = DownSide(currentNumber[0]);
        }
     
    }
    public void down2()
    {
        if (!animating)
        {
            downButtonClicked[1] = true;
            currentNumber[1] = DownSide(currentNumber[1]);
        }
            
    }
    public void down3()
    {
        if (!animating)
        {
            downButtonClicked[2] = true;
            currentNumber[2] = DownSide(currentNumber[2]);
        }
            
    }
    public void down4()
    {
        if (!animating)
        {
            downButtonClicked[3] = true;
            currentNumber[3] = DownSide(currentNumber[3]);
        }
            
    }

    //버튼 함수들 종료!!

    void InitNumberLocation()
    {
        firstNumberObjects[currentNumber[0]].transform.localPosition = new Vector3(coordX[0], coordY[1], 0.0f);
        secondNumberObjects[currentNumber[1]].transform.localPosition = new Vector3(coordX[1], coordY[1], 0.0f);
        thirdNumberObjects[currentNumber[2]].transform.localPosition = new Vector3(coordX[2], coordY[1], 0.0f);
        fourthNumberObjects[currentNumber[3]].transform.localPosition = new Vector3(coordX[3], coordY[1], 0.0f);
    }

    void NumberLocation()
    {
       
        if(currentNumber[0]!=beforeNumber[0])
        {
            
            animating = true;

            /*
            animating = false;
            beforeNumber[0] = currentNumber[0];
            return;
            */


           
            if (currentNumber[0]==DownSide(beforeNumber[0]))//숫자가 올라갔으면 애들 올려
            {
               

                firstNumberObjects[beforeNumber[0]].transform.localPosition = new Vector3(coordX[0], coordY[1], 0.0f);
                firstNumberObjects[DownSide(beforeNumber[0])].transform.localPosition = new Vector3(coordX[0], coordY[2], 0.0f);

                
              // if (firstNumberObjects[beforeNumber[0]].transform.localPosition.y<=coordY[0])
              // {
                    //애니메이션 대체
                    firstNumberObjects[beforeNumber[0]].transform.localPosition = new Vector3(coordX[0], coordY[0], 0.0f);
                    firstNumberObjects[DownSide(beforeNumber[0])].transform.localPosition = new Vector3(coordX[0], coordY[1], 0.0f);
                   // firstNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, speed*Time.deltaTime, 0.0f));
                   // firstNumberObjects[DownSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
                   // return;

               //}
                 


            }
            else
            {

                firstNumberObjects[beforeNumber[0]].transform.localPosition = new Vector3(coordX[0], coordY[1], 0.0f);
                firstNumberObjects[UpperSide(beforeNumber[0])].transform.localPosition = new Vector3(coordX[0], coordY[0], 0.0f);
                
               //if (firstNumberObjects[beforeNumber[0]].transform.localPosition.y >= coordY[2])
               //{
                    firstNumberObjects[beforeNumber[0]].transform.localPosition = new Vector3(coordX[0], coordY[2], 0.0f);
                    firstNumberObjects[UpperSide(beforeNumber[0])].transform.localPosition = new Vector3(coordX[0], coordY[1], 0.0f);

                   // firstNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                   // firstNumberObjects[UpperSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                   // return;
                

              // }


            }
            animating = false;


            beforeNumber[0] = currentNumber[0];

        }

        /*
        만약에 현재 숫자랑 이전 숫자가 다르면(자리별로 검사)
          애니메이션=true
          이전숫자-1, 이전숫자, 이전숫자+1 프리팹들을 묶어서 배치한후 transform을 함
          -> 만약에 currentnum>beforenum 이면 애들을 올림 그 반대면 내림
          애니메이션=false
          숫자 바꾸기(현재숫자로) 나머지 기본자리로 원위치*********
          이전숫자=현재숫자로 다시 대입
       */
        if (currentNumber[1] != beforeNumber[1])
        {
            
            animating = true;

            /*
            animating = false;
            beforeNumber[0] = currentNumber[0];
            return;
            */



            if (currentNumber[1] == DownSide(beforeNumber[1]))//숫자가 올라갔으면 애들 올려
            {


                secondNumberObjects[beforeNumber[1]].transform.localPosition = new Vector3(coordX[1], coordY[1], 0.0f);
                secondNumberObjects[DownSide(beforeNumber[1])].transform.localPosition = new Vector3(coordX[1], coordY[2], 0.0f);


                // if (secondNumberObjects[beforeNumber[0]].transform.localPosition.y<=coordY[0])
                // {
                //애니메이션 대체
                secondNumberObjects[beforeNumber[1]].transform.localPosition = new Vector3(coordX[1], coordY[0], 0.0f);
                secondNumberObjects[DownSide(beforeNumber[1])].transform.localPosition = new Vector3(coordX[1], coordY[1], 0.0f);
                // secondNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, speed*Time.deltaTime, 0.0f));
                // secondNumberObjects[DownSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
                // return;

                //}



            }
            else
            {

                secondNumberObjects[beforeNumber[1]].transform.localPosition = new Vector3(coordX[1], coordY[1], 0.0f);
                secondNumberObjects[UpperSide(beforeNumber[1])].transform.localPosition = new Vector3(coordX[1], coordY[0], 0.0f);

                //if (secondNumberObjects[beforeNumber[0]].transform.localPosition.y >= coordY[2])
                //{
                secondNumberObjects[beforeNumber[1]].transform.localPosition = new Vector3(coordX[1], coordY[2], 0.0f);
                secondNumberObjects[UpperSide(beforeNumber[1])].transform.localPosition = new Vector3(coordX[1], coordY[1], 0.0f);

                // secondNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // secondNumberObjects[UpperSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // return;


                // }


            }
            animating = false;


            beforeNumber[1] = currentNumber[1];

        }

        if (currentNumber[2] != beforeNumber[2])
        {

            animating = true;

            /*
            animating = false;
            beforeNumber[0] = currentNumber[0];
            return;
            */



            if (currentNumber[2] == DownSide(beforeNumber[2]))//숫자가 올라갔으면 애들 올려
            {


                thirdNumberObjects[beforeNumber[2]].transform.localPosition = new Vector3(coordX[2], coordY[1], 0.0f);
                thirdNumberObjects[DownSide(beforeNumber[2])].transform.localPosition = new Vector3(coordX[2], coordY[2], 0.0f);


                // if (thirdNumberObjects[beforeNumber[0]].transform.localPosition.y<=coordY[0])
                // {
                //애니메이션 대체
                thirdNumberObjects[beforeNumber[2]].transform.localPosition = new Vector3(coordX[2], coordY[0], 0.0f);
                thirdNumberObjects[DownSide(beforeNumber[2])].transform.localPosition = new Vector3(coordX[2], coordY[1], 0.0f);
                // thirdNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, speed*Time.deltaTime, 0.0f));
                // thirdNumberObjects[DownSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
                // return;

                //}



            }
            else
            {

                thirdNumberObjects[beforeNumber[2]].transform.localPosition = new Vector3(coordX[2], coordY[1], 0.0f);
                thirdNumberObjects[UpperSide(beforeNumber[2])].transform.localPosition = new Vector3(coordX[2], coordY[0], 0.0f);

                //if (thirdNumberObjects[beforeNumber[0]].transform.localPosition.y >= coordY[2])
                //{
                thirdNumberObjects[beforeNumber[2]].transform.localPosition = new Vector3(coordX[2], coordY[2], 0.0f);
                thirdNumberObjects[UpperSide(beforeNumber[2])].transform.localPosition = new Vector3(coordX[2], coordY[1], 0.0f);

                // thirdNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // thirdNumberObjects[UpperSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // return;


                // }


            }
            animating = false;


            beforeNumber[2] = currentNumber[2];

        }

        if (currentNumber[3] != beforeNumber[3])
        {

            animating = true;

            /*
            animating = false;
            beforeNumber[0] = currentNumber[0];
            return;
            */



            if (currentNumber[3] == DownSide(beforeNumber[3]))//숫자가 올라갔으면 애들 올려
            {


                fourthNumberObjects[beforeNumber[3]].transform.localPosition = new Vector3(coordX[3], coordY[1], 0.0f);
                fourthNumberObjects[DownSide(beforeNumber[3])].transform.localPosition = new Vector3(coordX[3], coordY[2], 0.0f);


                // if (fourthNumberObjects[beforeNumber[0]].transform.localPosition.y<=coordY[0])
                // {
                //애니메이션 대체
                fourthNumberObjects[beforeNumber[3]].transform.localPosition = new Vector3(coordX[3], coordY[0], 0.0f);
                fourthNumberObjects[DownSide(beforeNumber[3])].transform.localPosition = new Vector3(coordX[3], coordY[1], 0.0f);
                // fourthNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, speed*Time.deltaTime, 0.0f));
                // fourthNumberObjects[DownSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, speed * Time.deltaTime, 0.0f));
                // return;

                //}




            }
            else
            {

                fourthNumberObjects[beforeNumber[3]].transform.localPosition = new Vector3(coordX[3], coordY[1], 0.0f);
                fourthNumberObjects[UpperSide(beforeNumber[3])].transform.localPosition = new Vector3(coordX[3], coordY[0], 0.0f);

                //if (fourthNumberObjects[beforeNumber[0]].transform.localPosition.y >= coordY[2])
                //{
                fourthNumberObjects[beforeNumber[3]].transform.localPosition = new Vector3(coordX[3], coordY[2], 0.0f);
                fourthNumberObjects[UpperSide(beforeNumber[3])].transform.localPosition = new Vector3(coordX[3], coordY[1], 0.0f);

                // fourthNumberObjects[beforeNumber[0]].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // fourthNumberObjects[UpperSide(beforeNumber[0])].transform.Translate(new Vector3(0.0f, -speed * Time.deltaTime, 0.0f));
                // return;


                // }


            }
            animating = false;


            beforeNumber[3] = currentNumber[3];

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

    bool CheckPassword()
    {
        bool result = true;
        for(int i=0;i<4;i++)
        {
            if(password[i]!=currentNumber[i])
            {
                result = false;
                break;
            }
        }
        return result;
    }

    public void ApplyButton()
    {
        if(CheckPassword())
        {
            ClickManager.Unlocked = 1;
            SceneManager.LoadScene("SciFi_Industrial_SampleLayout");
            //
        }
    }
}
