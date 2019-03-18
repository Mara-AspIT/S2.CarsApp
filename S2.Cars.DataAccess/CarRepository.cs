using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using S2.CarsApp.Entities;

namespace S2.CarsApp.DataAccess
{
    public class CarRepository
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DataSet Execute(string sql)
        {
            DataSet resultSet = new DataSet();
            using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(sql, new SqlConnection(connectionString))))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }

        public static Car ExtractFrom(DataRow carRow)
        {
            Car car = new Car();
            car.Id = (int)carRow["Id"];
            car.Make = (string)carRow["Make"];
            car.Model = (string)carRow["Model"];
            car.LicencePlate = (string)carRow["LicencePlate"];
            return car;
        }

        public List<Car> GetAllCars()
        {
            List<Car> allCars = new List<Car>(0);
            string sql = "SELECT * FROM Cars";
            DataSet carsSet = Execute(sql);
            foreach(DataRow dataRow in carsSet.Tables[0].Rows)
            {
                Car car = ExtractFrom(dataRow);
                allCars.Add(car);
            }
            return allCars;
        }

        public void Save(Car car)
        {
            string sql = $"INSERT INTO Cars (Id, Make, Model, LicencePlate) VALUES ({car.Id}, '{car.Make}','{car.Model}','{car.LicencePlate}')";
            Execute(sql);
        }
    }
}
