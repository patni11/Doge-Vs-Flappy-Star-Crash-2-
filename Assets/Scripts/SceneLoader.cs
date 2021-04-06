using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Start()
    {   
        Invoke("LoadFirstScene",2f);
    }

    void LoadFirstScene(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.volume = 0.2f;
        SceneManager.LoadScene(1);
    }
}
