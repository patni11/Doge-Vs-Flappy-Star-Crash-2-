using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // as long as this is the only script loading scene

public class CollisionHandler : MonoBehaviour
{   
    int currentScene;
    [SerializeField] GameObject explosion_particle;
    void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;    
    }

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }
    private void OnCollisionEnter(Collision other) {
        StartDeathSequence();
    }

    private void OnParticleCollision(GameObject other) {
        print("CollidedWithPlayer");
        if (other.tag == "enemyBullet"){
            StartDeathSequence();
        }
    }

    private void StartDeathSequence(){
        explosion_particle.SetActive(true);
        SendMessage("OnPlayerDeath");
        //gameObject.SetActive(false);
        Invoke("ReloadScene",1);
    }

    private void ReloadScene(){
        //SendMessage("restartMusic");
        SceneManager.LoadScene(1);    
    }
    

}
