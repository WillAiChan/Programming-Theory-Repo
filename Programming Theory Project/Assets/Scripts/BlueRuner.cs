using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BlueRuner : PlayerController
{
    private void Awake()
    {
        jumpPower = 10;
        color = Color.blue;
    }

    // POLYMORPHISM
    protected override void DisplayInfo()
    {
        print("BuleRuner! Jump power up.");
    }

    protected override void SwitchPower()
    {
        gameObject.AddComponent<PlayerController>();
        Destroy(GetComponent<BlueRuner>());
    }
}
