using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efektombol : MonoBehaviour
{
    public AudioSource suaratombol;
    float scaleX, scaleY;
    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
    }

    void OnMouseDown()
    {
        suaratombol.PlayOneShot(suaratombol.clip);
        transform.localScale = new Vector2(scaleX * 1.2f, scaleY * 1.2f);
    }

    void OnMouseUp()
    {
        transform.localScale = new Vector2(scaleX, scaleY);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
