class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data source = d:\\Northwind.sdf";
        using (SqlCeConnection connection = new SqlCeConnection(connectionString))
        {
            connection.Open();
            // nějaké operace

            connection.Close(); // není nutné
        }
    }
}