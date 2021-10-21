using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
    [SerializeField] private float damping;
    public void RotateCamera(float currentTouch, float touchPoint) {
         var difference = currentTouch - touchPoint;

         var rotation = transform.rotation;
         
         var newRotation = Quaternion.Euler(rotation.x, rotation.eulerAngles.y + difference,
             rotation.z);

         rotation = Quaternion.Lerp(rotation, newRotation, Time.deltaTime * damping);
         transform.rotation = rotation;
    }
}
