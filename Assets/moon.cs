using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Sprite newSprite;
    void Start()
    {
        newSprite = sprites[Random.Range(0, 1)];
        spriteRenderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(4f * Time.deltaTime, 0, 0);

        if(transform.position.x <= -12){
            Destroy(this.gameObject);
        }
    }
}
