using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public bool isNotOverMaxQuality(int quality) => quality >= 50 ? false : true;


        public void UpdateQuality()
        {
            foreach (var Item in Items)
            {
                switch (Item.Name)
                {
                    case "Aged Brie":
                        UpdateAgedBrie(Item);
                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":
                        UpdateBackstagePasses(Item);
                        break;

                    case "Conjured Mana Cake":
                        UpdateConjured(Item);
                        break;

                    case "Sulfuras, Hand of Ragnaros":
                        break;

                    default:
                        UpdateNormalItem(Item);
                        break;
                }
            }
        }

        public void UpdateAgedBrie(Item item)
        {
            if (isNotOverMaxQuality(item.Quality))
            {
                item.Quality++;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            item.SellIn--;
        }

        public void UpdateBackstagePasses(Item item)
        {
            if (item.SellIn < 11)
            {
                if (item.SellIn < 6)
                {
                    if (isNotOverMaxQuality(item.Quality))
                    {
                        item.Quality = item.Quality + 3;
                    }
                }
                else
                {
                    if (isNotOverMaxQuality(item.Quality))
                    {
                        item.Quality = item.Quality + 2;
                    }
                }
            }

            if (item.SellIn < 1)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
            item.SellIn--;
        }

        public void UpdateConjured(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - 4;
                }
                else
                {
                    item.Quality = item.Quality - 2;
                }
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

        public void UpdateNormalItem(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.SellIn < 0)
                {
                    item.Quality = item.Quality - 2;
                }
                else
                {
                    item.Quality--;
                }
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            item.SellIn--;
        }

    }
}
