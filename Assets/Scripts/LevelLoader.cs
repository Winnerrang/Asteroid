using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();

        Enemy enemy1 = new Enemy();

        Enemy enemy2 = new Enemy();

        Weapon gun1 = new Weapon("Water Gun", 9f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
