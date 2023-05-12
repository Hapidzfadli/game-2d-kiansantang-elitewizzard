using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupObject; // game object popup yang ingin ditampilkan

    // method untuk menampilkan popup saat button diklik
    public void ShowPopup()
    {
        popupObject.SetActive(true); // menampilkan popup object
    }

    // method untuk menyembunyikan popup saat button ditutup
    public void HidePopup()
    {
        popupObject.SetActive(false); // menyembunyikan popup object
    }

    // method yang dipanggil saat script pertama kali dijalankan
    private void Start()
    {
        // menyembunyikan popup object saat scene pertama kali dimuat
        popupObject.SetActive(false);
    }
}
