using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmSwingMotion : MonoBehaviour
{
    public Text left;
    public Text right;
    public Text speedText;
    public Transform leftArm;
    public Transform rightArm;
    private Vector3 currLeftArmPos;
    private Vector3 currRightArmPos;
    private Vector3 prevLeftArmPos;
    private Vector3 prevRightArmPos;
    public float movementSpeed;
    public float threshold0;
    public float threshold1;
    public float threshold2;
    // Start is called before the first frame update
    void Start()
    {
        currLeftArmPos = leftArm.position;
        currRightArmPos = rightArm.position;
    }

    // Update is called once per frame
    void Update()
    {
        currLeftArmPos = leftArm.position;
        currRightArmPos = rightArm.position;  

        float leftDelta = (currLeftArmPos - prevLeftArmPos).magnitude;
        float rightDelta = (currRightArmPos - prevRightArmPos).magnitude;

        float averagedDelta = (leftDelta + rightDelta) * 0.5f;


        float speed = ScaledSpeed(averagedDelta);
        transform.position += transform.forward * speed * Time.deltaTime;
        
        left.text = "average delata: " + averagedDelta.ToString("f4");
        right.text = "actual speed " + speed.ToString("f4");

        prevLeftArmPos = leftArm.position;
        prevRightArmPos = rightArm.position; 



        // left.text = "l: " + ActionController.Instance.leftAccelerationValue.ToString("f2");
        // right.text = "r: " + ActionController.Instance.rightAccelerationValue.ToString("f2");
        // float v = Mathf.Abs(ActionController.Instance.leftAccelerationValue - 
        // ActionController.Instance.rightAccelerationValue);
        // speedText.text = "v diff: " + v.ToString("f2");
      //  Debug.Log("speed " + v);
    }

    float ScaledSpeed(float speedDelta) {
        float speed = 0f;
        if (speedDelta < threshold0)
            speed = movementSpeed * 0.2f;
        
        else if (speedDelta < threshold1)
            speed = movementSpeed * 0.6f;
        else 
            speed = movementSpeed * 1.8f;


        return speed;
    }
    
}
