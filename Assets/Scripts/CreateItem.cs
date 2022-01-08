using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private Item m_itemPrefab;
    void Start()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("");
        for (int i = 0; i < sprites.Length; i++)
        {
            Item item = Instantiate(m_itemPrefab, transform);
            item.SetItemPriporties(sprites[i]);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * (-100));
            //item.GetComponent<RectTransform>().SetPositionAndRotation( Camera.main.ScreenToWorldPoint(new Vector2(/*600*/0, i * (-100))), Quaternion.identity);
        }
    }
}
