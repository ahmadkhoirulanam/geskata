using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class drag_lvl4 : MonoBehaviour
{
    public AudioSource suaratombol;
    public AudioSource suaratombol_tahan;
    public GameObject detector;
    public Vector3 pos_awal, scale_awal;
    public bool on_pos = false, on_tempel  = false;
    // Start is called before the first frame update
    void Start()
    {
        pos_awal = transform.position;
        scale_awal = transform.localScale;
    }

    void OnMouseDown()
    {
        suaratombol.PlayOneShot(suaratombol_tahan.clip);
    }

    void OnMouseDrag()
    {
        Vector3 pos_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        transform.position = new Vector3(pos_mouse.x, pos_mouse.y, -1f);
        transform.localScale = new Vector2(0.15f, 0.15f);        
    }

    void OnMouseUp()
    {
        suaratombol.PlayOneShot(suaratombol_tahan.clip);
        if (on_pos)
        {
            transform.position = detector.transform.position;
            transform.localScale = new Vector2(0.15f, 0.15f);
            on_tempel = true;
        }
        else
        {
            transform.position = pos_awal;
            transform.localScale = scale_awal;
            on_tempel = false;
        }
    }

    void OnTriggerStay2D(Collider2D objek)
    {
        if(objek.gameObject == detector)
        {
            on_pos = true;
        }
    }

    void OnTriggerExit2D(Collider2D objek)
    {
        if (objek.gameObject == detector)
        {
            on_pos = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
