using UnityEngine;
using UnityEngine.UI;

public class Item
{
	public string id;
	public string count;
}
public class GridControl : MonoBehaviour
{
	public Text count;
	public Image image;

	//设置格子数据
	public void setItem(Item item)
	{
		count.enabled = true;
		image.enabled = true;
		count.text = item.count + "";
		ItemData itemData = ItemManager.Instance.GetItemById(item.id);
		image.sprite = Resources.Load<Sprite>(itemData.image);
	}
}
