using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Model;

namespace Worker.Data
{
    public class FoodData
    {
        public List<Food> _foodData = new List<Food>();

        public FoodData()
        {
            addFood();
        }

        public void addFood()
        {
            for(int i = 1; i<11; i++)
            {
                _foodData.Add(new Food
                {
                    ID = i,
                    Name = "Food:" + i,
                    Price = 10 * i
                });
            }
        }
    }
}
