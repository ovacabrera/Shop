using AutoMapper;
using Shop.Application.Automapper;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.DTOs;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.Application
{
    public class ItemApplication : IItemApplication
    {
        private IExternalService _externalService;
        private ILoggerService _logger;
        private readonly IItemDomain _domain;

        public ItemApplication(IExternalService externalService, ILoggerService logger)
        {
            _externalService = externalService;
            _logger = logger;
            _domain = new ItemDomain(externalService,logger);

            Mapper.Initialize(cfg => cfg.AddProfile<ServiceProfile>());
        }

        public ItemDTO GetItem(string itemId, ref string responseMessage)
        {
            var itemEntity = _domain.GetItem(itemId, ref responseMessage);
            return itemEntity != null ? Mapper.Map<ItemDTO>(itemEntity) : null;
        }

        public SearchResultDTO SearchItems(string filter, int? offset, int? limit, ref string responseMessage)
        {
            var searchResult = _domain.SearchItems(filter, offset, limit, ref responseMessage);
            return searchResult != null ? Mapper.Map<SearchResultDTO>(searchResult) : null;
        }
    }
}
