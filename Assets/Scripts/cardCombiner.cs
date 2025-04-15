using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardCombiner : MonoBehaviour
{
    public Transform cardADN; 
    public Transform cardVirus; 
    public Transform cardMedicina; 

    public GameObject adn;
    public GameObject virus;
    public GameObject medicina;

    public GameObject prefabADN_Virus; 
    public GameObject prefabADN_Medicina; 
    public GameObject prefabVirus_Medicina; 

    public float combineDistance = 2f; 
    private bool hasCombined = false; 

    void Update()
    {
        if (!hasCombined)
        {
            CheckAndCombine(cardADN, cardVirus, prefabADN_Virus, adn, virus);
            CheckAndCombine(cardADN, cardMedicina, prefabADN_Medicina, adn, medicina);
            CheckAndCombine(cardVirus, cardMedicina, prefabVirus_Medicina, virus, medicina);
        }
    }

    void CheckAndCombine(Transform card1, Transform card2, GameObject resultPrefab, GameObject go1, GameObject go2)
    {
        if (card1 != null && card2 != null && go1.activeInHierarchy && go2.activeInHierarchy)
        {
            float distance = Vector3.Distance(card1.position, card2.position);
            if (distance < combineDistance)
            {
                CombineElements(card1, card2, resultPrefab);
            }
        }
    }

    void CombineElements(Transform card1, Transform card2, GameObject resultPrefab)
    {
        Debug.Log("COMNBINE");
        hasCombined = true;

        Vector3 combinePosition = (card1.position + card2.position) / 2;
        resultPrefab.transform.position = combinePosition;
        resultPrefab.SetActive(true);

        card1.gameObject.SetActive(false);
        card2.gameObject.SetActive(false);
    }
}
