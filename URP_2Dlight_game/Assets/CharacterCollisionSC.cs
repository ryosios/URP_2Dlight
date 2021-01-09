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

    private void OnCollisionStay2D(Collision2D collision)
    {

        

        CharacterControllerSC. is_ground = true;





    }
    private void OnCollisionExit2D(Collision2D collision)
    {


        CharacterControllerSC.is_ground = false;
        CharacterControllerSC.jump_count = 0;


    }
}
