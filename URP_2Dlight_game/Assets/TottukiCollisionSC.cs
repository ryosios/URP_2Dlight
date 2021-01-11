using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TottukiCollisionSC : MonoBehaviour
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
        
    }
    private void OnTriggerEnter2D( Collider2D collision)
    {

        

        if (collision.gameObject.layer == 14)
        {
            
                CharacterControllerSC.is_tottuki = true;
            CharacterControllerSC.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            CharacterControllerSC.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY| RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
            

           


        }





    }
   

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            CharacterControllerSC.is_tottuki = false;
            CharacterControllerSC.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            CharacterControllerSC.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


        }
    }

}
