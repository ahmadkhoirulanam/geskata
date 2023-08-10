using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_lvl3 : MonoBehaviour
{
    public GameObject parent_puzzle, senyum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseUp()
    {
        for (int i = 0; i < 16; i++)
        {
            parent_puzzle.transform.GetChild(i).GetComponent<drag_lvl3>().on_tempel = false;
            parent_puzzle.transform.GetChild(i).GetComponent<drag_lvl3>().on_pos = false;
            parent_puzzle.transform.GetChild(i).position = parent_puzzle.transform.GetChild(i).GetComponent<drag_lvl3>().pos_awal;
            parent_puzzle.transform.GetChild(i).localScale = parent_puzzle.transform.GetChild(i).GetComponent<drag_lvl3>().scale_awal;           
        }
        senyum.SetActive(false);
        parent_puzzle.GetComponent<feedback_lvl3>().selesai = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
