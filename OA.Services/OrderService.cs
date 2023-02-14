using AutoMapper;
using OA.Core.Dto;
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
        private IMapper Mapper
        {
            get;
        }
        public OrderService(IOrderRepository studentRepository, IMapper mapper)
        {
            _orderRepository = studentRepository;
            Mapper = mapper;
        }
        public void Delete(OrderDto _entity)
        {
            try
            {
                if (_entity != null)
                {
                    var entity = Mapper.Map<Order>(_entity);
                    _orderRepository.Delete(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public OrderDto Get(int Id)
        {
            try
            {
                var obj = _orderRepository.Get(Id);
                if (obj != null)
                {
                    var objDto = Mapper.Map<OrderDto>(obj);

                    return objDto;
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
        public OrderDto GetFullOrder(int Id)
        {
            try
            {
                var obj = _orderRepository.Get(Id);
                if (obj != null)
                {
                    var objDto = Mapper.Map<OrderDto>(obj);

                    return objDto;
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
        public IEnumerable<OrderDto> GetAll()
        {
            try
            {
                var data = _orderRepository.GetAll();
                var dataDto = Mapper.Map<IEnumerable<OrderDto>>(data);

                    return dataDto;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(OrderDto _entity)
        {
            try
            {
                if (_entity != null)
                {
                    var entity = Mapper.Map<Order>(_entity);

                    _orderRepository.Insert(entity);
                    _orderRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(OrderDto _entity)
        {
            try
            {
                if (_entity != null)
                {
                    var entity = Mapper.Map<Order>(_entity);
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

        public void Update(OrderDto _entity)
        {
            try
            {
                if (_entity != null)
                {
                    var entity = Mapper.Map<Order>(_entity);
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
