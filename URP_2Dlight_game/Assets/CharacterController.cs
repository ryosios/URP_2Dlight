using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class CharacterController : MonoBehaviour
{
    Transform this_tf;

    [SerializeField]
    Transform chara_image_tf;
    Rigidbody2D this_rigid2D;

    Vector2 chara_pos;

    public int jump_count { get; set; }


    public bool is_ground { get; set; }
    public bool on_attack { get; set; }

    [SerializeField]
    float chara_speed;
    [SerializeField]
    Animator chara_skeletonanim;

    // Start is called before the first frame update
    void Start()
    {
        this_tf = GetComponent<Transform>();
        this_rigid2D = GetComponent<Rigidbody2D>();
        is_ground = false;

        
    }

    // Update is called once per frame
    void Update()
    {
       
        CharaMove();
        JumpMove();
        AttackMove();
    }

    private void FixedUpdate()
    {
        
        
        
        
        
       
        
    }

    void CharaMove()
    {
        //this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        if (is_ground == true)
        {
           

        }
        
        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyUp(KeyCode.UpArrow))
        {
            chara_pos = this_rigid2D.velocity;
            chara_pos.x = chara_speed;
            this_rigid2D.velocity = chara_pos;

            chara_image_tf.localScale = new Vector3(1, 1, 1);

            //chara_skeletonanim.state.SetAnimation(0, "run", true);
            chara_skeletonanim.SetBool("run_bool",true);

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (  is_ground == true)
            {
                chara_pos = this_rigid2D.velocity;
                chara_pos.x = chara_speed;
                this_rigid2D.velocity = new Vector2(0, 0);
                chara_skeletonanim.SetBool("run_bool", false);
            }
            else
            {
                chara_skeletonanim.SetBool("run_bool", false);
            }
            // chara_skeletonanim.state.SetAnimation(0, "wait", true);
            
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKeyUp(KeyCode.UpArrow))
        {
            chara_pos = this_rigid2D.velocity;
            chara_pos.x = -chara_speed;
            this_rigid2D.velocity = chara_pos;

            chara_image_tf.localScale = new Vector3(-1, 1, 1);
            chara_skeletonanim.SetBool("run_bool", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            if( is_ground == true)
            {
                chara_pos = this_rigid2D.velocity;
                chara_pos.x = chara_speed;
                this_rigid2D.velocity = new Vector2(0, 0);
                chara_skeletonanim.SetBool("run_bool", false);
            }
            else
            {
                chara_skeletonanim.SetBool("run_bool", false);
            }
        }
    }

    void JumpMove()
    {
         if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(jump_count == 0 && is_ground == true)
            {
                jump_count += 1;

                chara_skeletonanim.SetTrigger("jump_trigger");
                this_rigid2D.AddForce(new Vector2(0, chara_speed * 110));

            }


        }

    }

    void AttackMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(on_attack == false)
            {
                on_attack = true;
                StartCoroutine("AttackMoveC");
            }
            
        }

    }

    private IEnumerator AttackMoveC()
    {
        chara_skeletonanim.SetTrigger("attack_trigger");
        yield return new WaitForSeconds(1f);
        
        on_attack = false;
    }


    



    private void OnCollisionStay2D(Collision2D collision)
    {

       // Debug.Log(is_ground);
        
       //    is_ground = true;
            
       
       

        
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
       

     //  is_ground = false;
      //  jump_count = 0;


    }

    void IsGround()
    {
        
    }
}
