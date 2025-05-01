using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCurriculum.Domain.Entities;
using MyCurriculum.Infraestructure.Repositories.Interfaces;

namespace MyCurriculum.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddressAsync()
        {
            var addresses = await _unitOfWork.AddressRepository.GetAll();
            return Ok(addresses);
        }

        [HttpGet("{id:int:min(1)}", Name = "GetAddress")]
        public ActionResult<Address> GetAddressAsync(int id)
        {
            var address = _unitOfWork.AddressRepository.Get(c => c.AddressId == id);
            return address == null ? throw new Exception("ID não encontrado") : (ActionResult<Address>)Ok(address);
        }

        [HttpPost]
        public ActionResult<Address> PostAddressAsync(Address postedAddress)
        {
            var address = _unitOfWork.AddressRepository.Create(postedAddress);
            _unitOfWork.Commit();
            return address != null ? (ActionResult<Address>)Ok(address) : throw new ArgumentNullException("Erro ao tentar salvar a entidade.");
        }

        [HttpPut("{id:int:min(1)}")]
        public ActionResult<Address> PutAddressAsync(int id, Address modifiedAddress)
        {
            if (id != modifiedAddress.AddressId)
            {
                return BadRequest("ID não encontrado");
            }
            var address = _unitOfWork.AddressRepository.Update(modifiedAddress);
            _unitOfWork.Commit();
            return Ok(address);
        }

        [HttpDelete("{id:int:min(1)}")]
        public ActionResult<Address> DeleteAddressAsync(int id)
        {
            var address = _unitOfWork.AddressRepository.Get(c => c.AddressId == id);
            if (address is null)
            {
                return BadRequest("ID não encontrado");
            }
            _unitOfWork.AddressRepository.Delete(address);
            _unitOfWork.Commit();
            return Ok(address);
        }
    }
}
