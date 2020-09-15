using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyMove2 : MonoBehaviour
{
    private Vector3 data;
    private Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        location = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dragkey()
    {
        data = Input.mousePosition;
        //Debug.Log("Hellow");
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }

    public void EndDrag()
    {
        transform.position = location;
    }

}
