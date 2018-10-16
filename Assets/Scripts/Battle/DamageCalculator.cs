public static class DamageCalculator {

    public static int CalculateDamage(int level, int power, int attack, int defense)
    {
        // Taken from bulbapedia
        int damage = (((2 * level / 5) + 2 ) * power * attack / defense) / 50 + 2;

        return damage;
    }

}
