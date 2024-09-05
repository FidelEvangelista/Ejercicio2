using Ejercicio2_BD;

var builder = WebApplication.CreateBuilder(args);

// Configuramos la conexión a la base de datos
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("masterDB")));

// Inyeccion del el repositorio
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Endpoint para obtener todos los empleados
app.MapGet("/employees", async (IEmployeeRepository repo) =>
{
    var employees = await repo.GetAllAsync();
    return Results.Ok(employees);
});

// Endpoint que agrega un nuevo empleado a la bd
app.MapPost("/employees", async (Employee employee, IEmployeeRepository repo) =>
{
    await repo.AddAsync(employee);
    return Results.Created($"/employees/{employee.EmployeeId}", employee);
});

// Endpoint para actualizar un empleado existente
app.MapPut("/employees/{id}", async (int id, Employee updatedEmployee, IEmployeeRepository repo) =>
{
    var employee = await repo.GetByIdAsync(id);
    if (employee == null)
    {
        return Results.NotFound();
    }

    // Actualizar los datos del empleado por campoo
    employee.FirstName = updatedEmployee.FirstName;
    employee.LastName = updatedEmployee.LastName;
    employee.Salary = updatedEmployee.Salary;

    await repo.UpdateAsync(employee);
    return Results.NoContent();
});

// Endpoint para eliminar un empleado
app.MapDelete("/employees/{id}", async (int id, IEmployeeRepository repo) =>
{
    var employee = await repo.GetByIdAsync(id);
    if (employee == null)
    {
        return Results.NotFound();
    }

    await repo.DeleteAsync(id);
    return Results.NoContent();
});

app.Run();
