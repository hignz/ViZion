using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour {

    public ParticleSystem mainParticleSys;
    public ParticleSystem leftParticleSys;
    public ParticleSystem rightParticleSys;
    public ParticleSystem lightParticleSys;

    private float xAxis, yAxis;

    void Start () {
		
	}
	
	void Update () {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        HandleMainTrail();
        HandleWingTrails();
	}


    private void HandleWingTrails()
    {
        if (!(xAxis > 0))
        {
            leftParticleSys.Play();
        }

        if (!(xAxis < 0))
        {
            rightParticleSys.Play();
        }
    }

    private void HandleMainTrail()
    {
        if (!(yAxis > 0))
        {
            mainParticleSys.Play();
            lightParticleSys.Play();
        }
    }
}
