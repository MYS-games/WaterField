using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Animator anim = null;

    void Start()
    {
        ///anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Walking
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("Walk");
            // anim.SetBool("Walk", true);

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }

        //turnRight
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("Right");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }
        //turnLeft
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Left");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }


    }
}


/*using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class MoveController : NetworkBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;

    private Camera mainCamera;
    Animator anim;
    #region Server

    [Command]
    private void CmdMove(Vector3 position)
    {
        Debug.Log("hello");
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas)) { return; }

        agent.SetDestination(hit.position);
        Debug.Log("hi");
    }

    #endregion

    public override void OnStartAuthority()
    {
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
    }


   *//* void Start()
    {
        anim = GetComponent<Animator>();
    }*//*



    [ClientCallback]
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        //CmdMove(movement);
       *//* //Walking
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.Play("Walk");

           // anim.SetBool("Walk", true);

        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }

        //turnRight
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.Play("Right");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }
        //turnLeft
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.Play("Left");
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.GetComponent<Animation>().Stop();
        }
*/
/* //Running
 if (Input.GetKey(KeyCode.R))
 {
     anim.Play("Run");
 }
 if (Input.GetKeyUp(KeyCode.R))
 {
     anim.GetComponent<Animation>().Stop();
 }
 //jumping
 if (Input.GetKey(KeyCode.Space))
 {
     Debug.Log("jump");
     anim.Play("Big Jump");
 }
 if (Input.GetKeyUp(KeyCode.Space))
 {
     anim.GetComponent<Animation>().Stop();
 }

 //shoot
 if (Input.GetButtonDown("Fire1"))
 {
     anim.Play("shoot");
 }
 if (Input.GetButtonUp("Fire1"))
 {
     anim.GetComponent<Animation>().Stop();
 }
*/

/*anim.SetBool("Walk", Input.GetKey(KeyCode.UpArrow));
anim.SetBool("Run", Input.GetKey(KeyCode.R));
anim.SetBool("Jump", Input.GetKey(KeyCode.Space));
anim.SetBool("Right", Input.GetKey(KeyCode.RightArrow));
anim.SetBool("Left", Input.GetKey(KeyCode.LeftArrow));
anim.SetBool("shoot", Input.GetButton("Fire1"));*//*
}
}
*//*void Update()
{
   if(Input.GetMouseButtonUp(0))
  {
     GetComponent<Animation>().Stop();
  }
}
 
public void Shoot()
{
    if(Input.GetMouseButtonDown(0)) // Mouse left button
    {
       GetComponent<Animation>().Play();
    }
}*/
