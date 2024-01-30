using System;
using System.Collections;
using System.Collections.Generic;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemController : ControllerBase
    {
        private readonly IItemsRepository _repository;

        public ItemController(IItemsRepository repository)
        {
            _repository = repository;
        }

        // GET /items
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _repository.GetItems();
            return items;
        }

        //GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItems(Guid id)
        {
            var item = _repository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}