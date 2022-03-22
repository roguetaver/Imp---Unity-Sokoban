using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButtonScript : MonoBehaviour
{
    public LayerMask acionantes;
    private Collider2D hasSomethingOnIt;
    public GameObject portaA;
    public GameObject portaB;
    public bool done1;
    public bool done2;
    private AudioSource audioS;

    void Start()
    {
        portaA.SetActive(true);
        portaB.SetActive(false);
        audioS = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        hasSomethingOnIt = Physics2D.OverlapCircle(this.transform.position, .2f , acionantes);

        if(hasSomethingOnIt && !done1){
            audioS.Play();
            portaA.SetActive(!portaA.activeSelf);
            portaB.SetActive(!portaB.activeSelf);
            done1 = true;
            done2 = false;
        }
        else if (!hasSomethingOnIt && !done2){         
            portaA.SetActive(!portaA.activeSelf);
            portaB.SetActive(!portaB.activeSelf);
            done1 = false;
            done2 = true;
        }
    }
}
