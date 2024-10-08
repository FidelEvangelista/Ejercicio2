﻿namespace Ejercicio2_BD
{
    public interface IEmployeeRepository
    {
        //Taks para el CRUD
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
