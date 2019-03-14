using System;
using System.Collections.Generic;
using AutoMapper;
using Shop.Application.Automapper;
using Shop.Application.Interfaces;
using Shop.CrossCutting;
using Shop.DTOs;
using Shop.Entities;
using Shop.ExternalServices.Interfaces;
using Shop.Models;
using Shop.Models.Interfaces;

namespace Shop.Application
{
    public class ItemApplication : IItemApplication
    {
        private IExternalService _externalService;
        private ILoggerService _logger;
        private IItemDomain _domain;

        public ItemApplication(IExternalService externalService, ILoggerService logger)
        {
            _externalService = externalService;
            _logger = logger;
            _domain = new ItemDomain(externalService,logger);

            Mapper.Initialize(cfg => cfg.AddProfile<ServiceProfile>());
        }

        public ItemDTO GetItem(string itemId, ref string responseMessage)
        {
            ItemEntity itemEntity = _domain.GetItem(itemId, ref responseMessage);
            if (itemEntity != null)
            {
                //ItemDTO itemDTO = new ItemDTO();

                //itemDTO.title = itemEntity.title;
                //itemDTO.price = itemEntity.price;
                //itemDTO.sold_quantity = itemEntity.sold_quantity;
                //itemDTO.available_quantity = itemEntity.available_quantity;
                //itemDTO.itemLargeDescription = itemEntity.ItemLargeDescription.plain_text;
                //itemDTO.picturesUrl = new List<string>();
                //foreach (var picture in itemEntity.pictures)
                //{
                //    itemDTO.picturesUrl.Add(picture.url);
                //}
                //itemDTO.attributes=new List<Tuple<string, string>>();
                //foreach (var attribute in itemEntity.attributes)
                //{
                //    itemDTO.attributes.Add(new Tuple<string, string>(attribute.name, attribute.value_name));
                //}


                

                return Mapper.Map<ItemDTO>(itemEntity);
            }
            else
            {
                return null;
            }
                    
            
            
        }

        public SearchResultDTO SearchItems(string filter, int? offset, int? limit, ref string responseMessage)
        {
            SearchResultEntity searchResult = _domain.SearchItems(filter, offset, limit, ref responseMessage);
            if (searchResult != null)
            {
                //SearchResultDTO searchResultDTO = new SearchResultDTO();
                //searchResultDTO.results = new List<ItemResultDTO>();
                //foreach (var result in searchResult.results)
                //{
                //    ItemResultDTO resultDTO = new ItemResultDTO();
                //    resultDTO.id = result.id;
                //    resultDTO.title = result.title;
                //    resultDTO.price = result.price;
                //    resultDTO.free_shipping = result.shipping.free_shipping;
                //    resultDTO.thumbnail = result.thumbnail;
                //    searchResultDTO.results.Add(resultDTO);
                //}

                //searchResultDTO.totalItemCount = searchResult.paging.total;
                return Mapper.Map<SearchResultDTO>(searchResult);
            }
            else
            {
                return null;
            }
        }
    }
}
