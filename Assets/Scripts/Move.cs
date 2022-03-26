using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 7;
    public Transform laser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, new Vector3(transform.position.x + 0.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        }
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -Global.max_x)
        { 
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < Global.max_x)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }                                                              
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < Global.max_y)                             
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }                                                              
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -Global.max_y)                           
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
    }
}
