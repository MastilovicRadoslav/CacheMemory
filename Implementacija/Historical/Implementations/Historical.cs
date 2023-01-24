using CacheMemory.Structures.Interfaces;
using CacheMemory.Structures.Payload;
using System.Data.SqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheMemory.Structures.Implementations
{
    public class Historical : IHistorical
    {
        public void SaveNewRecords(List<SpentEnergyDto> spentEnergyMeters)
        {

            try
            {
                string connectionString;
                SqlConnection cnn;
				connectionString = @"Data Source=DESKTOP-9S5CVCU\SQLEXPRESS;Initial Catalog=ERS-cachememory;Integrated Security=True"; cnn = new SqlConnection(connectionString);
                cnn.Open();

                foreach (var s in spentEnergyMeters)
                {

                    try
                    {
                        var insertQuery = @"Insert into spent_energy_record (timestamp, user_id, spent_energy) values (@timestamp, @user_id, @spent_energy)";
                        SqlCommand insertCommand = new(insertQuery, cnn);

                        insertCommand.Parameters.Add("@timestamp", SqlDbType.DateTime).Value = s.Timestamp;
                        insertCommand.Parameters.Add("@user_id", SqlDbType.Int).Value = s.UserId;
                        insertCommand.Parameters.Add("@spent_energy", SqlDbType.Float).Value = s.SpentEnergy;

                        insertCommand.ExecuteNonQuery();

                        var updateQuery = @"Update spent_energy_meter set spent_total = spent_total + @spent_energy where id=@user_id";
                        SqlCommand updateCommand = new(updateQuery, cnn);
                        updateCommand.Parameters.Add("@user_id", SqlDbType.Int).Value = s.UserId;
                        updateCommand.Parameters.Add("@spent_energy", SqlDbType.Float).Value = s.SpentEnergy;

                        updateCommand.ExecuteNonQuery();
                    }
                    catch (SqlException sqlEx)
                    {
                        Console.WriteLine(sqlEx.StackTrace);
                    }

                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public List<SpentEnergyRecord> GetRecordsByMonth(int month)
        {
            var recordsList = new List<SpentEnergyRecord>();
            try
            {

                SqlConnection cnn;
				var connectionString = @"Data Source=DESKTOP-9S5CVCU\SQLEXPRESS;Initial Catalog=cacheMemory;Integrated Security=True";
				cnn = new SqlConnection(connectionString);
                cnn.Open();
                try
                {
                    var selectQuery = @"SELECT user_id, customer, streetName, streetNumber, city, state, spent_energy, timestamp 
                                        from spent_energy_record inner join spent_energy_meter on spent_energy_record.user_id = spent_energy_meter.id
                                        where MONTH(timestamp)=@month";
                    SqlCommand selectCommand = new(selectQuery, cnn);
                    selectCommand.Parameters.Add("@month", SqlDbType.Int).Value = month;

                    var dataReader = selectCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        recordsList.Add(new SpentEnergyRecord()
                        {
                            UserId = dataReader.GetInt32(0),
                            UserName = dataReader.GetString(1),
                            StreetName = dataReader.GetString(2),
                            StreetNumber = dataReader.GetString(3),
                            City = dataReader.GetString(4),
                            State = dataReader.GetString(5),
                            SpentEnergy = dataReader.GetDouble(6),
                            Timestamp = dataReader.GetDateTime(7)
                        });
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.StackTrace);
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return recordsList;
        }

        public List<SpentEnergyRecord> GetRecordsByUser(int userId)
        {
            var recordsList = new List<SpentEnergyRecord>();
            try
            {

                SqlConnection cnn;
				var connectionString = @"Data Source=DESKTOP-9S5CVCU\SQLEXPRESS;Initial Catalog=cacheMemory;Integrated Security=True";
				cnn = new SqlConnection(connectionString);
                cnn.Open();
                try
                {
                    var selectQuery = @"SELECT user_id, customer, streetName, streetNumber, city, state, spent_energy, timestamp 
                                        from spent_energy_record inner join spent_energy_meter on spent_energy_record.user_id = spent_energy_meter.id
                                        where user_id=@user_id";
                    SqlCommand selectCommand = new(selectQuery, cnn);
                    selectCommand.Parameters.Add("@user_id", SqlDbType.Int).Value = userId;
                    var dataReader = selectCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        recordsList.Add(new SpentEnergyRecord()
                        {
                            UserId = dataReader.GetInt32(0),
                            UserName = dataReader.GetString(1),
                            StreetName = dataReader.GetString(2),
                            StreetNumber = dataReader.GetString(3),
                            City = dataReader.GetString(4),
                            State = dataReader.GetString(5),
                            SpentEnergy = dataReader.GetDouble(6),
                            Timestamp = dataReader.GetDateTime(7)
                        });
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.StackTrace);
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return recordsList;
        }

        public List<SpentEnergyMeter> GetMetersByCityName(string city)
        {
            var recordsList = new List<SpentEnergyMeter>();
            try
            {

                SqlConnection cnn;
				var connectionString = @"Data Source=DESKTOP-9S5CVCU\SQLEXPRESS;Initial Catalog=cacheMemory;Integrated Security=True";
				cnn = new SqlConnection(connectionString);
                cnn.Open();
                try
                {
                    var selectQuery = @"SELECT id, customer, streetName, streetNumber, city, state, spent_total 
                                        from spent_energy_meter
                                        where LOWER(city) like @city";
                    SqlCommand selectCommand = new(selectQuery, cnn);
                    selectCommand.Parameters.Add("@city", SqlDbType.VarChar).Value = city.ToLower();
                    var dataReader = selectCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        recordsList.Add(new SpentEnergyMeter()
                        {

                            Id = dataReader.GetInt32(0),
                            UserName = dataReader.GetString(1),
                            StreetName = dataReader.GetString(2),
                            StreetNumber = dataReader.GetString(3),
                            City = dataReader.GetString(4),
                            State = dataReader.GetString(5),
                            SpentEnergyTotal = dataReader.GetDouble(6)
                        });
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.StackTrace);
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

            return recordsList;
        }
    }
}