using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour{
    [SerializeField] private DoorCtrl[] m_doors;
    [SerializeField] private DragDrop[] m_keys;

    [SerializeField] private GameObject[] m_doorPosition;
    [SerializeField] private GameObject m_keyPosition;
    [SerializeField] private TimeCounter m_timeCounter;

    [SerializeField] private float m_levelUpTime = 10.0f;

    private int m_door1;
    private int m_door2;
    private int m_door3;

    [HideInInspector] public int Score;

    private bool m_levelUp = false;

    private void Start(){
        Deploy();
    }

    private void Update(){
        if (m_timeCounter.countdown <= m_levelUpTime) {
            m_levelUp = true;
        }
    }

    private void SetDoorRandomly(){
        var length = m_doors.Length;
        m_door1 = Random.Range(0, length - 1);
        while (true) {
            m_door2 = Random.Range(0, length - 1);
            if (m_door1 != m_door2) break;
        }
        while (true) {
            m_door3 = Random.Range(0, length - 1);
            if (m_door3 != m_door1 && m_door3 != m_door2) break;
        }
    }

    private int GetKeyIndexRandomly(){
        var result = Random.Range(0, m_keys.Length);
        return result;
    }

    public void Deploy(){
        //door
        SetDoorRandomly();
        foreach (var door in m_doors) {
            door.gameObject.SetActive(false);
        }
        m_doors[m_door1].gameObject.SetActive(true);
        if(m_levelUp) m_doors[m_door2].gameObject.SetActive(true);
        m_doors[m_door3].gameObject.SetActive(true);

        m_doors[m_door1].transform.position = m_doorPosition[0].transform.position;
        m_doors[m_door2].transform.position = m_doorPosition[1].transform.position;
        m_doors[m_door3].transform.position = m_doorPosition[2].transform.position;
        
        //key
        foreach (var key in m_keys) {
            key.gameObject.SetActive(false);
        }

        int keyIndex = 0;
        while (true) {
            keyIndex = GetKeyIndexRandomly();
            if (m_levelUp) {
                if (m_doors[m_door1].CompareTag(m_keys[keyIndex].tag) ||
                    m_doors[m_door2].CompareTag(m_keys[keyIndex].tag) ||
                    m_doors[m_door3].CompareTag(m_keys[keyIndex].tag)) {
                    break;
                }
            }
            else {
                if (m_doors[m_door1].CompareTag(m_keys[keyIndex].tag) ||
                    m_doors[m_door3].CompareTag(m_keys[keyIndex].tag)) {
                    break;
                }
            }
        }
        m_keys[keyIndex].gameObject.SetActive(true);
        m_keys[keyIndex].transform.position = m_keyPosition.transform.position;
    }
}
