using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField]Color color;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void UpdateAlpha()
    {
        if(spriteRenderer != null)
        {
            color = spriteRenderer.color;
            color.a = (GameManager.Instance.DoorHealth / 100f);
            //Debug.Log("Door Health Should be : "+GameManager.Instance.DoorHealth/100f);
            spriteRenderer.color = color;
        }
    }
}
