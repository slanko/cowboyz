using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    gameManager gm;
    public GameObject GOD, droppedGun;
    Animator anim;
    public KeyCode fireButton;
    GameObject gun;
    ParticleSystem pSys;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gm = GOD.GetComponent<gameManager>();
        gun = GameObject.Find(gameObject.name + "/gun");
        pSys = GameObject.Find(gameObject.name + "/everyman/Armature/Hips/Chest/Head/TorsoBlood").GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(fireButton))
        {
            if(gameObject.tag == "Player1")
            {
                gm.P1Ready = true;
            }
            if(gameObject.tag == "Player2")
            {
                gm.P2Ready = true;
            }
        }

        if (Input.GetKeyUp(fireButton))
        {
            if(gm.bellsRung == true)
            {
                shoot();
            }
            else
            {
                fumble();
            }
        }

        if (gameObject.tag == "Player1")
        {
            if(gm.P2Shot == true)
            {
                perish();
            }
        }
        if (gameObject.tag == "Player2")
        {
            if (gm.P1Shot == true)
            {
                perish();
            }
        }
    }

    void bloodSpray()
    {
        pSys.Play();
    }

    void shoot()
    {
        anim.SetTrigger("shoot");
    }

    public void actuallyShoot()
    {
        if (gameObject.tag == "Player1")
        {
            gm.P1Shot = true;
        }
        if (gameObject.tag == "Player2")
        {
            gm.P2Shot = true;
        }
    }

    void fumble()
    {
        anim.SetTrigger("fumble");
    }

    void dropGun()
    {
        if(gun.activeSelf == true)
        {
            Instantiate(droppedGun, gun.transform.position, gun.transform.rotation);
            gun.SetActive(false);
        }
    }

    void perish()
    {
        anim.SetTrigger("perish");
    }
}
