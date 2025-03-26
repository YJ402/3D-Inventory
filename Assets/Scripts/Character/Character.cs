using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterSO characterData;

    public CharacterEquip characterEquip;

    public CharacterStatus characterStatus;

    private void Awake()
    {
        characterEquip = GetComponent<CharacterEquip>();
        characterStatus = GetComponent<CharacterStatus>();

        characterEquip.Init(this);
        characterStatus.Init(characterData);
    }

    private void Start()
    {

    }
}
