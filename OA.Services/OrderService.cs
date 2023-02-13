using OA.Core.Models;
using OA.Repository.Interfaces;
using OA.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OA.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository studentRepository)
        {
            _orderRepository = studentRepository;
        }
        public void Delete(Order entity)
        {
            try
            {
                if (entity != null)
                {
                    _orderRepository.Delete(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Order Get(int Id)
        {
            try
            {
                var obj = _orderRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Order GetFullOrder(int Id)
        {
            try
            {
                var obj = _orderRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Order> GetAll()
        {
            try
            {
                var obj = _orderRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(Order entity)
        {
            try
            {
                if (entity != null)
                {
                    _orderRepository.Insert(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Order entity)
        {
            try
            {
                if (entity != null)
                {
                    _orderRepository.Remove(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            try
            {
                if (entity != null)
                {
                    _orderRepository.Update(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
