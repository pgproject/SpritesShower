using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private Item m_itemPrefab;
    [SerializeField] private RectTransform m_scrollViewContentRect;

    private List<string> m_itemsName = new List<string>();
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
            if (m_itemsName.Contains(sprites[i].name)) continue;

            Item item = Instantiate(m_itemPrefab, transform);
            item.SetItemPriporties(sprites[i]);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * (-100));
            m_itemsName.Add(item.NameItem);
        }
    }
}
