using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRotationBehaviour : MonoBehaviour {
    [SerializeField] private float damping;
    [SerializeField] private float decelerationForce;
    private float speed;
    private bool isSpeedNegative;
    [SerializeField] private bool isScrolling;
    
    public void RotateCamera(float currentTouch, float touchPoint) {
        isScrolling = true;
        
         var difference = currentTouch - touchPoint;

         var rotation = transform.rotation;
         
         var newRotation = Quaternion.Euler(rotation.x, rotation.eulerAngles.y + difference,
             rotation.z);

         rotation = Quaternion.Lerp(rotation, newRotation, Time.deltaTime * damping);
         transform.rotation = rotation;
         
         speed = difference;
         
         if (speed < 0) {
             isSpeedNegative = true;
         }
         else {
             isSpeedNegative = false;
         }
    }

    public void DecelerateCamera() {
        if(CheckStopped()) return;
        
        var rotation = transform.rotation;
        if (speed > 0) {
            speed -= 0.5f;
        }
        else {
            speed += 0.5f;
        }
        
        var newRotation = Quaternion.Euler(rotation.x, 
            rotation.eulerAngles.y+(speed/decelerationForce),
            rotation.z);
        
        rotation = Quaternion.Lerp(rotation, newRotation, Time.deltaTime * damping);
        transform.rotation = rotation;
    }

    public bool CheckStopped() {
        if (speed == 0) return true;

        if (isSpeedNegative && speed > 0) {
            return true;
        }

        if (!isSpeedNegative && speed < 0) {
            return true;
        }

        return false;
    }

    public void StopScrolling() {
        isScrolling = false;
    }

    public bool CheckIfScrolling() {
        return isScrolling;
    }
}
