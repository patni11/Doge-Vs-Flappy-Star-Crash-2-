using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 33f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 33f;
    [Tooltip("In ms^-2")][SerializeField] float gravity = 9.8f;
    [Tooltip("In m")][SerializeField] float[] xrange = {-16f,16f};
    [Tooltip("In m")][SerializeField] float[] yrange = {-10f,10f};

    [SerializeField] float PositionPitchFactor = 2;
    [SerializeField] float PositionYawFactor = 1;
    
    [SerializeField] float ControlPitchFactor = -10;
    [SerializeField] float ControlRollFactor = -20;

    System.Random temp = new System.Random();
    float gravityTime = 6;
    float horizontalThrow, verticalThrow;
    bool isControlEnabled = true;
    bool isAntiGravityEnabled = false;
    // Update is called once per frame

    GameObject antiGravityVideo;

    void Update()
    {   if (isControlEnabled){
         Translation();
         Rotation();    
    }  
        //gameObject.GetComponent<Rigidbody>().AddForce(Physics.gravity, ForceMode.Acceleration);  
        if (isAntiGravityEnabled){
            transform.Translate(Time.deltaTime * gravity * Vector3.up);
        }else{
            transform.Translate(Time.deltaTime * gravity * Vector3.down);
        }
    }

    void Start(){
        antiGravityVideo = GameObject.Find("gravityVid");
        antiGravityVideo.SetActive(false);
        Invoke("Gravity",gravityTime);
    }

    private void Gravity(){
        if (isAntiGravityEnabled){
            isAntiGravityEnabled = false;
            gravityTime = temp.Next(5, 12);
        }else{
            isAntiGravityEnabled = true;
            gravityTime = temp.Next(5, 12);
        }
        AddAntiGravityVideo();
        Invoke("Gravity",gravityTime);
        
    }

    private void AddAntiGravityVideo(){
        if (antiGravityVideo.activeSelf){
            antiGravityVideo.SetActive(false);
        }else{
            antiGravityVideo.SetActive(true);
            Invoke("AddAntiGravityVideo",2);
        }
        
    }

    private void Rotation(){
        float pitch = (transform.localPosition.y * PositionPitchFactor) + verticalThrow * ControlPitchFactor;
        float yaw = (transform.localPosition.x * PositionYawFactor);
        float roll = horizontalThrow * ControlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
        
    }


    private void Translation(){
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float Xoffset = horizontalThrow * xSpeed * Time.deltaTime;
        float XPos = Mathf.Clamp(transform.localPosition.x + Xoffset,xrange[0],xrange[1]);

        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float Yoffset = verticalThrow * ySpeed * Time.deltaTime;
        float YPos = Mathf.Clamp(transform.localPosition.y + Yoffset, yrange[0],yrange[1]);

        float ZPos = Mathf.Clamp(transform.localPosition.z, 18.4f,18.4f);

        transform.localPosition = new Vector3(XPos,YPos,ZPos);
        //transform.Translate(Xoffset,0,0);
    }

    void OnPlayerDeath(){
        isControlEnabled = false;
    }
}
