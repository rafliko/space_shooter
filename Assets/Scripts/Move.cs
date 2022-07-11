using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform laser;
    public bool invoking = false;

    // Update is called once per frame
    private void Update()
    {
        var mPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mPos.z = 0;
        mPos.x += 2;
        if(mPos.x > -9f && mPos.x < 9f && mPos.y < 5f && mPos.y > -5f)
        {
            transform.position = mPos;
        }
        if (Input.GetMouseButtonDown(0) && !invoking)
        {
            InvokeRepeating("Shoot", 0.25f, 0.5f);
            invoking = true;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
            invoking = false;
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(laser, new Vector3(transform.position.x + 0.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
        }
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -8.5f)
        { 
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 8.5f)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
        }                                                              
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4.5f)                             
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }                                                              
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4.5f)                           
        {
            transform.position += Vector3.down * Time.deltaTime * speed;
        }
        */
    }

    void Shoot()
    {
        Instantiate(laser, new Vector3(transform.position.x + 0.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }
}
