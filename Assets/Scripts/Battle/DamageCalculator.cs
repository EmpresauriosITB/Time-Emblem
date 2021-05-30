using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator {

    public static int CalculateDamage(int Power, int Atack, int Defense, bool Burn) {

        double Damage = (((Power * ((Atack * 1.5) / Defense)) / 5 + 2)) + 1;
        return (int) Damage;
    }

    private static double CalculateModifier(bool Burn) {

        double Critical = 1;
        if (Random.Range(0, 50) > 45) { Critical = 1.5; }
        return Critical;
    }

    public static int CalculateHeal(int Power, int MentalPower) {
        return ((Power * MentalPower) / 100) + 1;
    }
}
