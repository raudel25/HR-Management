# HR-Management

El proyecto tiene como objetivo el desarrollo de una api para la administración de los recursos humanos en una empresa X. 

### Ejecutando el Proyecto

El Proyecto se encuentra desarrollado en **.Net 6** y se usó **Mysql** como base de datos junto a **Entity Framework Core**. Para ejecutarlo, debe configurar el scrip de conexiona su base de datos sustituyendo los valores que se encuentran en `appsettings.json`, luego debe ejecutar los siguientes comandos en su terminal.

```
make restore
```

o

```
dotnet restore
```

para actualizar las dependencias,

```
make db
```

o

```
dotnet ef database update --project HR-Management
```

para crear y actualizar la base de datos y finalmente

```
make dev
```

o

```
dotnet run --project HR-Management
```

para correr la api.

### Estructura del Proyecto

La api cuenta con los siguientes endpoints:

- employee: Permite crear, actualizar o eliminar un usuario, así como añadir rolles dentro de la empresa a un determinado usuario. Además del método para recalcular el salario del empleado.
- report: Brinda soporte a los dos informes requeridos en la orientación.
- roll: Permite crear, actualizar o eliminar un roll. Actualmente se encuentran creados los roles definidos en la orientación.
