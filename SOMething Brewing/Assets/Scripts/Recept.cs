using UnityEngine;
[CreateAssetMenu(menuName = "Alchemy/Recipe")]

public class Recept : ScriptableObject
{
    public Element elementA; //Oxygen
    public Element elementB; //Hydrogen
    public Element elementC; //Nitrogen
    public Element elementD; //Helium
    public Element elementE; //Carbon
    public Element elementF; //Uranium
    public Element elementG; //Plutonium
    public Element elementH; //Phosphorus
    public Element elementI; //Fluorine

    public Potion result;
    public Element[] requiredElements;

}
