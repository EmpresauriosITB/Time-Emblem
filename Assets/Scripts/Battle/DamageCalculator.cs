using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator {

    public static int CalculateDamage(int Power, int Atack, int Defense, bool Burn) {

        double Damage = ((Power * ((Atack * 1.5) / Defense)) / 5 + 2) * CalculateModifier(Burn);

        return (int) Damage;
    }

    private static double CalculateModifier(bool Burn) {

        double Critical = 1;
        if (Random.Range(0, 50) > 45) { Critical = 1.5; }

        double random = Random.Range(85, 100) / 100;
        double burn = 1;
        if (Burn) burn = 0.5;

        return Critical * random * burn;
    }
}
