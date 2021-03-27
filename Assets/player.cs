using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 33f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 33f;
    
    [Tooltip("In m")][SerializeField] float[] xrange = {-16f,16f};
    [Tooltip("In m")][SerializeField] float[] yrange = {-10f,10f};

    [SerializeField] float PositionPitchFactor = 2;
    [SerializeField] float PositionYawFactor = 1;
    
    [SerializeField] float ControlPitchFactor = -10;
    [SerializeField] float ControlRollFactor = -20;

    float horizontalThrow, verticalThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Translation();
        Rotation();
        
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
        
        transform.localPosition = new Vector3(XPos,YPos,transform.localPosition.z);
        //transform.Translate(Xoffset,0,0);
    }
}
