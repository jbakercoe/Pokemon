public static class EnemyPokemonAI {

    public static MoveObject GetMove(BattlePokemon pokemon)
    {
        // Picks the enemy pokemon's move
        return pokemon.Pokemon.Moves[0];
        //pokemon.Attack(pokemon.Pokemon.Moves[0]);

    }

}
