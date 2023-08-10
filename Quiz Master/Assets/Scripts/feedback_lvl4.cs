using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback_lvl4 : MonoBehaviour
{
    public GameObject senyum;
    public bool selesai = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cek()
    {
        for(int i = 0; i < 25; i++)
        {
            if(transform.GetChild(i).GetComponent<drag_lvl4>().on_tempel)
            {
                selesai = true;
            }
            else
            {
                selesai = false;
                i = 25;
            }
        }
        if (selesai)
        {
            senyum.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!selesai)
        {
            cek();
        }
    }
}
