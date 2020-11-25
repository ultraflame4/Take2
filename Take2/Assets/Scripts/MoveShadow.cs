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
        
        SpriteRenderer spriteRender = shadow.AddComponent<SpriteRenderer>();
        spriteRender.sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        spriteRender.sortingOrder = -10;
        spriteRender.color = shadow_color;



    }

    float getAngleOfPlayerRelativeToSelf()
    {
        float dy = (player.position.y - transform.position.y);
        float dx = (player.position.x - transform.position.x);
        float rad = Mathf.Atan2(dy, dx);

        return rad;
    }
    
    void Update()
    {
        float rad = getAngleOfPlayerRelativeToSelf();
        float rx = -distance * Mathf.Cos(rad) * .5f;
        if (Mathf.Abs(rx) < 0.01)
        {
            rx = (Random.Range(0, 1) * 2 - 1)*.01f;

        }
        shadow.transform.localPosition = new Vector3(rx,-.5f,0);
    }
}
