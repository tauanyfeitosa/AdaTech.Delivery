using AdaTech.Delivery.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Delivery.Library.Services
{
    public class DeliveryManService
    {
        private readonly List<DeliveryMan> _deliveryMen = new List<DeliveryMan>
        {
            new DeliveryMan
            {
                Id = 1,
                Name = "João",
                LastName = "Silva",
                Email = "joao.silva@email.com",
                PhoneNumber = "55999999999",
                CPF = "123.456.789-09",
                Senha = "Senha123",
                DateBirth = new DateTime(1985, 7, 23),
                IsSuperUser = true,
                IsDeliveryMan = true,
                IsStaff = true,
                IsActive = true
            },
            new DeliveryMan
            {
                Id = 2,
                Name = "Maria",
                LastName = "Fernandes",
                Email = "maria.fernandes@email.com",
                PhoneNumber = "55888888888",
                CPF = "987.654.321-00",
                Senha = "Senha123",
                DateBirth = new DateTime(1990, 5, 19),
                IsSuperUser = true,
                IsDeliveryMan = true,
                IsStaff = true,
                IsActive = false
            },
            new DeliveryMan
            {
                Id = 3,
                Name = "Pedro",
                LastName = "Gonçalves",
                Email = "pedro.goncalves@email.com",
                PhoneNumber = "55777777777",
                CPF = "111.222.333-44",
                Senha = "Senha123",
                DateBirth = new DateTime(1978, 1, 15),
                IsSuperUser = false,
                IsDeliveryMan = true,
                IsStaff = false,
                IsActive = true
            }
        };

        public IEnumerable<DeliveryMan> GetAllDeliveryMen()
        {
            return _deliveryMen;
        }

        public int CreateId()
        {
            if (_deliveryMen.Count == 0)
            {
                return 1;
            }
            return _deliveryMen.Max(x => x.Id) + 1; 
        }

        public void AddDeliveryMan(DeliveryMan deliveryMan)
        {
            _deliveryMen.Add(deliveryMan);
        }

        public DeliveryMan GetDeliveryManByCPF(string CPF)
        {
            return _deliveryMen.FirstOrDefault(x => x.CPF == CPF);
        }

        public void CreateDeliveryMan(DeliveryMan deliveryMan)
        {
            deliveryMan.Id = CreateId();

            AddDeliveryMan(deliveryMan);
        }
    }
}
