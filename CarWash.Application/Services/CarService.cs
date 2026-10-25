using CarWash.Application.Contracts.Cars;
using CarWash.Domain.Entities;
using CarWash.Infrastructure.InMemory;

namespace CarWash.Application.Services;

/// <summary>
/// Служба для CRUD-операций над авто
/// </summary>
public class CarService(
    IRepository<Car, int> carRepository,
    IRepository<CarWashCustomer, int> customerRepository)
    : ICarService
{
    public CarDto Create(CarCreateUpdateDto dto)
    {
        CarWashCustomer customer = customerRepository.Read(dto.CustomerId);

        int newId = carRepository.ReadAll()
            .Select(car => car.Id)
            .DefaultIfEmpty(0)
            .Max() + 1;

        var car = new Car
        {
            Id = newId,
            CarCategory = dto.CarCategory,
            LicensePlate = dto.LicensePlate,
            Brand = dto.Brand,
            CustomerId = customer.Id,
            Customer = customer
        };

        carRepository.Create(car);

        customer.Cars.Add(car);

        return MapToDto(car);
    }

    public CarDto Get(int dtoId)
    {
        return MapToDto(carRepository.Read(dtoId));
    }

    public List<CarDto> GetAll()
    {
        return carRepository.ReadAll()
            .Select(MapToDto)
            .ToList();
    }

    public CarDto Update(CarCreateUpdateDto dto, int dtoId)
    {
        Car oldCar = carRepository.Read(dtoId);
        CarWashCustomer customer = customerRepository.Read(dto.CustomerId);

        oldCar.Customer.Cars.Remove(oldCar);

        var car = new Car
        {
            Id = dtoId,
            CarCategory = dto.CarCategory,
            LicensePlate = dto.LicensePlate,
            Brand = dto.Brand,
            CustomerId = customer.Id,
            Customer = customer,
            Orders = oldCar.Orders
        };

        carRepository.Update(car);
        customer.Cars.Add(car);

        return MapToDto(car);
    }

    public void Delete(int dtoId)
    {
        Car car = carRepository.Read(dtoId);

        car.Customer.Cars.Remove(car);
        carRepository.Delete(dtoId);
    }

    private static CarDto MapToDto(Car car)
    {
        return new CarDto(
            car.Id,
            car.CarCategory,
            car.LicensePlate,
            car.Brand,
            car.CustomerId);
    }
}
