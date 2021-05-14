using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator {

    public int CalculateDamage(int Level, int Power, int Atack, int Defense, bool Burn) {

        double Damage = ((((2 * Level) / 5) * Power * (Atack / Defense)) / 50 + 2) * CalculateModifier(Burn);

        return (int) Damage;
    }

    private double CalculateModifier(bool Burn) {

        double Critical = 1;
        if (Random.Range(0, 50) > 45) { Critical = 1.5; }

        double random = Random.Range(85, 100) / 100;
        double burn = 1;
        if (Burn) burn = 0.5;

        return Critical * random * burn;
    }
}
