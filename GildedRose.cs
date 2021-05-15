using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        // There are few types of items: Standart, Legendary, Conjured,
        // Aged Brie, Back Stage Pass. We should make these items into classes
        // which implement Standart item type. Our base class should implement
        // a method that compares it's "SellIn", "Quality" values. It should also
        // implement a method which recognizes the type of item and returns it to it's
        // class instance. To do this I would need to change the "Item" class which is prohibited.
        // My solution was to restructure if statment, remove duplication,
        // make statement flow understandable, readable.
        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                // My process
                // 1. Inverting negative if's for readability.
                // 2. Changing if's conditions from !A && !B to A || B.
                // 3. Extracted "Sulfuras" statment cause, it doesn't do anything.
                // 4. Trying to remove name duplication as much as possible.
                // 5. Middle "ItemSellIn" statement gave a door to remove such duplications.
                // 6. Combing if statements, and defining flow of statements "Name -> Quality -> SellIn".
                // Results: 89 lines -> 80 lines, readability, and all tests pass.

                if (item.Name == "Sulfuras, Hand of Ragnaros")
                    continue;
                if (item.Name == "Aged Brie")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (item.Quality < 50 && item.SellIn < 1)
                    {
                        item.Quality++;
                    }
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (item.Quality < 50 && item.SellIn < 11)
                    {
                        item.Quality++;
                    }
                    if (item.Quality < 50 && item.SellIn < 6)
                    {
                        item.Quality++;
                    }
                    if (item.SellIn < 1)
                        item.Quality -= item.Quality;
                }
                else
                {
                    if (item.Quality > 0)
                    {
                        item.Quality--;
                    }
                    if (item.Quality > 0 && item.SellIn < 1)
                    {
                        item.Quality--;
                    }
                }
                item.SellIn--;

            }
        }
    }
}
