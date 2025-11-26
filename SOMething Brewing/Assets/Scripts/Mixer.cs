using System;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public Recept[] recepts;

    internal static Potion Mix()
    {
        throw new NotImplementedException();
    }

    public Potion Mix(Element a, Element b, Element c, Element d, Element e, Element f, Element g, Element h, Element i)
    {
        foreach (var recipe in recepts)
        {
            bool match1 = (recipe.elementA == a && recipe.elementB == b); //SmokeBomb
            bool match2 = (recipe.elementA == b && recipe.elementB == a); //SmokeBomb
            bool match3 = (recipe.elementA == a && recipe.elementH == h); //Fire
            bool match4 = (recipe.elementA == h && recipe.elementH == a); //Fire
            bool match5 = (recipe.elementC == i && recipe.elementI == c); //Frostbite
            bool match6 = (recipe.elementC == c && recipe.elementI == i); //Frostbite
            bool match7 = (recipe.elementB == b && recipe.elementD == d); //Fling
            bool match8 = (recipe.elementB == d && recipe.elementD == b); //Fling
            bool match9 = (recipe.elementA == a && recipe.elementB == b && recipe.elementE == e); // Explosion
            bool match10 = (recipe.elementA == b && recipe.elementB == e && recipe.elementE == a); // Explosion
            bool match11= (recipe.elementA == e && recipe.elementB == a && recipe.elementE == b); // Explosion
            bool match12 = (recipe.elementA == a && recipe.elementB == b && recipe.elementC == c && recipe.elementE == e); //Acid
            bool match13= (recipe.elementA == b && recipe.elementB == c && recipe.elementC == e && recipe.elementE == a); //Acid
            bool match14 = (recipe.elementA == c && recipe.elementB == e && recipe.elementC == a && recipe.elementE == b); //Acid
            bool match15 = (recipe.elementA == e && recipe.elementB == a && recipe.elementC == b && recipe.elementE == c); //Acid
            bool match16 = (recipe.elementB == b && recipe.elementE == e && recipe.elementF == f && recipe.elementG == g); //NuclearRadiation
            bool match17 = (recipe.elementB == e && recipe.elementE == f && recipe.elementF == g && recipe.elementG == b); //NuclearRadiation
            bool match18 = (recipe.elementB == f && recipe.elementE == g && recipe.elementF == b && recipe.elementG == e); //NuclearRadiation
            bool match19 = (recipe.elementB == g && recipe.elementE == b && recipe.elementF == e && recipe.elementG == f); //NuclearRadiation

            if (match1 || match2)
                return recipe.result; // zet SmokeBomb prefab in unity
            if (match3 || match4)
                return recipe.result; // zet Fire prefab in unity
            if (match5 || match6)
                return recipe.result;// zet Frostbite prefab in unity
            if (match7 || match8)
                return recipe.result;// zet Fling prefab in unity
            if (match9 || match10 || match11)
                return recipe.result;// zet Explosion prefab in unity
            if (match12 || match13 || match14 || match15)
                return recipe.result;// zet Acid prefab in unity
            if (match16 || match17 || match18 || match19)
                return recipe.result;// zet NuclearPotion prefab in unity
        }

        return null; 
    }
}
