using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade_in_and_out : MonoBehaviour
{
    // Start is called before the first frame update
    private bool fadeInBool, fadeOutBool;
    [SerializeField] float fadeSpeed = 0.1f;

    void Start() {
        Color objectColor = this.GetComponent<Renderer>().material.color;
        this.GetComponent<Renderer>().material.color = new Color(objectColor.r,objectColor.g,objectColor.b,0f);
        transform.SetSiblingIndex(3);

        GameObject terrain = GameObject.Find("Terrain");
        terrain.transform.SetSiblingIndex(0);
        fadeIn();    
    }

    void Update(){
        if (fadeInBool){
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r,objectColor.g,objectColor.b,fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a >= 1){
                fadeInBool = false;
                Invoke("fadeOut",1.9f);
            }
        }

        if (fadeOutBool){
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r,objectColor.g,objectColor.b,fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;

            if (objectColor.a <= 0){
                fadeOutBool = false;
            }
        }
    }

    private void fadeIn(){
        fadeInBool = true;
    }

    private void fadeOut(){
        fadeOutBool = true;
    }
}
