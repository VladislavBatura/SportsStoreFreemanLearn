﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.Interfaces;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _repository; //внедряем зависимость для упрощения дальнейшей работы с бд
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(int productPage = 1) => View(_repository.Products
            .OrderBy(p => p.ProductId)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize)); //упрощение конструкции вызова представления

    }
}
