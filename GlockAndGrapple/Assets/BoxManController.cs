using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;

public class BoxManController : MonoBehaviour {

    public Animator animCont;
    public PuppetMaster puppet;
    private PuppetMaster.StateSettings pms;
    public Rigidbody rootRB;

    public bool dead, extend, contract;

	void Start ()
    {
        pms = puppet.stateSettings;

        rootRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;
    }

    void Update ()
    {
        if (Input.GetKeyDown("k"))
            Dead();

        if (Input.GetKeyDown("w"))
        {
            animCont.SetBool("extend", true);
            animCont.SetBool("contract", false);
        }
        if (Input.GetKeyDown("s"))
        {
            animCont.SetBool("contract", true);
            animCont.SetBool("extend", false);
        }
        if (Input.GetKeyUp("w"))
        {
            animCont.SetBool("extend", false);
        }
        if (Input.GetKeyUp("s"))
        {
            animCont.SetBool("contract", false);
        }
    }

    void Dead ()
    {
        dead = !dead;

        if (dead)
        {
            puppet.Kill(pms);
        }
        else
        {
            puppet.Resurrect();
        }
    }
}
