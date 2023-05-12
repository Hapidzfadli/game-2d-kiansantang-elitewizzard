using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // nama scene yang akan dipindahkan

    // method untuk memindahkan scene saat button diklik
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // memuat scene dengan nama yang ditentukan
    }
}