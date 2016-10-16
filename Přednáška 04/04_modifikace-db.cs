class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data source = d:\\Northwind.sdf";
        using (SqlCeConnection connection = new SqlCeConnection(connectionString))
        {
            connection.Open();
            //            string commandText = @"UPDATE Customers 
            //               SET [Contact Name] = 'Karel' 
            //               WHERE [Customer Id] = 'ANATR'";
            string commandText = @"UPDATE Customers 
               SET [Contact Name] = 'Ana Trujillo' 
               WHERE [Customer Id] = 'ANATR'";
            SqlCeCommand command = new SqlCeCommand(commandText, connection);
            int rowCount = command.ExecuteNonQuery();

            Console.WriteLine("Pocet ovlivnenych radku: {0}", rowCount);
        }
        Console.ReadKey();
    }
}