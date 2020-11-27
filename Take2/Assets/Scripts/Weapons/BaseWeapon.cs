using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon
{
    public Sprite sprite;
    public int useTime;
    public int damage;
    public float critChance;
    public float critMultiplier;
    public float range;

    private bool rotating = false;
    private Transform rotaTransform;
    private int counter;
    
    public virtual void useAnimation(Transform body)
    {
        rotating = true;
        rotaTransform = body;
        counter = useTime;
    }


    public void update()
    {
        if (rotating && rotaTransform != null && counter > 0)
        {
            rotaTransform.Rotate(0,0, (360 / useTime));
            counter--;
        }
    }
}
