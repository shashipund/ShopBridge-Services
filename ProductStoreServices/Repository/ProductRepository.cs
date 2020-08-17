using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductStoreServices.Repository
{
    public class ProductRepository : IProductMasterRepository
    {
        public List<Items> GetProductList()
        {
            using (var _itemEntity = new ShopBridgeDBEntities())
            {
                var _list = (from p in _itemEntity.Items
                             select new Items
                             {
                                 Id  = p.ItemID,
                                 Name = p.Name,
                                 Price=(int)p.Price,
                                 Description=p.Description,
                                 ImageName=p.ImageName,
                                 Base64Content= p.Base64Content
                             }).ToList();
                return _list;
            }
        }

        public Item GetProduct(int id)
        {
            using (var _itemEntity = new ShopBridgeDBEntities())
            {
                return _itemEntity.Items.FirstOrDefault(x => x.ItemID == id);
            }
        }
        public bool AddProduct(Item _item)
        {
            using (var _itemEntity = new ShopBridgeDBEntities())
            {
                if (_item != null)
                {

                    _itemEntity.Items.Add(_item);
                    _itemEntity.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateProduct(Item _item)
        {
            using (var _prodEntity = new ShopBridgeDBEntities())
            {
                var _prod = _prodEntity.Items.Where(x => x.ItemID == _item.ItemID).FirstOrDefault();
                if (_prod != null)
                {
                    _prod.Name = _item.Name;
                    _prod.Price = _item.Price;
                    _prod.Description = _item.Description;
                    _prod.ImageName = _item.ImageName;
                    _prod.Base64Content = _item.Base64Content;

                    _prodEntity.SaveChanges();
                }
            }
            return true;
        }


        public bool DeleteProduct(int id)
        {
            using (var _prodEntity = new ShopBridgeDBEntities())
            {
                var _prod = _prodEntity.Items.Where(x => x.ItemID == id).FirstOrDefault();
                if (_prod != null)
                {
                    _prodEntity.Entry(_prod).State = EntityState.Deleted;
                    _prodEntity.SaveChanges();
                }
            }
            return true;
        }

        public List<Items> SearchProductList(string searchTerm)
        {
            using (var _prodEntity = new ShopBridgeDBEntities())
            {
                if (searchTerm.Trim() != null)
                {
                    var list = _prodEntity.SearchItem(searchTerm).ToList<SearchItem_Result>();

                    var result = list.Select(x => new Items()
                    {
                        Name = x.Name,
                        Price = (int)x.Price,
                        Description = x.Description,
                        ImageName = x.ImageName,
                        Base64Content = x.Base64Content
                    }).ToList<Items>();

                    return result;
                }
            }
            return null;
        }

        
    }
}