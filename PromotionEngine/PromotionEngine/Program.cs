﻿namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            IPromotionEngine engine = new PromotionEngineCore();
            engine.CalculatePrice();
        }
    }
}
