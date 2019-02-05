using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster {

    [SerializeField]
    private int lives = 6;

    public int Lives
    {
        get { return lives; }
        set
        {
            if (value <= 6) lives = value;
        }
    }

    public override void ReceiveDamage()
    {
        Lives--;

        if (lives <= 0)
        {
            Die();
        }
    }


    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        Character unit = collider.GetComponent<Character>();

        if (unit)
        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 1)
            {
                ReceiveDamage();
            }
            else unit.ReceiveDamage();
        }
    }
}
