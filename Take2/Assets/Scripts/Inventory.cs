using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class Inventory : MonoBehaviour
{
    private Transform hand;
    private SpriteRenderer sr;
    private BaseWeapon heldWeapon;


    // Start is called before the first frame update
    void Start()
    {
        hand = transform.Find("Hand");
        sr = hand.gameObject.GetComponent<SpriteRenderer>();
        SwitchHeldWeapon(new TestWeapon());
        
    }


    void SwitchHeldWeapon(BaseWeapon weapon)
    {
        heldWeapon = weapon;
        sr.sprite = heldWeapon.sprite;
        
    }
    
    

    void UseHeldItem()
    {
        heldWeapon.useAnimation(hand);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UseHeldItem();
        }

        heldWeapon.update();
    }
}
