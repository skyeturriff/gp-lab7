using UnityEngine;
using System.Collections.Generic;

public class InfectTooth : MonoBehaviour 
{
    public List<GameObject> teeth;
    public Color infectionColor;

    // Time between when next tooth is chosen for infection
    public float nextInfectionDelay = 1.0f;
    private float elapsedTime = 0.0f;
    private bool allInfectedTeeth = false;

    void start()
    {
        // Store transforms of the teeth so that we can spawn new teeth in same location

    }

	void Update () 
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= nextInfectionDelay)
        {
            elapsedTime = 0.0f;
            InfectTheTooth();
        }
	}

    public void InfectTheTooth()
    {
        if (teeth.Count > 0)
        {
            // How many teeth we've tried to infect
            for (int attemptedToothCount = 0; attemptedToothCount < teeth.Count; attemptedToothCount++)
            {
                // Get a random tooth
                int index = Random.Range(0, teeth.Count);
                GameObject selectedTooth = teeth[index];

                // Attach infection to the randomly selected tooth (if not already infected)
                if (selectedTooth.GetComponent<Infection>() == null)
                {
                    Infection newInfection = selectedTooth.AddComponent<Infection>();
                    newInfection.infectedColor = infectionColor;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    public void RemoveTooth(GameObject toothToRemove) 
    {
        if (teeth.Contains(toothToRemove))
        {
            // Do it this way so as not to change the size of our array
            int toothIndex = teeth.IndexOf(toothToRemove);
            teeth[toothIndex] = null;
        }

    }

    public void SpawnTooth()
    {
        for (int toothIndex = 0; toothIndex < teeth.Count; toothIndex++)
        {
            // Spawn tooth if there is not one there
            if (teeth[toothIndex] == null)
            {
                 // Spawn toothe here
            }
        }
    }
}
