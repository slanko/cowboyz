using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainScript : MonoBehaviour
{
    gameManager gm;
    Animator anim;
    public KeyCode fireButton;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void perish()
    {
        anim.SetTrigger("die");
    }
}
