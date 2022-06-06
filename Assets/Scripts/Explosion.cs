using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().volume = Game.svol * 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            Destroy(gameObject);
    }
}
