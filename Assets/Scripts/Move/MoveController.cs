using UnityEngine;

public class MoveController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetBool("shoot", Input.GetButton("Fire1"));*/
    }
}
/*void Update()
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