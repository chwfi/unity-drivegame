using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] Color32 havePackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool HavePackage;
    [SerializeField] float directionSpeed = 0.1f;
    [SerializeField] float moveSpeed = 0.01f;
    // Start is called before the first frame update
    
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    // Update is called once per frame
    void Update()
    {
        float directionAmount = Input.GetAxisRaw("Horizontal") * directionSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -directionAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) //OnTriggerExit -> 특정영역을 떠났을 때 사용
    {
        if (other.tag == "Package" && !HavePackage)
        {
            Debug.Log("Package picked up");
            HavePackage = true;
            spriteRenderer.color = havePackageColor;
            Destroy(other.gameObject, destroyDelay); 
        }

        if (other.tag == "Customer" && HavePackage){
            Debug.Log("Good");
            HavePackage = false;
            spriteRenderer.color = noPackageColor;

        }

        if (other.tag == "SpeedUp"){
            
            moveSpeed = boostSpeed;
            Destroy(other.gameObject, destroyDelay); 

        }
    }
}
