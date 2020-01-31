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
    public int temperature;
    private SpriteRenderer spriteRenderer;
    public uint systemSeed;
    public void resetSeed()
    {
        lehmer.setSeed(systemSeed);
    }

    void Start()
    {
        resetSeed();
        float scale = lehmer.randDouble(0.2f, 1.0f);

        transform.localScale = new Vector3(scale, scale, scale);

        spriteRenderer = GetComponent<SpriteRenderer>();
        temperature = lehmer.randInt(1000, 40000);

        color = tempToCol(temperature);
        spriteRenderer.color = color;

    }
    void Update()
    {

    }

    Color tempToCol(int temp)
    {
        temp /= 100;

        //RED
        float red;
        if (temp <= 66)
            red = 255;
        else
        {
            red = temp - 60;
            red = 329.698727446f * (Mathf.Pow(red, -0.1332047592f));
            red = red > 255 ? 255 : red;
        }

        //GREEN
        float green;
        if(temp <= 66){
            green = temp;
            green = 99.4708025861f * Mathf.Log(green) - 161.1195681661f;
            green = green > 255 ? 255 : green;
        } else {
            green = temp - 60;
            green = 288.1221695283f * (Mathf.Pow(green, -0.0755148492f));
            green = green > 255 ? 255 : green;
        }

        //BLUE
        float blue;
        if(temp >= 66)
            blue = 255;
        else{
            if(temp < 19)
                blue = 0;
            else{
                blue = temp - 10;
                blue = 138.5177312231f * Mathf.Log(blue) - 305.0447927307f;
                blue = blue > 255 ? 255 : blue;
            }
        }

        return new Color(red/255, green/255, blue/255);
    }
}
