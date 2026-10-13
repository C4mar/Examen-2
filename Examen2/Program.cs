using System;
using System.Collections.Generic;
using System.Globalization;

class Producto
{
    public string? Nombre { get; set; }
    public int Codigo { get; set; }
    public decimal Precio { get; set; } // decimal para dinero
}

class Tienda
{
    public static void AgregarProductos(List<Producto> productos, int n)
    {
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nProducto {i + 1} de {n}");

            Console.Write("Ingresa el nombre del producto: ");
            string? nombre = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Write("Nombre inválido. Ingresa el nombre del producto: ");
                nombre = Console.ReadLine();
            }

            Console.Write("Ingresa el codigo del producto: ");
            int codigo;
            while (!int.TryParse(Console.ReadLine(), out codigo))
            {
                Console.Write("Código inválido. Ingresa el codigo del producto (entero): ");
            }

            Console.Write("Ingresa el precio del producto: ");
            decimal precio;
            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
            {
                Console.Write("Precio inválido. Ingresa el precio del producto (ej. 12.50): ");
            }

            productos.Add(new Producto { Nombre = nombre, Codigo = codigo, Precio = precio });
        }
    }

    public static void MostrarProductos(IEnumerable<Producto> productos)
    {
        Console.WriteLine("\nProductos en la tienda:");
        foreach (var producto in productos)
        {
            Console.WriteLine($"Nombre: {producto.Nombre}");
            Console.WriteLine($"Codigo: {producto.Codigo}");
            Console.WriteLine($"Precio: {producto.Precio:C2}\n");
        }
    }

    public static decimal CalculaTotal(IEnumerable<Producto> productos)
    {
        decimal total = 0m;
        if (productos == null) return total;
        foreach (var p in productos)
            total += p.Precio;
        return total;
    }
}

class Programa
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a la tienda");
        Console.Write("¿Cuántos productos deseas agregar?: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Número inválido. Terminando programa.");
            return;
        }

        List<Producto> productos = new List<Producto>();
        Tienda.AgregarProductos(productos, n);

        Tienda.MostrarProductos(productos);

        decimal total = Tienda.CalculaTotal(productos);
        Console.WriteLine($"El total de la compra es: {total:C2}");
    }
}
