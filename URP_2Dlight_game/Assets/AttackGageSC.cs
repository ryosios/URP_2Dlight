using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackGageSC : MonoBehaviour
{
    [SerializeField]
    GameObject UI_haguruma;

    [SerializeField]
    Slider AttackSlider;

    

    public float attack_slider_value { get; set; } 
    float attack_slider_value_speed = 0.7f;

    public bool attack_gage_full { get; set; }


    float rotation_speed = 100f;

    

    // Start is called before the first frame update
    void Start()
    {
        attack_slider_value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SliderValue();

       

        if (attack_gage_full == false)
        {
            HagurumaRotation();
        }


        
    }

    void HagurumaRotation()
    {

        UI_haguruma.transform.Rotate(0.0f, 0.0f, rotation_speed*Time.deltaTime);
        
    }

    void SliderValue()
    {
        if(attack_slider_value <= 1)
        {
            attack_slider_value += attack_slider_value_speed * Time.deltaTime;
            AttackSlider.value = attack_slider_value;
           // attack_gage_full = false;

        }
        else 
        {
            attack_slider_value = 1;
            attack_gage_full = true;


        }


    }
}
