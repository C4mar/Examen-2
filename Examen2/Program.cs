using System;


class Producto{
    public string? Nombre{get; set;}
    public int Codigo{get; set;}
    public double Precio {get;set;}
}

class Tienda{
    public static  void AgregarProducto(int n){
        if (n==0) return ;
        Console.WriteLine("Ingresa el nombre del producto: ");
        string? Nombre = Convert.ToString( Console.ReadLine());
        Console.WriteLine("Ingresa el codigo del producto: ");
        int Codigo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Ingresa el precio del producto:");
        double Precio = Convert.ToDouble(Console.ReadLine());

        List<Producto> productos = new List<Producto>();
        productos.Add(new Producto(){Nombre = Nombre, Codigo = Codigo, Precio = Precio});
        AgregarProducto(n-1);
        MostrarProductos(productos);
        //CalculaTotal(productos);
    }
    public static void MostrarProductos(List<Producto> productos){
        foreach (Producto producto in productos){
            Console.WriteLine($"Nombre del producto es: {producto.Nombre}");
            Console.WriteLine($"Codigo del producto es: {producto.Codigo}");
            Console.WriteLine($"Precio del prodcuto es {producto.Precio}");
        }
    }
    /*public static void CalculaTotal(List<Producto> productos){
        double total = 0;
        foreach (Producto producto in productos){
            total += producto.Precio;
        }
        Console.WriteLine($"El total de la compra es: {total}");
    }*/
}   

class Programa{

    static void Main(){
        Console.WriteLine("Bienvenido a la tienda");
        Console.WriteLine("¿Cuantos productos deseas agregar?: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Tienda.AgregarProducto(n);
    }
}