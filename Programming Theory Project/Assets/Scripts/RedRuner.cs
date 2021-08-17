using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RedRuner : PlayerController
{
    private void Awake()
    {
        speed = 700;
        color = Color.red;
    }

    // POLYMORPHISM
    protected override void DisplayInfo()
    {
        print("RedRuner! Speed power up.");
    }

    protected override void SwitchPower()
    {
        gameObject.AddComponent<BlueRuner>();
        Destroy(GetComponent<RedRuner>());
    }
}
