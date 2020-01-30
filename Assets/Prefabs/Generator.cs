using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    private int sectorsX = Screen.width / 16;
    private int sectorsY = Screen.height / 16;
    private Lehmer lehmer = new Lehmer();
    public GameObject starSystem;
    public Vector2 screenPos;


    // Start is called before the first frame update
    void Start()
    {
        screenPos = new Vector2(0.0f,0.0f);
        genGalaxy();
        Debug.Log(Screen.width + " " + Screen.height);


    }

    void genGalaxy(){

        for (int x = -sectorsX/2; x < sectorsX/2; x++)
        {
            for (int y = -sectorsY/2; y < sectorsY/2; y++)
            {
                lehmer.setSeed((((uint)(x + screenPos.x) & 0xFFFF) << 16) | ((uint)(y+screenPos.y) & 0xFFFF));
                if (lehmer.rand() % 256 < 32)
                    genStarSystem(x,y, lehmer.getSeed());
            }
        }
    }

    public StarSystem genStarSystem(int x, int y, uint seed)
    {
        GameObject newObject = Instantiate(starSystem, new Vector3(x,y,0),Quaternion.identity) as GameObject;
        StarSystem yourObject = newObject.GetComponent<StarSystem>();
        yourObject.x = x;
        yourObject.y = y;
        yourObject.lehmer = lehmer;
        yourObject.systemSeed = seed;
        return yourObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horScroll = Input.GetAxisRaw("Horizontal");
        float verSCroll = Input.GetAxisRaw("Vertical");

        if(horScroll != 0 || verSCroll != 0){
            GameObject[] a = GameObject.FindGameObjectsWithTag("StarSystem");
            foreach(GameObject g in  a ){
                Destroy(g);
            }
            screenPos.x += horScroll;
            screenPos.y += verSCroll;
            genGalaxy();
        }
    }
}
