using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FindWildPokemon {

    public static bool CheckForWildPokemon(float appearRate)
    {
        float n = Random.Range(0f, 1f);
        return (n < appearRate);
    }

    public static Rarity DetermineRarity()
    {
        // Check for which rarity to find

        float n = Random.Range(0f, 100f);

        if(n < 4f)
        {
            // Very Rare
            return Rarity.VeryRare;
        } else if(n < 13f)
        {
            // Rare
            return Rarity.Rare;
        } else if(n < 32f)
        {
            // Semi Rare
            return Rarity.Semirare;
        } else if(n < 61f)
        {
            // Common
            return Rarity.Common;
        } else
        {
            // Very Common
            return Rarity.VeryCommon;
        }
    }
    
}
