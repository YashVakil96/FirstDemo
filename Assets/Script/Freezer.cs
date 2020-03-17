using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public float duration;
    bool isFrozen = false;
    float pendingFreezeDuration = 0f;

    //private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingFreezeDuration > 0 && !isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }
    public  void Freeze()
    {
        pendingFreezeDuration = duration;
    }

    IEnumerator DoFreeze()
    {
        //anim.SetBool("IsDead", true);
        //Debug.Log("IsRunning");
        isFrozen = true;
        var original = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = original;
        pendingFreezeDuration = 0;
        isFrozen = false;


    }
}