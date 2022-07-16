using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] float directionSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float directionAmount = Input.GetAxisRaw("Horizontal") * directionSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -directionAmount);
        transform.Translate(0, moveAmount, 0);
    }
}