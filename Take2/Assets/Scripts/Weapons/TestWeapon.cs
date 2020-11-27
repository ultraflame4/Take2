using UnityEngine;

public class TestWeapon : BaseWeapon
{

    public TestWeapon()
    {
        sprite = Resources.Load <Sprite> ("Sprites/Diamond");

        useTime = 10;
        damage = 100;
        critChance = 1f;
        critMultiplier = 5f;
        range = 10f;
    }
}
