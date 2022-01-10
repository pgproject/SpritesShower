using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CreateItem : MonoBehaviour
{
    private const float SIZE_OF_DELTA_X = 500;
    private const float SIZE_OF_DELTA_Y = 100;


    [SerializeField] private Item m_itemPrefab;
    [SerializeField] private RectTransform m_scrollViewContentRect;
    [SerializeField] private Scrollbar m_scrollbar;
    private List<string> m_itemsName = new List<string>();
    private List<Item> m_items = new List<Item>();

    private void Start()
    {
        RefreshItems();
        m_scrollbar.value = 1;
    }
    public void RefreshItems()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("");
        m_scrollViewContentRect.sizeDelta = new Vector2(SIZE_OF_DELTA_X, sprites.Length * SIZE_OF_DELTA_Y);

        for (int i = 0; i < m_items.Count; i++)
        {
            m_items[i].RefreshDateTime();
        }

        for (int i = 0; i < sprites.Length; i++)
        {
            if (m_itemsName.Contains(sprites[i].name)) continue;

            Item item = Instantiate(m_itemPrefab, transform);
            item.SetItemPriporties(sprites[i]);
            item.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * (-SIZE_OF_DELTA_Y));
            m_itemsName.Add(item.NameItem);
            m_items.Add(item);
        }
        m_scrollbar.value = 1;
    }
}
