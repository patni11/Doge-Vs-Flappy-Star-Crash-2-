using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject enemyBullet;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider(){
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other) {
        
        GameObject explosionfx = Instantiate(explosion,transform.position, Quaternion.identity);
        explosionfx.transform.parent = parent;
        AddScore();
        Destroy(gameObject);
        print("Particle Collided  " + gameObject.name);
    }

    private void AddScore(){
    	GameObject text = GameObject.Find("ScoreBoard");
    	ScoreBoard script = (ScoreBoard) text.GetComponent(typeof(ScoreBoard));
    	script.ScoreHit();
    }
}
 