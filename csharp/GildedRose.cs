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

        public bool isOverMaxValue(int quality) => quality >= 50 ? false : true;

        public void UpdateQuality()
        {
            foreach (var Item in Items)
            {
                if (Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Item.Quality > 0)
                    {
                        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
                        if (Item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            if (Item.Name == "Conjured Mana Cake")
                            {
                                Item.Quality = Item.Quality - 2;
                            }
                            else
                            {
                                Item.Quality--;
                            }
                        }
                    }
                }
                else
                {
                    if (isOverMaxValue(Item.Quality))
                    {
                        Item.Quality++;
                        /*
                        "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
	                    Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
	                    Quality drops to 0 after the concert
                        */
                        if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Item.SellIn < 11)
                            {
                                if (isOverMaxValue(Item.Quality))
                                {
                                    Item.Quality++;
                                }
                            }

                            if (Item.SellIn < 6)
                            {
                                //The Quality of an item is never more than 50
                                if (isOverMaxValue(Item.Quality))
                                {
                                    Item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (Item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    Item.SellIn--;
                }

                //Once the sell by date has passed, Quality degrades twice as fast
                if (Item.SellIn < 0)
                {
                    if (Item.Name != "Aged Brie")
                    {
                        if (Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            //The Quality of an item is never negative
                            if (Item.Quality > 0)
                            {
                                if (Item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            Item.Quality = Item.Quality - Item.Quality;
                        }
                    }
                    else //"Aged Brie" actually increases in Quality the older it gets
                    {
                        //The Quality of an item is never more than 50
                        if (isOverMaxValue(Item.Quality))
                        {
                            Item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
