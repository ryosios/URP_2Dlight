using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionSC : MonoBehaviour
{

    [SerializeField]
    CharacterController CharacterControllerSC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(CharacterControllerSC.is_ground);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("koko");

        CharacterControllerSC.is_ground = true;
        CharacterControllerSC.jump_count = 0;




    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        

        Debug.Log(collision.contacts[0].normal);
        CharacterControllerSC.sakamiti_normal_vector = collision.contacts[0].normal;
        CharacterControllerSC. is_ground = true;
        CharacterControllerSC.jump_count = 0;




    }
    private void OnCollisionExit2D(Collision2D collision)
    {


        CharacterControllerSC.is_ground = false;
        CharacterControllerSC.jump_count = 0;


    }
}
