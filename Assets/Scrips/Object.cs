using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public static Object instance;
    public Rigidbody2D Ftire;
    public Rigidbody2D Btire;
    public Rigidbody2D Objected;
    public float speed;
    public float movement;
    public float gas = 1f;
    public float gasConSumption = 0.1f;
    public Image gasImage;
    // Start is called before the first frame update
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }
    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        gasImage.fillAmount = gas;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       if(gas > 0) 
       {
            Ftire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            Btire.AddTorque(-movement * speed * Time.fixedDeltaTime);
            Objected.AddTorque(movement * speed * Time.fixedDeltaTime);
       }

        gas = gas - gasConSumption * Time.fixedDeltaTime * Mathf.Abs(movement);
    }
}
