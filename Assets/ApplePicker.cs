using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    private void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGo.transform.position = pos;
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        // Find all of the baskets
        int BasketIndex = basketList.Count - 1;
        // get reference to that gameobject
        GameObject basketGo = basketList[BasketIndex];
        // remove the basket from the list and destroy the gameobject
        basketList.RemoveAt(BasketIndex);
        Destroy(basketGo);
     
        // If there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("_Scene_0");
        }
    }
    private void Update()
    {

    }
}