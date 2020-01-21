using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    public GameObject health_scroll;
    public GameObject tiple_shot;
    public GameObject Powerfull_laser;
    public GameObject Laser;
    public float speed = 5f;
    public float firerate =20f;
    public float canfire = 0.0f;
    public float boostupSpeed = 15f;
    public int lives = 3;
    public GameObject Player_Explosion;

    public GameObject shield_gameobject;
    //bools
    public bool shield = false;
    public bool Triple_shot=false;
    public bool isSpeedBoostActive = false;
    //bools ends
    public UIManager uIManager;

    public float horizontal;
    public float vertical;

    
    public void Start () {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(uIManager != null)
        {
            uIManager.UpdateLive(lives);
        }
       



	}

    // Update is called once per frame
    void Update()
    {

       
        AudioSource[] audio = GetComponents<AudioSource>();
        Movement();

        //speed Up
      


        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > canfire)
            {
                if (Triple_shot == true)
                {
                    //center
                    Instantiate(Laser, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);

                    //left
                    Instantiate(Laser, transform.position+new Vector3(-0.51f, -0.09f, 0), Quaternion.identity);
                    //right
                    Instantiate(Laser, transform.position + new Vector3(0.52f, -0.09f, 0), Quaternion.identity);
                }
                else {
                    
             Instantiate(Laser, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);
                }



                audio[0].Play();
               

                canfire = Time.time + firerate;
                


            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            audio[0].Play();
            Instantiate(Powerfull_laser, transform.position + new Vector3(0, 1.06f, 0), Quaternion.identity);

        }
        
        
    }
   

     void Movement()
    {
          horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speed * horizontal * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vertical * Time.deltaTime);
        //isboostAvtice
        if (isSpeedBoostActive == true)
        {

            

            transform.Translate(Vector3.right * boostupSpeed * horizontal * Time.deltaTime);
            transform.Translate(Vector3.up * boostupSpeed * vertical * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontal * Time.deltaTime);
            transform.Translate(Vector3.up * speed * vertical * Time.deltaTime);
        }







        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -3.6f)
        {
            transform.position = new Vector3(transform.position.x, -3.6f, 0);


        }
        //space jet moved
        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8, transform.position.y, 0);
        }
    }

   
    //SpeedBoostUp codes
    public void speedupBoost()
    {
        isSpeedBoostActive = true;
        StartCoroutine(Boost());
    }
    public IEnumerator Boost()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }




    //SpeedBoostUp codes end
    //Triple shot codes start
    public void TripleShotPowerupRoutine()
    {


        Triple_shot = true;
        StartCoroutine(TripleShot());



    }


    public IEnumerator TripleShot()
    {
       
        yield return new WaitForSeconds(5.0f);
        Triple_shot = false;
    }
    //Tripleshot code end
    public void Damage()
    {
        if(shield == true)
        {
            shield = false;
            shield_gameobject.SetActive(false);
            return;
        }

        lives--;
        uIManager.UpdateLive(lives);
        if (lives < 1)
        {
            Instantiate(Player_Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }
    public void Enableshield()
    {
        shield = true;
        shield_gameobject.SetActive(true);
    }
   
   
}
