using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KishiP1 : MonoBehaviour {

    public float kishiSpeed;
    public bool isWalking;

    public float walkTime;
    public float idleTime;

    public float walkCounter;
    public float idleCounter;

    private Rigidbody2D myRigitbody;
    private Animation walkingAnimation;

	// Use this for initialization
	void Start () {
        myRigitbody = GetComponent<Rigidbody2D>();
        walkingAnimation = GetComponent<Animation>();

        walkCounter = walkTime;
        idleCounter = idleTime;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(isWalking == true)
        {
            
            walkCounter -= Time.deltaTime;

            myRigitbody.velocity = new Vector2(kishiSpeed, 0);

            if (walkCounter <= 0)
            {
                //gameObject.GetComponent<Animator>().Play("Kishi_idle");
                gameObject.GetComponent<Animation>().Stop("Kishi_walking");
                isWalking = false;
                idleCounter = idleTime;
            } 
        }
        else
        {
            idleCounter -= Time.deltaTime;
            
            myRigitbody.velocity = Vector2.zero;

            if (idleCounter < 0)
            {
                gameObject.GetComponent<Animator>().Play("Kishi_walking");
                isWalking = true;
                walkCounter = walkTime;
            }
        }
	}
}
