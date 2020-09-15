using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //赤いドア
    [SerializeField] GameObject redDoor;
    [SerializeField] GameObject redblueDoor;
    [SerializeField] GameObject redgreenDoor;
    //青いドア
    [SerializeField] GameObject blueDoor;
    [SerializeField] GameObject blueredDoor;
    [SerializeField] GameObject bluegreenDoor;
    //緑ドア
    [SerializeField] GameObject greenDoor;
    [SerializeField] GameObject greenredDoor;
    [SerializeField] GameObject greenblueDoor;
    //赤い鍵
    [SerializeField] GameObject redKey;
    [SerializeField] GameObject redblueKey;
    [SerializeField] GameObject redgreenKey;
    //青い鍵
    [SerializeField] GameObject blueKey;
    [SerializeField] GameObject blueredKey;
    [SerializeField] GameObject bluegreenKey;
    [SerializeField] GameObject blueyellowKey;
    //緑鍵
    [SerializeField] GameObject greenKey;

    private int door1;
    private int door2;
    private int key;
    int rightDoor;
    Vector3 initialDoor1Pos;
    Vector3 initialDoor2Pos;
    Vector3 initialKeyPos;
    float ExcludeDoorPos;

    // Start is called before the first frame update
    void Start()
    {
        initialDoor1Pos = redDoor.transform.position;
        initialDoor1Pos.z = 0;
        initialDoor2Pos = blueDoor.transform.position;
        initialDoor2Pos.z = 0;
        initialKeyPos = redKey.transform.position;
        initialKeyPos.z = 0;


        //画面外のドアの位置
        ExcludeDoorPos = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            DeployObj();
        }
    }

    public void random()
    {
        door1 = Random.Range(0, 3);
        door2 = Random.Range(0, 3);
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
    public void initialazeDoor()
    {

    }

    public void DeployObj()
    {
        random();



        //RightDoor
        switch (door1)
        {
            case 0:
                redDoor.transform.position = initialDoor1Pos;
                break;
            case 1:
                blueDoor.transform.position = initialDoor1Pos;
                break;
            default:
                greenDoor.transform.position = initialDoor1Pos;
                break;
        }

        //LeftDoor
        switch (door2)
        {
            case 0:
                redDoor.transform.position = initialDoor2Pos;
                break;
            case 1:
                blueDoor.transform.position = initialDoor2Pos;
                break;
            default:
                greenDoor.transform.position = initialDoor2Pos;
                break;
        }

        //Key
        switch (key)
        {
            case 0:
                redKey.transform.position = initialKeyPos;
                break;
            case 1:
                blueKey.transform.position = initialKeyPos;
                break;
            default:
                greenKey.transform.position = initialKeyPos;
                break;
        }

    }
}
