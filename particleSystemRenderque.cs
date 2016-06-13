sing UnityEngine;
using System.Collections;

public class particleSystemRenderque : MonoBehaviour {

    ParticleSystem temp;

	// Use this for initialization
	void Start () {
        temp = GetComponent<ParticleSystem>();
        temp.renderer.material.renderQueue = 3501;
	}
	
	
}
