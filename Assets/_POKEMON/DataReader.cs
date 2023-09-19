using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MyLinq
{
    public static void DestroyAllChild(this GameObject @this)
    {
        foreach (Transform child in @this.transform)
        {
            GameObject.Destroy(child);
        }
    }
    public static IEnumerable<int> WhereMajeur (this IEnumerable<int> @this)
    {
        foreach(var el in @this)
        {
            if (el < 18) continue;
            else yield return el;
        }
    }
    public static IEnumerable<int> WhereMajeur (this IEnumerable<int> @this, Func<int, bool> strategy)
    {
        foreach (int el in @this)
        {
            if (strategy.Invoke(el)) yield return el;
        }
    }
}

public class DataReader : MonoBehaviour
{
    void coucou()
    {
        List<int> data = new() { 12, 25, 28, 0, -12, 36, 42 };
        data.WhereMajeur(Filter);
        data.WhereMajeur(i => i > 18);


        (string, int) monCharacter = ("Kevin", 42);
        (int atk, int def, int vit, float, int) coucou;

    }
    struct Character
    {
        public string name;
        public int age;
    }
    bool Filter(int test)
    {
        if (test < 18) return false;
        else return true;
    }

    [SerializeField] TextAsset _pokemonFile;
    [SerializeField] TextAsset _itemFile;
    [SerializeField] TextAsset _movesFile;
    [SerializeField] TextAsset _typeFile;

    public DataReader Init()
    {
#if UNITY_EDITOR
        _pokemonFile ??= Resources.Load<TextAsset>("Pokemon");
        _itemFile   ??= Resources.Load<TextAsset>("Items");
        _movesFile  ??= Resources.Load<TextAsset>("Moves");
        _typeFile   ??= Resources.Load<TextAsset>("Types");
#endif
        return this;
    }

    public T ReadData<T>(TextAsset content) 
        => JsonUtility.FromJson<T>(content.text);   

    public IEnumerable<Pokemon> GetPokemons()
        => ReadData<PokemonData>(_pokemonFile).pokemons;


    public Pokemon GetPokemonById(int id)
        => GetPokemons().First(pokemon => pokemon.id == id);

    public IEnumerable<Pokemon> PokemonByType(string type)
        => GetPokemons().Where(pokemon => pokemon.type.Contains(type));

    public List<int> GetTopPokemonByBasePower(int count)
        => GetPokemons()
            .OrderByDescending(pokemon => pokemon.statbase.BasePower)
            .Select(pokemon => pokemon.id)
            .Take(count)
            .ToList();

    public List<int> GetDownPokemonByBasePower(int count)
        => GetPokemons()
            .OrderBy(pokemon => pokemon.statbase.BasePower)
            .Select(pokemon => pokemon.id)
            .Take(count)
            .ToList();

    public int GetPokemonPowerById(int id)
        => GetPokemonById(id).statbase.BasePower;

    public IEnumerable<(int id, int power)> DecoratePokemonIdWithPower(IEnumerable<int> ids)
        => GetPokemons()
            .Where(pokemon => ids.Contains(pokemon.id))
            .Select(pokemon => (pokemon.id, pokemon.statbase.BasePower));
}
