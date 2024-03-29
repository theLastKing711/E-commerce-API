﻿using ECommerce.API.Dtos.AppUserDtos.Product;
using ECommerce.API.Dtos.Shared;
using ECommerce.API.Models;

namespace ECommerce.API.Helpers.PriceFilterStrategy
{
    public class LessThanPriceFilter : IPriceFilterStrategy
    {

        public IEnumerable<Product> filter(IEnumerable<Product> products, ProductFilter filter)
        {
            return products.Where(product => this.IsLessThan(product.Price, filter.EndValue));
        }


        private bool IsLessThan(decimal firstValue, decimal secondValue)
        {
            return firstValue < secondValue;
        }

    }
}
