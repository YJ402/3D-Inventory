using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "newCharacter", menuName = "Character")]
public class CharacterSO : ScriptableObject
{
    [field: SerializeField] public float AttackPower { get; private set; }
    [field: SerializeField] public float Defense { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float Critical { get; private set; }
}
