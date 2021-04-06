using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class music_player : MonoBehaviour
{
    //AudioSource audio = gameObject.GetComponent<AudioSource>();
    private void Awake() {

        int numOfMusicPlayers = FindObjectsOfType<music_player>().Length;      
        print(numOfMusicPlayers);
        
        if (numOfMusicPlayers > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);   
            }
    }
    
    void restartMusic(){//string sensitive or string reference
        print("restart ran");
        AudioSource music = gameObject.GetComponent<AudioSource>();
        music.Stop();
    }
        
}
    // Start is called before the first frame update

