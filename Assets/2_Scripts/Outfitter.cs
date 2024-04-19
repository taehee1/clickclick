using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType charType;

    private enum CharacterType
    {
        Ork, Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            charType = charType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOutfit();
        }
    }

    private void ChangeOutfit()
    {
        foreach (SpriteResolver resolver in resolvers)
        {
            Debug.Log($" cate : {resolver.GetCategory()} char : {charType.ToString()}");

            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());
            if (resolver.GetCategory() != "Weapon")
            {
                //resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            //Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            //Debug.Log($"sprite : " + sprite);
        }
    }
}
