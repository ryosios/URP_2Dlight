using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class CharacterController : MonoBehaviour
{
    Transform this_tf;

    [SerializeField]
    Transform chara_image_tf;

    [SerializeField]
    AttackGageSC AttackGageSC;

    [SerializeField]
    BoxCollider2D AttackColliison;

    [SerializeField]
    BoxCollider2D TottukiColliison;
    [SerializeField]
    Animator chara_skeletonanim;

    Rigidbody2D this_rigid2D;

    Vector2 chara_pos;

    public Vector2 sakamiti_normal_vector { get; set; }

    public int jump_count { get; set; }


    public bool is_ground { get; set; }
    public bool on_attack { get; set; }

    public bool is_tottuki { get; set; }

    bool on_walljamp = false;

    bool is_D;

    [SerializeField]
    float chara_speed;
    [SerializeField]
    float jump_speed;
    

    // Start is called before the first frame update
    void Start()
    {
        this_tf = GetComponent<Transform>();
        this_rigid2D = GetComponent<Rigidbody2D>();
        is_ground = false;

        AttackColliison.enabled = false;
        TottukiColliison.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(jump_count);

        
            CharaMove();

       // Debug.Log(is_D);
       
        
        JumpMove();
        DownMove();
        AttackMove();


        if (Input.GetKeyDown(KeyCode.D))
        {
            is_D = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {

            is_D = false;
        }

        if (is_D)
        {
            
                chara_skeletonanim.SetBool("tottuki_bool", true);
            




        }
        else
        {
            chara_skeletonanim.SetBool("tottuki_bool", false);
        }
        if (is_ground)
        {
            chara_skeletonanim.SetBool("tottuki_bool", false);
        }




            if (is_ground == false)
        {
           
            TottukiMethod();
            
        }
       
    }

    private void FixedUpdate()
    {







    }

    void CharaMove()
    {


        if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKeyUp(KeyCode.UpArrow))
        {
            //Vector2 sinkou_vector = new Vector2( -sakamiti_normal_vector.y, sakamiti_normal_vector.x);

            chara_pos = this_rigid2D.velocity;
            chara_pos.x = chara_speed;
            this_rigid2D.velocity = chara_pos;

            chara_image_tf.localScale = new Vector3(1, 1, 1);

            //chara_skeletonanim.state.SetAnimation(0, "run", true);
            
                chara_skeletonanim.SetBool("run_bool", true);

            
            

        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (is_ground == true)
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
            //Vector2 sinkou_vector = new Vector2(sakamiti_normal_vector.y, sakamiti_normal_vector.x);
            chara_pos = this_rigid2D.velocity;
            chara_pos.x = -chara_speed;
            this_rigid2D.velocity = chara_pos ;

            chara_image_tf.localScale = new Vector3(-1, 1, 1);
            
                chara_skeletonanim.SetBool("run_bool", true);
           

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (is_ground == true)
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
            if (jump_count == 0 && is_ground == true)
            {
                jump_count += 1;

                chara_skeletonanim.SetTrigger("jump_trigger");
                this_rigid2D.AddForce(new Vector2(0, jump_speed * 110));

            }

            


        }

    }

    void DownMove()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (is_ground == false)
            {
                

                chara_skeletonanim.SetTrigger("down_trigger");
                this_rigid2D.AddForce(new Vector2(0, jump_speed * -110));

            }




        }
    }

    void AttackMove()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (on_attack == false)
            {
                if (AttackGageSC.attack_gage_full == true)
                {
                    on_attack = true;
                    StartCoroutine("AttackMoveC");

                    StartCoroutine("AttackCollisionSet");


                    AttackGageSC.attack_slider_value = 0;
                    AttackGageSC.attack_gage_full = false;
                }

            }

        }

    }

    private IEnumerator AttackMoveC()
    {
        chara_skeletonanim.SetTrigger("attack_trigger");
        yield return new WaitForSeconds(1f);

        on_attack = false;
    }






    private void OnTriggerStay2D(Collider2D collision)
    {
        




    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        


    }

    void IsGround()
    {

    }

    private IEnumerator AttackCollisionSet()
    {
        AttackColliison.enabled = true;
        yield return new WaitForSeconds(1f);
        AttackColliison.enabled = false;

    }

    void TottukiMethod()
    {

        
        if (is_D) { 

            if (this_rigid2D.IsSleeping())
            {
                this_rigid2D.WakeUp();
            }

            TottukiColliison.enabled = true;


           
            //  jump_count = 0;

            // if(is_tottuki == true)
            //  {
            //      this_rigid2D.constraints = RigidbodyConstraints2D.FreezeAll;
            //  }


        }
        else
        {
            TottukiColliison.enabled = false;
        }
        


        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("koko2");
            jump_count = 0;
        }


        if (is_tottuki)
        {

            chara_skeletonanim.SetBool("run_bool",false);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

              //  Debug.Log("koko");
                if (jump_count < 1)
                {
                    jump_count += 1;

                    this_rigid2D.constraints = RigidbodyConstraints2D.None;
                    this_rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;

                    on_walljamp = true;

                    chara_skeletonanim.SetTrigger("jump_trigger");
                    this_rigid2D.velocity = new Vector2(0, 0);
                    this_rigid2D.AddForce(new Vector2(0, jump_speed * 110));


                    //jump_count = 0;
                }


            }


            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                is_D = false;
            }




        }
        

            
        


        
       /*
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {

            if (jump_count < 1)
            {
                jump_count += 1;
                on_walljamp = true;

                chara_skeletonanim.SetTrigger("jump_trigger");
                this_rigid2D.AddForce(new Vector2(0, chara_speed * 110));

                this_rigid2D.constraints = RigidbodyConstraints2D.None;
                this_rigid2D.constraints = RigidbodyConstraints2D.FreezeRotation;
                jump_count = 0;
            }


        }
        else
        {
            on_walljamp = false;
        }

    */
    }
    
}
