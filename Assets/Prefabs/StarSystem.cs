using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystem : MonoBehaviour
{
    public int size;
    public Color color;
    public Lehmer lehmer;
    public int x;
    public int y;
    private SpriteRenderer spriteRenderer;
    public uint systemSeed;
    public void resetSeed(){
        lehmer.setSeed( systemSeed );
    }

    void Start(){
        resetSeed();
        float scale = lehmer.randDouble(0.2f, 1.0f);
    
        transform.localScale = new Vector3(scale,scale,scale);

        spriteRenderer = GetComponent<SpriteRenderer>();
        color = lehmer.randColor();
        spriteRenderer.color = color;

    }
    void Update()
    {
        
    }
}
