using System;
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

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List() => View(_repository.Products); //упрощение конструкции вызова представления

    }
}
