using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //赤いドア
    [SerializeField] GameObject redDoor;
    [SerializeField] GameObject redblueDoor;
    [SerializeField] GameObject redgreenDoor;
    [SerializeField] GameObject redyellowDoor;
    //青いドア
    [SerializeField] GameObject blueDoor;
    [SerializeField] GameObject blueredDoor;
    [SerializeField] GameObject bluegreenDoor;
    [SerializeField] GameObject blueyelloeDoor;
    //緑ドア
    [SerializeField] GameObject greenDoor;
    [SerializeField] GameObject greenredDoor;
    [SerializeField] GameObject greenblueDoor;
    [SerializeField] GameObject greenyellowDoor;
    //黄色い鍵
    [SerializeField] GameObject yellowDoor;
    [SerializeField] GameObject yellowredDoor;
    [SerializeField] GameObject yellowblueDoor;
    [SerializeField] GameObject yellowgreenDoor;

    //赤い鍵
    [SerializeField] GameObject redKey;
    [SerializeField] GameObject redblueKey;
    [SerializeField] GameObject redgreenKey;
    [SerializeField] GameObject redyellowKey;
    //青い鍵
    [SerializeField] GameObject blueKey;
    [SerializeField] GameObject blueredKey;
    [SerializeField] GameObject bluegreenKey;
    [SerializeField] GameObject blueyellowKey;
    //緑鍵
    [SerializeField] GameObject greenKey;
    [SerializeField] GameObject greenredKey;
    [SerializeField] GameObject greenblueKey;
    [SerializeField] GameObject greenyellowKey;
    //黄色い鍵
    [SerializeField] GameObject yellowKey;
    [SerializeField] GameObject yellowredKey;
    [SerializeField] GameObject yellowblueKey;
    [SerializeField] GameObject yellowgreenKey;

    
    //どのドアを使うか
    private int door1;
    private int door2;
    private int door3;
    //どのカギを使うか
    private int key;

    int rightDoor;
    public Vector3 initialDoor1Pos;
    public Vector3 initialDoor2Pos;
    public Vector3 initialKeyPos;
    public Vector3 initial;
    float ExcludeDoorPos;

    //三枚ようの座標
    public Vector3 Door1Pos3;
    public Vector3 Door2Pos3;
    public Vector3 Door3Pos3;


    //ドアの枚数　false=2枚　true=3枚　
    public bool Mode;

    //ドアの位置を変数に格納
    Vector3 red;
    Vector3 redblue;
    Vector3 redgreen;
    Vector3 redyellow;

    Vector3 blue;
    Vector3 bluered;
    Vector3 bluegreen;
    Vector3 blueyellow;

    Vector3 green;
    Vector3 greenred;
    Vector3 greenblue;
    Vector3 greenyellow;
        
    Vector3 yellow;
    Vector3 yellowred;
    Vector3 yellowblue;
    Vector3 yellowgreen;

    //鍵の位置を変数に格納
    Vector3 redKeyPos;
    Vector3 redblueKeyPos;
    Vector3 redgreenKeyPos;
    Vector3 redyellowKeyPos;

    Vector3 blueKeyPos;
    Vector3 blueredKeyPos;
    Vector3 bluegreenKeyPos;
    Vector3 blueyellowKeyPos;

    Vector3 greenKeyPos;
    Vector3 greenredKeyPos;
    Vector3 greenblueKeyPos;
    Vector3 greenyellowKeyPos;

    Vector3 yellowKeyPos;
    Vector3 yellowredKeyPos;
    Vector3 yellowblueKeyPos;
    Vector3 yellowgreenKeyPos;

  

    // Start is called before the first frame update
    void Start()
    {
        red = redDoor.transform.position;
        redblue = redblueDoor.transform.position;
        redgreen = redgreenDoor.transform.position;
        redyellow = redyellowDoor.transform.position;

        blue = blueDoor.transform.position;
        bluered = blueredDoor.transform.position;
        bluegreen = bluegreenDoor.transform.position;
        blueyellow = blueyelloeDoor.transform.position;

        green = greenDoor.transform.position;
        greenred = greenredDoor.transform.position;
        greenblue = greenblueDoor.transform.position;
        greenyellow = greenyellowDoor.transform.position;

        yellow = yellowDoor.transform.position;
        yellowred = yellowredDoor.transform.position;
        yellowblue = yellowblueDoor.transform.position;
        yellowgreen = yellowgreenDoor.transform.position;

        redKeyPos = redKey.transform.position;
        redblueKeyPos = redblueKey.transform.position;

        redgreenKeyPos = redgreenKey.transform.position;
        redyellowKeyPos = redyellowKey.transform.position;


        blueKeyPos = blueKey.transform.position;
        blueredKeyPos = blueredKey.transform.position;
        bluegreenKeyPos = bluegreenKey.transform.position;
        blueyellowKeyPos = blueyellowKey.transform.position;

        greenKeyPos = greenKey.transform.position;
        greenredKeyPos = greenredKey.transform.position;
        greenblueKeyPos = greenblueKey.transform.position;
        greenyellowKeyPos = greenyellowKey.transform.position;

        yellowKeyPos = yellowKey.transform.position;
        yellowredKeyPos = yellowredKey.transform.position;
        yellowblueKeyPos = yellowblueKey.transform.position;
        yellowgreenKeyPos = yellowgreenKey.transform.position;



        //画面外のドアの位置
        //ExcludeDoorPos = 10;

        //ドアの位置を三枚用に置き換える（動的に変更したいならUpdate)
        if (Mode == true)
        {
            initialDoor1Pos = Door1Pos3;
            initialDoor2Pos = Door2Pos3;
            //三枚目の変数=Door3Pos3 
        }
        DeployObj();
    }


    // Update is called once per frame
    void Update()
    {

        //テスト起動用　いらない
        if (Input.GetMouseButtonDown(0))
        {

           
          // DeployObj();

                // Debug.Log("door1");
                // Debug.Log("door2");
               
            
        }
        if(Input.GetMouseButton(1))
        {
            initializedDoor();
        }

       
    }

    public void random()
    {
        door1 = Random.Range(0, 9);
        door2 = Random.Range(0, 9);
        if (door1 == door2)
        {
            random();
        }
        else
        {
            rightDoor = Random.Range(0, 2);
            switch (rightDoor)
            {
                case 0:
                    key = door1;
                    break;
                case 1:
                    key = door2;
                    break;

            }
        }


    }

    //三枚用ランダム関数
    public void random3()
    {
        door1 = Random.Range(0, 16);
        door2 = Random.Range(0, 16);
        door3 = Random.Range(0, 16);
        if (door1 == door2)
        {
            random3();
        }
        else if (door1 == door3)
        {
            random3();
        }
        else if(door2 == door3)
        {
            random3();
        }
        else
        {
            rightDoor = Random.Range(0, 3);
            switch (rightDoor)
            {
                case 0:
                    key = door1;
                    break;
                case 1:
                    key = door2;
                    break;
                case 2:
                    key = door3;
                    break;

            }

            
        }


    }

    public void initializedDoor()
    {
        //画面外へドアを移動させる関数

        red = redblue = redgreen = redyellow = blue = bluered = bluegreen = blueyellow = green = greenred = greenblue = greenyellow = yellow = yellowred = yellowblue = yellowgreen = initial;
        redDoor.transform.position = red;
        redblueDoor.transform.position = redblue;
        redgreenDoor.transform.position = redgreen;
        redyellowDoor.transform.position = redyellow;

        blueDoor.transform.position = blue;
        blueredDoor.transform.position = bluered;
        bluegreenDoor.transform.position = bluegreen;
        blueyelloeDoor.transform.position = blueyellow;

        greenDoor.transform.position = green;
        greenredDoor.transform.position = greenred;
        greenblueDoor.transform.position = greenblue;
        greenyellowDoor.transform.position = greenyellow;

        yellowDoor.transform.position = yellow;
        yellowredDoor.transform.position = yellowred;
        yellowblueDoor.transform.position = yellowblue;
        yellowgreenDoor.transform.position = yellowgreen;

        //黄色追加済
        
        
    }
    
    public void initializedKey()
    {
        redKeyPos = redblueKeyPos = redgreenKeyPos = redyellowKeyPos = blueKeyPos = blueredKeyPos = bluegreenKeyPos = blueyellowKeyPos = greenKeyPos = greenredKeyPos = greenblueKeyPos = greenyellowKeyPos = yellowKeyPos = yellowredKeyPos = yellowblueKeyPos = yellowgreenKeyPos = initial;//要作業　他の鍵もすべて記入する　済
        redKey.transform.position = redKeyPos;
        redblueKey.transform.position = redblueKeyPos;
        redgreenKey.transform.position = redgreenKeyPos; 
        redyellowKey.transform.position = redyellowKeyPos;

        blueKey.transform.position = blueKeyPos;
        blueredKey.transform.position = blueredKeyPos;
        bluegreenKey.transform.position = bluegreenKeyPos;
        blueyellowKey.transform.position = blueyellowKeyPos;

        greenKey.transform.position = greenKeyPos;
        greenredKey.transform.position = greenredKeyPos;
        greenblueKey.transform.position = greenblueKeyPos;
        greenyellowKey.transform.position = greenyellowKeyPos;

        yellowKey.transform.position = yellowKeyPos;
        yellowredKey.transform.position = yellowredKeyPos;
        yellowblueKey.transform.position = yellowblueKeyPos;
        yellowgreenKey.transform.position = yellowgreenKeyPos;
        //要作業　ほかの鍵もすべて記入する　（上の関数を参考に）済
    }
    

    public void DeployObj()
    {
        if (Mode == true)
        {
            random3();
        }
        else
        {
            random();
        }
       


        //RightDoor
        switch (door1)
        {
            case 0:
              red = initialDoor1Pos;
                redDoor.transform.position = red;
                break;
            case 1:
                redblue = initialDoor1Pos;
                redblueDoor.transform.position = redblue;
                break;
            case 2:
                redgreen = initialDoor1Pos;
                redgreenDoor.transform.position = redgreen;
                break;
            case 3:
               blue = initialDoor1Pos;
                blueDoor.transform.position = blue;
                break;
            case 4:
                bluered = initialDoor1Pos;
                blueredDoor.transform.position = bluered;
                break;
            case 5:
                bluegreen = initialDoor1Pos;
                bluegreenDoor.transform.position = bluegreen;
                break;
            case 6:
                green=initialDoor1Pos;
                greenDoor.transform.position = green;
                break;
            case 7:
                greenred = initialDoor1Pos;
                greenredDoor.transform.position = greenred;
                break;
            case 8:
                greenblue = initialDoor1Pos;
                greenblueDoor.transform.position = greenblue;
                break;

            //ドア三つ
            case 9:
                redyellow = initialDoor1Pos;
                break;
            case 10:
                blueyellow = initialDoor1Pos;
                break;
            case 11:
                greenyellow = initialDoor1Pos;
                break;
            case 12:
                yellow = initialDoor1Pos;
                break;
            case 13:
                yellowred = initialDoor1Pos;
                break;
            case 14:
                yellowblue = initialDoor1Pos;
                break;     
            default:
                yellowgreen = initialDoor1Pos;
                yellowgreenDoor.transform.position = yellowgreen;
                break;
        }

        //LeftDoor
        switch (door2)

        { 
            case 0:
            red = initialDoor2Pos;
                redDoor.transform.position = red;
            break;
        case 1:
            redblue = initialDoor2Pos;
                redblueDoor.transform.position = redblue;
            break;
        case 2:
            redgreen = initialDoor2Pos;
                redgreenDoor.transform.position = redgreen;
            break;
        case 3:
            blue = initialDoor2Pos;
                blueDoor.transform.position = blue;
            break;
        case 4:
            bluered = initialDoor2Pos;
                blueredDoor.transform.position = bluered;
            break;
        case 5:
            bluegreen = initialDoor2Pos;
                bluegreenDoor.transform.position = bluegreen;
            break;
        case 6:
            green = initialDoor2Pos;
                greenDoor.transform.position = green;
            break;
        case 7:
            greenred = initialDoor2Pos;
                greenredDoor.transform.position = greenred;
            break;
        case 8:
                greenblue = initialDoor2Pos;
                greenblueDoor.transform.position = greenblue;
            break;
        //ドア３つ
        case 9:
                redyellow = initialDoor2Pos;
                break;
        case 10:
                blueyellow = initialDoor2Pos;
                break;
        case 11:
                greenyellow = initialDoor2Pos;
                break;
        case 12:
                yellow = initialDoor2Pos;
                break;
        case 13:
                yellowred = initialDoor2Pos;
                break;
        case 14:
                yellowblue = initialDoor2Pos;
                break;
        default:
                yellowgreen = initialDoor2Pos;
                break;
                
        }

        //三枚目
        //要作業　door2→door3 initialDoor2Pos→Door3Pos3　に書き換える　済
        if (Mode == true)
        {
            switch (door3)

            {
                case 0:
                    red = Door3Pos3;
                    redDoor.transform.position = red;
                    break;
                case 1:
                    redblue = Door3Pos3;
                    redblueDoor.transform.position = redblue;
                    break;
                case 2:
                    redgreen = Door3Pos3;
                    redgreenDoor.transform.position = redgreen;
                    break;
                case 3:
                    blue = Door3Pos3;
                    blueDoor.transform.position = blue;
                    break;
                case 4:
                    bluered = Door3Pos3;
                    blueredDoor.transform.position = bluered;
                    break;
                case 5:
                    bluegreen = Door3Pos3;
                    bluegreenDoor.transform.position = bluegreen;
                    break;
                case 6:
                    green = Door3Pos3;
                    greenDoor.transform.position = green;
                    break;
                case 7:
                    greenred = Door3Pos3;
                    greenredDoor.transform.position = greenred;
                    break;
                case 8:
                    greenblue = Door3Pos3; 
                    greenblueDoor.transform.position = greenblue;
                    break;
                //ドア３つ
                case 9:
                    redyellow = Door3Pos3;
                    break;
                case 10:
                    blueyellow = Door3Pos3;
                    break;
                case 11:
                    greenyellow = Door3Pos3;
                    break;
                case 12:
                    yellow = Door3Pos3;
                    break;
                case 13:
                    yellowred = Door3Pos3;
                    break;
                case 14:
                    yellowblue = Door3Pos3;
                    break;
                default:
                    yellowgreen = Door3Pos3;
                    break;

            }
        }

        //Key
        //要作業　(色)key.transform.position=(色)keyPos　と記述する。下を参考に
        switch (key)
        {
            case 0:
                redKeyPos = initialKeyPos;
                redKey.transform.position = redKeyPos;//これと
                break;
            case 1:
                redblueKeyPos = initialKeyPos;
                redblueKey.transform.position = redblueKeyPos;//これを参考に下のも記述する 済
                break;
            case 2:
                redgreenKeyPos = initialKeyPos;
                redgreenKey.transform.position = redgreenKeyPos;
                break;
            case 3:
                blueKeyPos = initialKeyPos;
                blueKey.transform.position = blueKeyPos;
                break;
            case 4:
                blueredKeyPos = initialKeyPos;
                blueredKey.transform.position = blueredKeyPos;
                break;
            case 5:
                bluegreenKeyPos = initialKeyPos;
                bluegreenKey.transform.position = bluegreenKeyPos;
                break;
            case 6:
                greenKeyPos = initialKeyPos;
                greenKey.transform.position = greenKeyPos;
                break;
            case 7:
                greenredKeyPos = initialKeyPos;
                greenredKey.transform.position = greenredKeyPos;
                break;
            case 8:
                greenblueKeyPos = initialKeyPos;
                greenblueKey.transform.position = greenblueKeyPos;
                break;
            case 9:
                redyellowKeyPos = initialKeyPos;
                redyellowKey.transform.position = redyellowKeyPos;
                break;
            case 10:
                blueyellowKeyPos = initialKeyPos;
                blueyellowKey.transform.position = blueyellowKeyPos;
                break;
            case 11:
                greenyellowKeyPos = initialKeyPos;
                greenyellowKey.transform.position = greenyellowKeyPos;
                break;
            case 12:
                yellowKeyPos = initialKeyPos;
                yellowKey.transform.position = yellowKeyPos;
                break;
            case 13:
                yellowredKeyPos = initialKeyPos;
                yellowredKey.transform.position = yellowredKeyPos;
                break;
            case 14:
                yellowblueKeyPos = initialKeyPos;
                yellowblueKey.transform.position = yellowblueKeyPos;
                break;
            default:
                yellowgreenKeyPos = initialKeyPos;
                yellowgreenKey.transform.position = yellowgreenKeyPos;
                break;
        }

    }
}
