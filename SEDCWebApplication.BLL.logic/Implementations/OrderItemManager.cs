using System.Collections.Generic;
using AutoMapper;
using SEDCWebApplication.BLL.logic.Interfaces;
using SEDCWebApplication.BLL.logic.Models;
using SEDCWebApplication.DAL.DatabaseFactory.Entities;
using SEDCWebApplication.DAL.DatabaseFactory.Interfaces;
//using SEDCWebApplication.DAL.data.Entities;
//using SEDCWebApplication.DAL.data.Interfaces;
//using SEDCWebApplicationEntityFactory.Entities;
//using SEDCWebApplicationEntityFactory.Interfaces;

namespace SEDCWebApplication.BLL.logic.Implementations
{
    public class OrderItemManager : IOrderItemManager
    {

        private readonly IOrderItemDAL _orderItemDAL;
        private readonly IMapper _mapper;
        public OrderItemManager(IOrderItemDAL orderItemDAL, IMapper mapper)
        {
            _orderItemDAL = orderItemDAL;
            _mapper = mapper;
        }
        public OrderItemDTO Add(OrderItemDTO orderItem)
        {

            OrderItem orderItemEntity = _mapper.Map<OrderItem>(orderItem);
            _orderItemDAL.Save(orderItemEntity);
            orderItem = _mapper.Map<OrderItemDTO>(orderItemEntity);
            return orderItem;
        }
        public OrderItemDTO Delete(OrderItemDTO orderItem)
        {

            OrderItem orderItemEntity = _mapper.Map<OrderItem>(orderItem);
            _orderItemDAL.Delete(orderItemEntity);
            orderItem = _mapper.Map<OrderItemDTO>(orderItemEntity);
            return orderItem;
        }

        public IEnumerable<OrderItemDTO> GetAllOrderItems()
        {
            return _mapper.Map<List<OrderItemDTO>>(_orderItemDAL.GetAll(0, 50));
        }

        public OrderItemDTO GetById(int id)
        {
            return _mapper.Map<OrderItemDTO>(_orderItemDAL.GetById(id));
        }
    }
}
