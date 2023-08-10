using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LatihanApplication : MonoBehaviour
{
     public void menu_utama () {
        
		SceneManager.LoadScene("main");
     }
	 	 
    public void profil()
    {

        SceneManager.LoadScene("kreator");
    }

    public void Kembali () {
        
		SceneManager.LoadScene("main");
     }
	public void belajar () {
        
		SceneManager.LoadScene("belajar");
		
     }   

     public void pazzle () {
        
		SceneManager.LoadScene("puzzle");
		
     }  

     public void huruf () {
        
		SceneManager.LoadScene("huruf");
		
     }  

      public void tentang () {
        
		SceneManager.LoadScene("tentang");
		
     }  

     public void kuis1_campuran () {
        
		SceneManager.LoadScene("soal_1_campuran");
		
     }
     public void kuis1_penjumlahan () {
        
		SceneManager.LoadScene("soal_1_penjumlhan");
		
     }
     
    public void ExitNow()
    {
        Application.Quit();
    }
    public void playnext()
    {

        SceneManager.LoadScene("wisata2");

    }
    public void playnext1()
    {

        SceneManager.LoadScene("wisata3");

    }
    public void playkembali()
    {

        SceneManager.LoadScene("wisata");

    }

}
