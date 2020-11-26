using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveShadow : MonoBehaviour
{
    private Color shadow_color = new Color();
    private string color = "#A8A8A8";
    public float distance = .35f;

    // Will change after networking
    private Transform player;

    
    private GameObject shadow;

    private void Start()
    {
        Debug.Log("If null reference object, tag player object with Player");
        player = GameObject.FindWithTag("Player").transform;
        
        ColorUtility.TryParseHtmlString(color, out shadow_color);
        
        shadow = new GameObject("shadow");
        shadow.transform.SetParent(transform);
        
        shadow.transform.localScale=new Vector3(1,1,1);
        shadow.layer = LayerMask.NameToLayer("shadows");
        
        SpriteRenderer spriteRender = shadow.AddComponent<SpriteRenderer>();
        spriteRender.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spriteRender.sortingOrder = -10;
        spriteRender.color = shadow_color;



    }

    float getAngleOfPlayerRelativeToSelf(Vector3 selfpos)
    {
        float dy = (player.position.y - transform.position.y);
        float dx = (player.position.x - selfpos.x);
        float rad = Mathf.Atan2(dy, dx);

        return rad;
    }


    float getXpos(Vector3 pos)
    {
        float rad = getAngleOfPlayerRelativeToSelf(pos);
        float rx = -distance * Mathf.Cos(rad) * .5f;
        if (Mathf.Abs(rx) < 0.01)
        {
            rx = (Random.Range(0, 1) * 2 - 1)*.01f;

        }

        return rx;
    }

    float getAvgXpos()
    {
        float centerPoint = getXpos(transform.position);
        float leftPoint = getXpos(new Vector3(transform.position.x - transform.localScale.x/2,0));
        float rightPoint = getXpos(new Vector3(transform.position.x + transform.localScale.x/2,0));
        

        return (centerPoint + leftPoint*1.5f + rightPoint*1.5f)/3;
    }
    
    void Update()
    {
        
        shadow.transform.localPosition = new Vector3(getAvgXpos(),-.5f,0);
    }
}
