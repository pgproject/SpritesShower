using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private Item m_itemPrefab;
    [SerializeField] private RectTransform m_scrollViewContentRect;
    private void Start()
    {
        RefreshItems();
    }
    public void RefreshItems()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("");
        m_scrollViewContentRect.sizeDelta = new Vector2(500, sprites.Length * 100);
        for (int i = 0; i < sprites.Length; i++)
        {
            Item item = Instantiate(m_itemPrefab, transform);
            item.SetItemPriporties(sprites[i]);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * (-100));
        }
    }    
}
