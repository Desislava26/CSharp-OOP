
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IByer
    {
        void BuyFood();
        int Food { get;}
        string Name { get;}
    }
}
