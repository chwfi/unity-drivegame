using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow; 
    //이 물체의 위치는 차의 위치와 같아야 한다
    

    // Update is called once per frame
    void lateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -10);
    }
}
