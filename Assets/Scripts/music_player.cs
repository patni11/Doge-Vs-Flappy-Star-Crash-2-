using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music_player : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake() {
        DontDestroyOnLoad(gameObject);   
        audioSource = GetComponent<AudioSource>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene",2f);
    }

    void LoadFirstScene(){
        SceneManager.LoadScene(1);
        audioSource.volume = 0.2f;
    }

     public void PlayMusic()
     {
         if (audioSource.isPlaying) return;
         audioSource.Play();
     }
 
     public void StopMusic()
     {
         audioSource.Stop();
     }
}
