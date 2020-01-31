using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lehmer 
{
    private uint seed;
    public Lehmer()
    {
        seed = 0;
    }

    public void setSeed(uint newSeed){
        seed = newSeed;
    }
    public uint getSeed(){
        return seed;
    }

    public uint rand()
    {
        seed += 0x120fc15;
        ulong tmp;
        tmp = (ulong)seed * 0x4a39b70d;
        uint m1 = (uint)(tmp >> 32) ^ (uint)tmp;
        tmp = (ulong)m1 * 0x12fad5c9;
        uint m2 = (uint)(tmp >> 32) ^ (uint)tmp;
        return m2;
    }

    public float randDouble(float min, float max)
	{
		return ((float)rand() / (0xFFFFFFFF)) * (max - min) + min;
	}

	public int randInt(int min, int max)
	{
		return ((int)rand() % (max - min)) + min;
	}
    
    public Color randColor(){
        float R = randDouble(0.0f,1.0f);
        float G = randDouble(0.0f,1.0f);
        float B = randDouble(0.0f,1.0f);
        return new Color(R,G,B);
    }
}
