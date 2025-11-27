using UnityEngine;
using System.Linq;
using System;

public class Mixer : MonoBehaviour
{
    public Recept[] recipes;

    internal static Potion Mix()
    {
        throw new NotImplementedException();
    }

    public Potion Mix(Element[] inputElements)
    {
        // haal lege slots uit de combinatie
        var elements = inputElements.Where(e => e != null).ToArray();

        foreach (var recipe in recipes)
        {
            var req = recipe.requiredElements;

            // als aantal niet voldoet aan de benodigdheden kan het niet matchen
            if (req.Length != elements.Length)
                continue;

            bool match = !req.Except(elements).Any() && !elements.Except(req).Any();

            if (match)
                return recipe.result;
        }

        return null;
    }
}
