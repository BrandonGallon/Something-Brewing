using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    public static CraftingTable Instance;

    private Element first;
    private Element second;

    public Mixer mixer;

    private void Awake()
    {
        Instance = this;
    }

    public void AddElement(Element e)
    {
        // eerste slot leeg?
        if (first == null)
        {
            first = e;
            Debug.Log("First element: " + e.name);
            return;
        }

        // tweede slot leeg?
        if (second == null)
        {
            second = e;
            Debug.Log("Second element: " + e.name);

            MixNow();
        }
    }

    private void MixNow()
    {
        Potion result = Mixer.Mix();

        if (result != null)
        {
            Debug.Log("MIX RESULT: " + result.name);
        }
        else
        {
            Debug.Log("No valid recipe!");
        }

        // reset the table
        first = null;
        second = null;
    }
}
