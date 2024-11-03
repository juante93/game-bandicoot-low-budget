using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboPlayer : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    private int totalAttacks = 0;
    private bool canIAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            startCombo();
        }
    }

    private void startCombo()
    {
        if (canIAttack)
        {
            totalAttacks += 1;
        }
        if (totalAttacks == 1) {
            anim.SetInteger("firstAttack", 1);
        }
        if (totalAttacks == 2) {
            anim.SetInteger("SecondAttack", 2);
        }
        if (totalAttacks == 3) {
            anim.SetInteger("thirdAttack", 3);
            totalAttacks = 0;
        }
    }
}
