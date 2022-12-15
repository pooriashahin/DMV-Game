using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDB : ScriptableObject
{
    public Character[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
        }
    }

    public Character getCharacter(int index)
    {
        return character[index];
    }
}
