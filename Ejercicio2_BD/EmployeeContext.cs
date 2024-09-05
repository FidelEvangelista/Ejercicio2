using Microsoft.EntityFrameworkCore;

namespace Ejercicio2_BD
{
    public class EmployeeContext
    {

        // DbSet representa una colección de todos los empleados en la base de datos
        // Esta propiedad será usada para realizar operaciones CRUD sobre la tabla Employees
        public DbSet<Employee> Employees { get; set; }

        // Este constructor permite configurar el contexto, como la cadena de conexión a la base de datos.
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }
    }
}
