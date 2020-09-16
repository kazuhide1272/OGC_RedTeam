using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour{
    [SerializeField] private GameManager m_game;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 originPosition;

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;

    [SerializeField]UnityEngine.AudioSource audioSource;


    private bool m_enableInput = true;

    public void OnMouseDown()
    {
        // このオブジェクトの位置(transform.position)をスクリーン座標に変換。
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        // ワールド座標上の、マウスカーソルと、対象の位置の差分。
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        originPosition = transform.position;
    }

   public void OnMouseDrag()
    {
        if(!m_enableInput) return;
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
    public void OnMouseUp()
    {
        transform.position = originPosition;
    }

    private IEnumerator DisableInputCoroutine(){
        yield return new WaitForSeconds(2.0f);
        m_enableInput = true;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (gameObject.CompareTag(collision.gameObject.tag)) {
            m_game.Deploy();
            m_game.Score++;
            audioSource.PlayOneShot(sound1);
            audioSource.PlayOneShot(sound2);

        }
        else {
            m_enableInput = false;
            StartCoroutine(DisableInputCoroutine());
            audioSource.PlayOneShot(sound3);
        }
    }
}
