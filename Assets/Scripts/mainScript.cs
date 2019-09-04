using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    gameManager gm;
    public GameObject GOD, droppedGun, flungHat;
    Animator anim;
    public KeyCode fireButton;
    GameObject gun, hat;
    ParticleSystem pSys, gPSys;
    public AudioClip[] gunSounds;
    public AudioClip[] bodyFalls;
    public AudioClip gunCockSound;
    AudioSource soundzz;

    // Start is called before the first frame update
    void Start()
    {
        soundzz = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        gm = GOD.GetComponent<gameManager>();
        gun = GameObject.Find(gameObject.name + "/gun");
        hat = GameObject.Find(gameObject.name + "/everyman/Armature/Hips/Chest/Head/hat1");
        pSys = GameObject.Find(gameObject.name + "/everyman/Armature/Hips/Chest/Head/TorsoBlood").GetComponent<ParticleSystem>();
        gPSys = GameObject.Find(gameObject.name + "/gun/gunParticles").GetComponent<ParticleSystem>();
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
            soundzz.PlayOneShot(gunSounds[Random.Range(0, gunSounds.Length)]);
            gPSys.Play();
        }
        if (gameObject.tag == "Player2")
        {
            gm.P2Shot = true;
            soundzz.PlayOneShot(gunSounds[Random.Range(0, gunSounds.Length)]);
            gPSys.Play();
        }
    }

    void fumble()
    {
        anim.SetTrigger("fumble");
        if (gameObject.tag == "Player1")
        {
            gm.P1Fumbled = true;
        }
        if (gameObject.tag == "Player2")
        {
            gm.P2Fumbled = true;
        }
    }

    void playCockSound()
    {
        soundzz.PlayOneShot(gunCockSound);
    }

    void dropGun()
    {
        if(gun.activeSelf == true)
        {
            Instantiate(droppedGun, gun.transform.position, gun.transform.rotation);
            gun.SetActive(false);
        }
    }

    void flingHat()
    {
        if(hat.activeSelf == true)
        {
            Instantiate(flungHat, hat.transform.position, hat.transform.rotation);
            hat.SetActive(false);
        }
    }

    void perish()
    {
        anim.SetTrigger("perish");
    }

    void bodyFallNoise()
    {
        soundzz.PlayOneShot(bodyFalls[Random.Range(0, bodyFalls.Length)]);
    }
}
